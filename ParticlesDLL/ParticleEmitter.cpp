#include "ParticleEmitter.h"
#include "Instrumentation.h"
#include <algorithm>
#include <chrono>

namespace Particles {

void ParticleEmitter::bindVariables() {
    // Config — persisted on the object tree, editable from the GUI.
    bindVariable(rate); bindVariable(lifetime); bindVariable(lifetimeJitter);
    bindVariable(startTime); bindVariable(stopTimeField);
    bindVariable(shapeField); bindVariable(coneHalfAngleDeg); bindVariable(shapeSize);
    bindVariable(speed); bindVariable(speedJitter);
    bindVariable(gravX); bindVariable(gravY); bindVariable(gravZ);
    bindVariable(drag); bindVariable(windX); bindVariable(windY); bindVariable(windZ);
    bindVariable(swirlAmp); bindVariable(swirlFreq);
    bindVariable(sizeStart); bindVariable(sizeEnd); bindVariable(alphaStart); bindVariable(alphaEnd);
    bindVariable(colorStartR); bindVariable(colorStartG); bindVariable(colorStartB);
    bindVariable(colorEndR); bindVariable(colorEndG); bindVariable(colorEndB);
    bindVariable(styleField); bindVariable(pointSize); bindVariable(luminous); bindVariable(seedField);
    bindVariable(textureIndex);
    // Live stats — bound so FlexScript / GUI can read them.
    bindVariable(statLiveCount); bindVariable(statBuildMs); bindVariable(statDrawMs);
}

double ParticleEmitter::onCreate(double, double, double, int) {
    return 0;
}

double ParticleEmitter::onReset() {
    startTime = time();   // anchor the emission clock at run/reset start
    return 0;
}

EmitterSpec ParticleEmitter::buildSpec() const {
    EmitterSpec s;
    s.rate = (float)std::max(1e-4, rate);
    s.lifetime = (float)lifetime; s.lifetimeJitter = (float)lifetimeJitter;
    s.startTime = (float)startTime;
    s.stopTime = stopTimeField > 0 ? (float)stopTimeField : 1e30f;
    s.shape = (EmitShape)(int)shapeField;
    s.coneHalfAngleDeg = (float)coneHalfAngleDeg; s.shapeSize = (float)shapeSize;
    s.speed = (float)speed; s.speedJitter = (float)speedJitter;
    s.gravity = { (float)gravX, (float)gravY, (float)gravZ };
    s.drag = (float)drag; s.wind = { (float)windX, (float)windY, (float)windZ };
    s.swirlAmp = (float)swirlAmp; s.swirlFreq = (float)swirlFreq;
    s.sizeStart = (float)sizeStart; s.sizeEnd = (float)sizeEnd;
    s.alphaStart = (float)alphaStart; s.alphaEnd = (float)alphaEnd;
    s.colorStops.count = 2;
    s.colorStops.stops[0] = { 0.0f, rgba{(float)colorStartR,(float)colorStartG,(float)colorStartB,1} };
    s.colorStops.stops[1] = { 1.0f, rgba{(float)colorEndR,(float)colorEndG,(float)colorEndB,1} };
    s.style = (RenderStyle)(int)styleField;
    s.pointSize = (float)pointSize; s.luminous = luminous != 0; s.seed = (uint32_t)seedField;
    return s;
}

double ParticleEmitter::onDraw(treenode view) {
    EmitterSpec s = buildSpec();
    float T = (float)time();

    long cap = std::max(0L, GlobalParticleStats::get().liveCap);
    if ((long)scratch.size() != cap) scratch.resize(cap);

    auto t0 = std::chrono::high_resolution_clock::now();
    int n = cap > 0 ? ::evaluate(s, T, scratch.data(), (int)cap) : 0;
    auto t1 = std::chrono::high_resolution_clock::now();
    statLiveCount = n;
    statBuildMs = std::chrono::duration<double, std::milli>(t1 - t0).count();

    auto d0 = std::chrono::high_resolution_clock::now();
    if (n > 0) {
        if (s.style == RenderStyle::Sprite) drawSprites(view, n, s);
        else                                drawPoints(n, s);
    }
    auto d1 = std::chrono::high_resolution_clock::now();
    statDrawMs = std::chrono::duration<double, std::milli>(d1 - d0).count();

    return (double)__super::onDraw(view);
}

void ParticleEmitter::drawPoints(int n, const EmitterSpec& s) {
    mesh.init(n, MESH_POSITION | MESH_AMBIENT_AND_DIFFUSE4, MESH_DYNAMIC_DRAW);
    for (int k = 0; k < n; ++k) {
        const Particle& p = scratch[k];
        float pos[3] = { p.position.x, p.position.y, p.position.z };
        float col[4] = { p.color.r, p.color.g, p.color.b, p.color.a };
        mesh.setVertexAttrib(k, MESH_POSITION, pos);
        mesh.setVertexAttrib(k, MESH_AMBIENT_AND_DIFFUSE4, col);
    }
    bool wasLit = s.luminous;
    if (wasLit) fglDisable(GL_LIGHTING);
    fglEnable(GL_BLEND);
    glPointSize(s.pointSize);
    mesh.draw(GL_POINTS);
    glPointSize(1.0f);
    if (wasLit) fglEnable(GL_LIGHTING);
}

void ParticleEmitter::drawSprites(treenode /*view*/, int n, const EmitterSpec& s) {
    // Camera-facing basis from the current modelview matrix so quads billboard.
    float mv[16];
    glGetFloatv(GL_MODELVIEW_MATRIX, mv);
    pvec3 right{ mv[0], mv[4], mv[8] };
    pvec3 up{    mv[1], mv[5], mv[9] };

    mesh.init(n * 6, MESH_POSITION | MESH_AMBIENT_AND_DIFFUSE4 | MESH_TEX_COORD2, MESH_DYNAMIC_DRAW);
    static const float uv[6][2] = {{0,0},{1,0},{1,1},{0,0},{1,1},{0,1}};
    static const int   idx[6]   = {0,1,2,0,2,3};
    int v = 0;
    for (int k = 0; k < n; ++k) {
        const Particle& p = scratch[k];
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
    int tex = (int)textureIndex;
    if (tex > 0) { bindtexture(tex); fglEnable(GL_TEXTURE_2D); }
    mesh.draw(GL_TRIANGLES);
    if (tex > 0) { bindtexture(0); fglDisable(GL_TEXTURE_2D); }
    glDepthMask(GL_TRUE);
    fglEnable(GL_LIGHTING);
}

}  // namespace Particles
