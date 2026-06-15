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
    bindVariable(statEmitterCount); bindVariable(statTotalLive);
    bindVariable(statBuildMs); bindVariable(statDrawMs);
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
    long totalLive = 0;
    int count = 0;

    auto t0 = std::chrono::high_resolution_clock::now();
    forobjecttreeunder(model()) {
        if (!isclasstype(a, "Particles::ParticleEmitter")) continue;
        ParticleEmitter* e = a->objectAs(ParticleEmitter);
        if (!e) continue;
        ++count;
        EmitterSpec s = e->buildSpec();
        Vec3 loc = e->getLocation(0, 0, 0);
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

    // --- Draw: one points batch + one batch per sprite texture ---
    // FlexSim invokes onDraw in a frame that is rotated relative to the model's
    // Z-up coordinates. Our particle positions come from getLocation() (model
    // space), so bracket the draw in the same -90 deg X rotation RouteGraph uses
    // and restore it afterward. The sprite billboard basis is read from the
    // modelview *inside* this bracket, so quads still face the camera correctly.
    auto d0 = std::chrono::high_resolution_clock::now();
    fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);
    if (!points.empty()) drawPointsBatch(points);
    for (auto& kv : spritesByTex)
        if (!kv.second.empty()) drawSpriteBatch(kv.first, kv.second);
    fglRotate(90.0f, 1.0f, 0.0f, 0.0f);
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
    fglDisable(GL_LIGHTING);
    fglEnable(GL_BLEND);
    glPointSize((float)pointSize);
    pointsMesh.draw(GL_POINTS);
    glPointSize(1.0f);
    fglEnable(GL_LIGHTING);
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
    fglDisable(GL_LIGHTING);
    fglEnable(GL_BLEND);
    glDepthMask(GL_FALSE);
    if (texIndex > 0) { bindtexture(texIndex); fglEnable(GL_TEXTURE_2D); }
    mesh.draw(GL_TRIANGLES);
    if (texIndex > 0) { bindtexture(0); fglDisable(GL_TEXTURE_2D); }
    glDepthMask(GL_TRUE);
    fglEnable(GL_LIGHTING);
}

}  // namespace Particles
