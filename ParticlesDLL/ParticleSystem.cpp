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

// Add one aim arrow (box shaft + pyramid tip) to the mesh, transformed to world
// coordinates by the emitter's base+rotation (the same transform the particles use),
// at world size A. Per-face normals so it shades under the scene lighting.
static void addArrowToMesh(Mesh& m, float A, const pvec3& base, const pvec3& rot, const float* col) {
    float shaftH = 0.62f*A, tipH = 0.42f*A, hw = 0.05f*A, tw = 0.12f*A;
    auto addTri = [&](pvec3 a, pvec3 b, pvec3 c) {
        pvec3 wa = localToWorld(a, base, rot), wb = localToWorld(b, base, rot), wc = localToWorld(c, base, rot);
        pvec3 e1{wb.x-wa.x,wb.y-wa.y,wb.z-wa.z}, e2{wc.x-wa.x,wc.y-wa.y,wc.z-wa.z};
        pvec3 nn{ e1.y*e2.z-e1.z*e2.y, e1.z*e2.x-e1.x*e2.z, e1.x*e2.y-e1.y*e2.x };
        float l = std::sqrt(nn.x*nn.x+nn.y*nn.y+nn.z*nn.z); if (l>1e-6f){nn.x/=l;nn.y/=l;nn.z/=l;}
        pvec3 ws[3]={wa,wb,wc};
        for (auto& w : ws) {
            int vi = m.addVertex();
            float p[3]={w.x,w.y,w.z}, nr[3]={nn.x,nn.y,nn.z};
            m.setVertexAttrib(vi, MESH_POSITION, p);
            m.setVertexAttrib(vi, MESH_NORMAL, nr);
            m.setVertexAttrib(vi, MESH_AMBIENT_AND_DIFFUSE4, (float*)col);
        }
    };
    pvec3 c8[8]={{-hw,-hw,0},{hw,-hw,0},{hw,hw,0},{-hw,hw,0},{-hw,-hw,shaftH},{hw,-hw,shaftH},{hw,hw,shaftH},{-hw,hw,shaftH}};
    int f[12][3]={{0,1,2},{0,2,3},{4,6,5},{4,7,6},{0,4,5},{0,5,1},{1,5,6},{1,6,2},{2,6,7},{2,7,3},{3,7,4},{3,4,0}};
    for (auto& t : f) addTri(c8[t[0]],c8[t[1]],c8[t[2]]);
    pvec3 ap{0,0,shaftH+tipH}, p0{-tw,-tw,shaftH}, p1{tw,-tw,shaftH}, p2{tw,tw,shaftH}, p3{-tw,tw,shaftH};
    addTri(p0,p1,ap); addTri(p1,p2,ap); addTri(p2,p3,ap); addTri(p3,p0,ap);
    addTri(p0,p2,p1); addTri(p0,p3,p2);
}

double ParticleSystem::onDraw(treenode view) {
    // TEMPORARILY DISABLED. The emitters now draw their own region outline + aim
    // arrow in ParticleEmitter::onDraw so they are individually selectable. The
    // system's batched particle/arrow draw is parked here until we revisit why it
    // was leaking GL state / not self-containing. Re-enable by removing this early
    // return. (Stats are zeroed so the GUI doesn't show stale counts.)
    statEmitterCount = statTotalLive = statBuildMs = statDrawMs = 0;
    return (double)__super::onDraw(view);

#if 0
    bool picking = getpickingmode(view) != 0;
    float T = (float)time();
    long cap = std::max(0L, (long)liveCap);
    if (!picking && (long)scratch.size() < cap) scratch.resize(cap);

    // The aim arrows are the emitters' selectable handles: built in world coordinates
    // (so they can't drift/deform) with a per-emitter pick range (so clicking one
    // selects that emitter). Built in BOTH passes; particles only in the normal pass.
    const float arrowCol[4] = { 0.30f, 0.46f, 0.95f, 1.0f };
    arrowMesh.init(0, MESH_POSITION | MESH_NORMAL | MESH_AMBIENT_AND_DIFFUSE4, MESH_DYNAMIC_DRAW);
    bool anyArrows = false;

    std::vector<Particle> points;
    std::map<int, std::vector<Particle>> spritesByTex;
    long totalLive = 0;
    int count = 0;

    auto t0 = std::chrono::high_resolution_clock::now();
    forobjecttreeunder(model()) {
        if (!isclasstype(a, "Particles::ParticleEmitter")) continue;
        ParticleEmitter* e = a->objectAs(ParticleEmitter);
        if (!e) continue;
        ++count;
        EmitterSpec s = e->buildSpec();
        Vec3 loc = e->getLocation(0.5, 0.5, 0);   // base center (z=0)
        Vec3 rot = e->rotation;
        pvec3 wp{ (float)loc.x, (float)loc.y, (float)loc.z };
        pvec3 rd{ (float)rot.x, (float)rot.y, (float)rot.z };

        if (showArrows != 0 && s.direction == DirectionMode::Aimed) {
            arrowMesh.beginPickRange(GL_TRIANGLES, a, PICK_OBJECT, 0, 0);
            addArrowToMesh(arrowMesh, (float)arrowSize, wp, rd, arrowCol);
            arrowMesh.endPickRange();
            anyArrows = true;
        }

        if (picking) continue;   // particles are never pickable -- skip the heavy eval

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

    // FlexSim's onDraw frame is rotated vs the model's Z-up; our positions come from
    // getLocation() (model space), so bracket every draw in the same -90deg X rotation.
    // --- PICK pass: only the arrows' pick ranges (so a click selects the emitter) ---
    if (picking) {
        fglDisable(GL_TEXTURE_2D);
        fglDisable(GL_LIGHTING);
        fglPushMatrix();
        fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);
        if (anyArrows) arrowMesh.drawPickRanges(view);
        fglPopMatrix();
        setpickingdrawfocus(view, 0, 0, 0, OVERRIDE_DRAW_ALL);
        fglEnable(GL_LIGHTING);
        fglEnable(GL_TEXTURE_2D);
        return (double)__super::onDraw(view);
    }
    statBuildMs = std::chrono::duration<double, std::milli>(t1 - t0).count();

    // --- NORMAL pass: particles + lit arrows, with a single state set/restore ---
    auto d0 = std::chrono::high_resolution_clock::now();
    fglDisable(GL_TEXTURE_2D);
    fglDisable(GL_LIGHTING);
    fglEnable(GL_BLEND);
    fglPushMatrix();
    fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);
    if (!points.empty()) drawPointsBatch(points);
    for (auto& kv : spritesByTex)
        if (!kv.second.empty()) drawSpriteBatch(kv.first, kv.second);
    if (anyArrows) { fglEnable(GL_LIGHTING); arrowMesh.draw(GL_TRIANGLES); }   // lit
    fglPopMatrix();
    // restore FlexSim defaults + reset the pick draw focus, so the draw is self-contained
    fglDisable(GL_BLEND);
    fglEnable(GL_TEXTURE_2D);
    fglEnable(GL_LIGHTING);
    glDepthMask(GL_TRUE);
    glPointSize(1.0f);
    glLineWidth(1.0f);
    fglColor(1.0f, 1.0f, 1.0f, 1.0f);
    setpickingdrawfocus(view, 0, 0, 0, OVERRIDE_DRAW_ALL);
    auto d1 = std::chrono::high_resolution_clock::now();
    statDrawMs = std::chrono::duration<double, std::milli>(d1 - d0).count();

    statEmitterCount = count;
    statTotalLive = (double)totalLive;
    return (double)__super::onDraw(view);
#endif
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

}  // namespace Particles
