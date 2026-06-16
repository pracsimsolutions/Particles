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


double ParticleSystem::onDraw(treenode view) {
    // The system is an invisible manager: keep its name label hidden every frame.
    switch_hidelabel(holder, 1);

    // Particles are never pickable, and the emitters draw their own handles -> there is
    // nothing for the system to contribute to the pick pass.
    if (getpickingmode(view) != 0)
        return (double)__super::onDraw(view);

    float T = (float)time();
    long cap = std::max(0L, (long)liveCap);
    if ((long)scratch.size() < cap) scratch.resize(cap);

    std::vector<Particle> points;
    std::map<int, std::vector<Particle>> spritesByTex;
    long totalLive = 0;
    int count = 0;

    // Scan every emitter once, evaluate its live particles analytically (pure function of
    // model time T -- no events), and bucket them for one batched draw call per kind. The
    // emitters draw their own region outline + aim pyramid in their own onDraw; the system
    // ONLY draws particles now (drawing the arrows here was the old "funky" double-draw).
    auto t0 = std::chrono::high_resolution_clock::now();
    forobjecttreeunder(model()) {
        if (!isclasstype(a, "Particles::ParticleEmitter")) continue;
        ParticleEmitter* e = a->objectAs(ParticleEmitter);
        if (!e) continue;
        ++count;
        EmitterSpec s = e->buildSpec();
        Vec3 loc = e->getLocation(0.5, 0.5, 0.5);   // spawn from the object center (matches the region)
        Vec3 rot = e->rotation;
        pvec3 wp{ (float)loc.x, (float)loc.y, (float)loc.z };
        pvec3 rd{ (float)rot.x, (float)rot.y, (float)rot.z };

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

    // Particle positions are model-space world coordinates; the DLL onDraw frame is rotated
    // +90deg about X from model Z-up, so fglRotate(-90,1,0,0) brings us to model-aligned.
    //
    // Snapshot every GL flag we touch and restore it EXACTLY afterwards. Forcing fixed
    // values (e.g. blend OFF, color white) leaked onto FlexSim's later translucent passes
    // and made the selection orb render as a solid white ball. Leave state as we found it.
    auto d0 = std::chrono::high_resolution_clock::now();

    // Billboard axes for sprite particles. Read the modelview NOW -- before any fgl matrix
    // ops, so it is the current entry matrix M_entry. The full draw modelview is
    // M_full = M_entry * R(-90,X) (our model-aligning rotation), which maps model-space
    // positions -> eye; its first two rows are the camera right/up in model space (a correct
    // billboard at every angle). Row0(M_entry*R(-90,X)) = (m0, -m8, m4); Row1 = (m1, -m9, m5).
    float mvs[16];
    glGetFloatv(GL_MODELVIEW_MATRIX, mvs);
    auto norm = [](pvec3 v) { float l = std::sqrt(v.x*v.x+v.y*v.y+v.z*v.z);
                              if (l > 1e-6f) { v.x/=l; v.y/=l; v.z/=l; } return v; };
    pvec3 billRight = norm(pvec3{ mvs[0], -mvs[8], mvs[4] });
    pvec3 billUp    = norm(pvec3{ mvs[1], -mvs[9], mvs[5] });

    GLboolean wasBlend = glIsEnabled(GL_BLEND);
    GLboolean wasTex   = glIsEnabled(GL_TEXTURE_2D);
    GLboolean wasLight = glIsEnabled(GL_LIGHTING);
    GLboolean wasDepthMask = GL_TRUE; glGetBooleanv(GL_DEPTH_WRITEMASK, &wasDepthMask);

    fglDisable(GL_TEXTURE_2D);
    fglDisable(GL_LIGHTING);
    fglEnable(GL_BLEND);
    // Write depth so the particles "claim" their pixels. FlexSim fills the sky/background
    // AFTER the object pass on any pixel with no depth written, so depth-mask-off particles
    // over open space get painted over (they only survived where geometry backed them).
    glDepthMask(GL_TRUE);
    fglPushMatrix();
    fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);
    if (!points.empty()) drawPointsBatch(points);
    for (auto& kv : spritesByTex)
        if (!kv.second.empty()) drawSpriteBatch(kv.first, kv.second, billRight, billUp);
    fglPopMatrix();

    // restore exactly what we found
    if (wasBlend) fglEnable(GL_BLEND); else fglDisable(GL_BLEND);
    if (wasTex)   fglEnable(GL_TEXTURE_2D); else fglDisable(GL_TEXTURE_2D);
    if (wasLight) fglEnable(GL_LIGHTING); else fglDisable(GL_LIGHTING);
    glDepthMask(wasDepthMask);
    glPointSize(1.0f);
    glLineWidth(1.0f);
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

void ParticleSystem::drawSpriteBatch(int texIndex, const std::vector<Particle>& sprites,
                                     const pvec3& right, const pvec3& up) {
    // right/up are the camera-facing billboard axes (model space), computed once per frame
    // in onDraw from the entry modelview -- correct at every camera angle.
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
    // Write depth (inherit GL_TRUE from onDraw) like the points, so sprites survive FlexSim's
    // later floor/background pass -- depth-mask-off sprites got painted over wherever the
    // ground was behind them (they only showed against the open sky).
    if (texIndex > 0) { bindtexture(texIndex); fglEnable(GL_TEXTURE_2D); }
    mesh.draw(GL_TRIANGLES);
    if (texIndex > 0) { bindtexture(0); fglDisable(GL_TEXTURE_2D); }
}

}  // namespace Particles
