#include "ParticleSystem.h"
#include <algorithm>
#include <chrono>

namespace Particles {

ParticleSystem* ParticleSystem::instance = nullptr;

ParticleSystem::~ParticleSystem() {
    if (ParticleSystem::instance == this)
        ParticleSystem::instance = nullptr;
}

void ParticleSystem::bindVariables() {
    ParticleSystem::instance = this;
    bindVariable(pointSize);
    bindVariable(liveCap);
    bindVariable(showPlanes); bindVariable(showArrows); bindVariable(arrowSize);
    bindVariable(statEmitterCount); bindVariable(statTotalLive);
    bindVariable(statBuildMs); bindVariable(statDrawMs);
}

void ParticleSystem::bindInterface() {
    bindParentClass("Object");   // REQUIRED before bindTypedProperty (or nothing registers).
    // Register the static "Particles" namespace so FlexScript can reach the
    // singleton via Particles.system (then .liveCap, .statTotalLive, .setCap(n), ...).
    bindClassByName<Statics>("Particles", true);
    #define PS_BIND(n) bindTypedProperty(n, double, &ParticleSystem::pget_##n, &ParticleSystem::pset_##n)
    PS_BIND(pointSize); PS_BIND(liveCap); PS_BIND(showPlanes); PS_BIND(showArrows); PS_BIND(arrowSize);
    #undef PS_BIND
    bindTypedProperty(statEmitterCount, double, &ParticleSystem::pget_statEmitterCount, nullptr);
    bindTypedProperty(statTotalLive, double, &ParticleSystem::pget_statTotalLive, nullptr);
    bindTypedProperty(statBuildMs, double, &ParticleSystem::pget_statBuildMs, nullptr);
    bindTypedProperty(statDrawMs, double, &ParticleSystem::pget_statDrawMs, nullptr);
    bindMethod(setCap, ParticleSystem, "double setCap(double maxLivePerEmitter)");
}

void ParticleSystem::Statics::bindInterface() {
    bindStaticTypedPropertyByName<ParticleSystem*>("system", "Particles.System",
        force_cast<void*>(&ParticleSystem::Statics::getSystem), nullptr);
}

double ParticleSystem::onCreate(double, double, double, int) {
    switch_noselect(holder, 1);   // the system itself is never selectable
    return 0;
}

double ParticleSystem::onReset() {
    switch_noselect(holder, 1);
    // Anchor each emitter's emission clock to the run start.
    double now = time();
    forobjecttreeunder(model()) {
        if (isclasstype(a, "Particles::ParticleEmitter")) {
            ParticleEmitter* e = a->objectAs(ParticleEmitter);
            if (e) e->startTime = now;
        }
    }
    return 0;
}

// Append one aim-arrow (box shaft + pyramid tip) to a world-space triangle buffer,
// built at world size A (so it never deforms with the object) and oriented by the
// emitter's rotation about its base -- the exact transform the particles use.
static void appendTriW(std::vector<float>& v, const pvec3& base, const pvec3& rot, pvec3 a, pvec3 b, pvec3 c) {
    pvec3 wa = localToWorld(a, base, rot), wb = localToWorld(b, base, rot), wc = localToWorld(c, base, rot);
    v.push_back(wa.x); v.push_back(wa.y); v.push_back(wa.z);
    v.push_back(wb.x); v.push_back(wb.y); v.push_back(wb.z);
    v.push_back(wc.x); v.push_back(wc.y); v.push_back(wc.z);
}
static void appendArrow(std::vector<float>& v, float A, const pvec3& base, const pvec3& rot) {
    float shaftH = 0.62f*A, tipH = 0.42f*A, hw = 0.05f*A, tw = 0.12f*A;
    pvec3 c[8] = {{-hw,-hw,0},{hw,-hw,0},{hw,hw,0},{-hw,hw,0},{-hw,-hw,shaftH},{hw,-hw,shaftH},{hw,hw,shaftH},{-hw,hw,shaftH}};
    int f[12][3]={{0,1,2},{0,2,3},{4,6,5},{4,7,6},{0,4,5},{0,5,1},{1,5,6},{1,6,2},{2,6,7},{2,7,3},{3,7,4},{3,4,0}};
    for (auto& t : f) appendTriW(v, base, rot, c[t[0]], c[t[1]], c[t[2]]);
    pvec3 ap{0,0,shaftH+tipH};
    pvec3 p0{-tw,-tw,shaftH}, p1{tw,-tw,shaftH}, p2{tw,tw,shaftH}, p3{-tw,tw,shaftH};
    appendTriW(v,base,rot,p0,p1,ap); appendTriW(v,base,rot,p1,p2,ap);
    appendTriW(v,base,rot,p2,p3,ap); appendTriW(v,base,rot,p3,p0,ap);
    appendTriW(v,base,rot,p0,p2,p1); appendTriW(v,base,rot,p0,p3,p2);
}

double ParticleSystem::onDraw(treenode view) {
    // Never draw particles during the hit-test pass, so clicking a particle
    // selects nothing. Emitter objects draw their own shapes and stay pickable.
    if (getpickingmode(view))
        return (double)__super::onDraw(view);

    float T = (float)time();
    long cap = std::max(0L, (long)liveCap);
    if ((long)scratch.size() < cap) scratch.resize(cap);

    // --- Collect: evaluate every emitter, bake its world transform, bin by material ---
    std::vector<Particle> points;
    std::map<int, std::vector<Particle>> spritesByTex;
    std::vector<float> arrowVerts;
    long totalLive = 0;
    int count = 0;

    auto t0 = std::chrono::high_resolution_clock::now();
    forobjecttreeunder(model()) {
        if (!isclasstype(a, "Particles::ParticleEmitter")) continue;
        ParticleEmitter* e = a->objectAs(ParticleEmitter);
        if (!e) continue;
        ++count;
        EmitterSpec s = e->buildSpec();
        Vec3 loc = e->getLocation(0.5, 0.5, 0);   // emit from the object's base center (z=0)
        Vec3 rot = e->rotation;
        pvec3 wp{ (float)loc.x, (float)loc.y, (float)loc.z };
        pvec3 rd{ (float)rot.x, (float)rot.y, (float)rot.z };

        // Aim arrow: drawn in model units => constant world size, never deforms.
        if (showArrows != 0 && s.direction == DirectionMode::Aimed)
            appendArrow(arrowVerts, (float)arrowSize, wp, rd);

        int n = cap > 0 ? ::evaluate(s, T, scratch.data(), (int)cap) : 0;
        e->statLiveCount = n;
        totalLive += n;

        std::vector<Particle>& dst = (s.style == RenderStyle::Sprite)
            ? spritesByTex[(int)e->textureIndex] : points;
        for (int k = 0; k < n; ++k) {
            Particle p = scratch[k];
            p.position = localToWorld(p.position, wp, rd);
            dst.push_back(p);
        }
    }
    auto t1 = std::chrono::high_resolution_clock::now();
    statBuildMs = std::chrono::duration<double, std::milli>(t1 - t0).count();

    // --- Draw: one points batch + one batch per sprite texture ---
    // FlexSim invokes onDraw in a frame that is rotated relative to the model's
    // Z-up coordinates. Our particle positions come from getLocation() (model
    // space), so bracket the draw in the same -90 deg X rotation RouteGraph uses
    // and restore it afterward. The sprite billboard basis is read from the
    // modelview *inside* this bracket, so quads still face the camera correctly.
    auto d0 = std::chrono::high_resolution_clock::now();
    // Set the GL state our draws need ONCE and restore it ONCE, so an emitter never
    // leaks state onto other objects (lighting/texture/blend/depth/color/sizes).
    fglDisable(GL_LIGHTING);
    fglDisable(GL_TEXTURE_2D);
    fglEnable(GL_BLEND);
    fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);
    if (!points.empty()) drawPointsBatch(points);
    for (auto& kv : spritesByTex)
        if (!kv.second.empty()) drawSpriteBatch(kv.first, kv.second);
    if (!arrowVerts.empty()) drawArrowBatch(arrowVerts);
    fglRotate(90.0f, 1.0f, 0.0f, 0.0f);
    fglDisable(GL_BLEND);
    fglEnable(GL_TEXTURE_2D);
    fglEnable(GL_LIGHTING);
    glDepthMask(GL_TRUE);
    glPointSize(1.0f);
    glLineWidth(1.0f);
    fglColor(1.0f, 1.0f, 1.0f, 1.0f);
    auto d1 = std::chrono::high_resolution_clock::now();
    statDrawMs = std::chrono::duration<double, std::milli>(d1 - d0).count();

    statEmitterCount = count;
    statTotalLive = (double)totalLive;
    return (double)__super::onDraw(view);
}

void ParticleSystem::drawPointsBatch(const std::vector<Particle>& pts) {
    int n = (int)pts.size();
    pointsMesh.init(n, MESH_POSITION | MESH_AMBIENT_AND_DIFFUSE4, MESH_DYNAMIC_DRAW);
    for (int k = 0; k < n; ++k) {
        const Particle& p = pts[k];
        float pos[3] = { p.position.x, p.position.y, p.position.z };
        float col[4] = { p.color.r, p.color.g, p.color.b, p.color.a };
        pointsMesh.setVertexAttrib(k, MESH_POSITION, pos);
        pointsMesh.setVertexAttrib(k, MESH_AMBIENT_AND_DIFFUSE4, col);
    }
    glPointSize((float)pointSize);
    pointsMesh.draw(GL_POINTS);
}

void ParticleSystem::drawSpriteBatch(int texIndex, const std::vector<Particle>& sprites) {
    // Camera-facing basis from the current modelview matrix so quads billboard.
    float mv[16];
    glGetFloatv(GL_MODELVIEW_MATRIX, mv);
    pvec3 right{ mv[0], mv[4], mv[8] };
    pvec3 up{    mv[1], mv[5], mv[9] };

    Mesh& mesh = spriteMeshes[texIndex];
    int n = (int)sprites.size();
    mesh.init(n * 6, MESH_POSITION | MESH_AMBIENT_AND_DIFFUSE4 | MESH_TEX_COORD2, MESH_DYNAMIC_DRAW);
    static const float uv[6][2] = {{0,0},{1,0},{1,1},{0,0},{1,1},{0,1}};
    static const int   idx[6]   = {0,1,2,0,2,3};
    int v = 0;
    for (int k = 0; k < n; ++k) {
        const Particle& p = sprites[k];
        pvec3 r = right * (p.size * 0.5f);
        pvec3 u = up * (p.size * 0.5f);
        pvec3 corner[4] = { p.position - r - u, p.position + r - u,
                            p.position + r + u, p.position - r + u };
        float col[4] = { p.color.r, p.color.g, p.color.b, p.color.a };
        for (int t = 0; t < 6; ++t, ++v) {
            const pvec3& c = corner[idx[t]];
            float pos[3] = { c.x, c.y, c.z };
            float tc[2]  = { uv[t][0], uv[t][1] };
            mesh.setVertexAttrib(v, MESH_POSITION, pos);
            mesh.setVertexAttrib(v, MESH_AMBIENT_AND_DIFFUSE4, col);
            mesh.setVertexAttrib(v, MESH_TEX_COORD2, tc);
        }
    }
    glDepthMask(GL_FALSE);
    if (texIndex > 0) { bindtexture(texIndex); fglEnable(GL_TEXTURE_2D); }
    mesh.draw(GL_TRIANGLES);
    if (texIndex > 0) { bindtexture(0); fglDisable(GL_TEXTURE_2D); }
    glDepthMask(GL_TRUE);
}

void ParticleSystem::drawArrowBatch(const std::vector<float>& verts) {
    int n = (int)verts.size() / 3;
    if (n <= 0) return;
    const float col[4] = { 0.30f, 0.42f, 0.78f, 1.0f };   // handle blue
    std::vector<float> cols((size_t)n * 4);
    for (int k = 0; k < n; ++k) { cols[k*4]=col[0]; cols[k*4+1]=col[1]; cols[k*4+2]=col[2]; cols[k*4+3]=col[3]; }
    arrowMesh.init(n, MESH_POSITION | MESH_AMBIENT_AND_DIFFUSE4, MESH_DYNAMIC_DRAW);
    arrowMesh.defineVertexAttribs(MESH_POSITION, (float*)verts.data());
    arrowMesh.defineVertexAttribs(MESH_AMBIENT_AND_DIFFUSE4, cols.data());
    arrowMesh.draw(GL_TRIANGLES);
}

}  // namespace Particles
