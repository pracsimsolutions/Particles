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
    bindVariable(lod); bindVariable(lodStart); bindVariable(lodMin); bindVariable(frustumCull);
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
    PS_BIND(lod); PS_BIND(lodStart); PS_BIND(lodMin); PS_BIND(frustumCull);
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
    // NOTE: startTime is a user-controlled absolute model time when emission begins
    // (default 0 = from run start). We deliberately do NOT overwrite it here -- doing so
    // clobbered any value the user set back to 0 on every reset. The analytic birth schedule
    // (birth = startTime + i/rate) already gives a clean restart at T=0 when startTime is 0.
    return 0;
}


// Column-major 4x4 multiply: C = A * B.
static void mul4(const float* A, const float* B, float* C) {
    for (int col = 0; col < 4; ++col)
        for (int row = 0; row < 4; ++row) {
            float s = 0; for (int k = 0; k < 4; ++k) s += A[k*4+row] * B[col*4+k];
            C[col*4+row] = s;
        }
}
// True if the whole [center +/- R] AABB is outside one frustum plane (safe to cull). The
// "all 8 corners beyond a single plane" test never culls a partly-visible cloud.
static bool cloudOffscreen(const float* mvp, const pvec3& c, float R) {
    int oL=1,oR=1,oB=1,oT=1,oN=1,oF=1;
    for (int i = 0; i < 8; ++i) {
        float x=c.x+((i&1)?R:-R), y=c.y+((i&2)?R:-R), z=c.z+((i&4)?R:-R);
        float cx=mvp[0]*x+mvp[4]*y+mvp[8]*z+mvp[12];
        float cy=mvp[1]*x+mvp[5]*y+mvp[9]*z+mvp[13];
        float cz=mvp[2]*x+mvp[6]*y+mvp[10]*z+mvp[14];
        float cw=mvp[3]*x+mvp[7]*y+mvp[11]*z+mvp[15];
        if (cx > -cw) oL=0;  if (cx < cw) oR=0;
        if (cy > -cw) oB=0;  if (cy < cw) oT=0;
        if (cz > -cw) oN=0;  if (cz < cw) oF=0;
    }
    return oL||oR||oB||oT||oN||oF;
}

// Read a 4x4 matrix (column-major, 16 floats) from the LIVE shader pipeline. Under FlexSim's
// shader renderer glGetFloatv(GL_MODELVIEW_MATRIX) returns identity, so the camera transform
// must come from fglInfo (FGL_INFO_MODELVIEW_MATRIX / FGL_INFO_PROJECTION_MATRIX). fglInfo
// returns the matrix as a 1-based Array of 16 numbers.
static void readMat16(int op, treenode view, float* m) {
    Array a = fglInfo(op, view);
    int n = (int)a.size();
    for (int i = 0; i < 16; ++i)
        m[i] = (i < n) ? (float)(double)a[i + 1] : ((i % 5 == 0) ? 1.0f : 0.0f);
}

double ParticleSystem::onDraw(treenode view) {
    // The system is an invisible manager: keep its name label hidden every frame.
    switch_hidelabel(holder, 1);

    // Particles are never pickable, and the emitters draw their own handles -> there is
    // nothing for the system to contribute to the pick pass.
    if (getpickingmode(view) != 0)
        return (double)__super::onDraw(view);

    // Lazy-load the built-in soft round sprite used for the Points style (every particle is
    // now a camera-facing billboard quad; Points use this, Sprites use the emitter texture).
    if (softDotTex < 0)
        softDotTex = (int)loadimage("modules\\Particles\\bitmaps\\soft_dot.png", "particles_soft_dot");

    float T = (float)time();
    long cap = std::max(0L, (long)liveCap);
    if ((long)scratch.size() < cap) scratch.resize(cap);

    static const float Rx[16] = {1,0,0,0, 0,0,-1,0, 0,1,0,0, 0,0,0,1};  // fglRotate(-90,1,0,0)
    auto norm = [](pvec3 v) { float l = std::sqrt(v.x*v.x+v.y*v.y+v.z*v.z);
                              if (l > 1e-6f) { v.x/=l; v.y/=l; v.z/=l; } return v; };
    // Frustum-cull matrix from the shader matrices: MVP = projection * (M_entry * R(-90,X)).
    float mvp[16];
    { float m[16], p[16], mf[16]; readMat16(FGL_INFO_MODELVIEW_MATRIX, view, m);
      readMat16(FGL_INFO_PROJECTION_MATRIX, view, p); mul4(m, Rx, mf); mul4(p, mf, mvp); }

    std::map<int, std::vector<Particle>> spritesByTex;
    long totalLive = 0;
    int count = 0, culled = 0;

    // Scan every emitter once, evaluate its live particles analytically (pure function of
    // model time T -- no events) with per-emitter frustum cull + distance LOD, and bucket
    // them by texture for one batched billboard draw per texture.
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

        // Frustum cull: bound the whole cloud (region + ballistic travel) and skip evaluate()
        // entirely when it is fully off-screen. Generous radius so nothing visible pops.
        if (frustumCull != 0) {
            float maxLife = s.lifetime + (s.lifetimeJitter > 0 ? s.lifetimeJitter : 0);
            float g = std::sqrt(s.gravity.x*s.gravity.x + s.gravity.y*s.gravity.y + s.gravity.z*s.gravity.z)
                    + std::sqrt(s.wind.x*s.wind.x + s.wind.y*s.wind.y + s.wind.z*s.wind.z);
            Vec3 sz = e->size;
            float regionR = 0.5f * (float)std::sqrt(sz.x*sz.x + sz.y*sz.y + sz.z*sz.z);
            float R = regionR + (s.speed + s.speedJitter) * maxLife + 0.5f * g * maxLife * maxLife + 0.5f;
            if (cloudOffscreen(mvp, wp, R)) { e->statLiveCount = 0; ++culled; continue; }
        }

        // Distance LOD: fewer particles for far/small emitters (full detail within lodStart).
        long ecap = cap;
        if (lod != 0 && cap > 0) {
            double dist = distfromviewpoint(a, view);
            double f = 1.0;
            if (lodStart > 0 && dist > lodStart) { double r = lodStart / dist; f = r * r; }
            if (f < lodMin) f = lodMin;  if (f > 1.0) f = 1.0;
            ecap = (long)(cap * f);
        }

        // Prewarm: evaluate at T + prewarm so the cloud isn't empty at reset / T=0.
        float Te = T + (float)e->prewarm;
        int n = ecap > 0 ? ::evaluate(s, Te, scratch.data(), (int)ecap) : 0;
        e->statLiveCount = n;
        totalLive += n;
        // Sprite texture = the object's own image, read straight from imageindexobject (the
        // attribute the image picker sets). NOTE: do not use getobjectimageindex() -- it returns
        // imageindexBASE, which is a different slot. 0/unset -> fall back to the built-in soft dot.
        treenode imgNode = node(">visual/imageindexobject", a);
        int imgIdx = objectexists(imgNode) ? (int)getnodenum(imgNode) : 0;
        int tex = (s.style == RenderStyle::Sprite && imgIdx > 0) ? imgIdx : softDotTex;
        std::vector<Particle>& dst = spritesByTex[tex];
        for (int k = 0; k < n; ++k) {
            Particle p = scratch[k];
            p.position = localToWorld(p.position, wp, rd);
            dst.push_back(p);
        }
    }
    auto t1 = std::chrono::high_resolution_clock::now();
    statBuildMs = std::chrono::duration<double, std::milli>(t1 - t0).count();

    // Snapshot every GL flag we touch and restore it EXACTLY afterwards (forcing fixed values
    // leaked onto FlexSim's later translucent passes and whitened the selection orb).
    auto d0 = std::chrono::high_resolution_clock::now();
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
    // Billboard axes from the LIVE shader modelview (now == the view matrix V, since
    // M_entry*R(-90) maps world->eye): rows 0/1 are the camera right/up in world space. Must
    // come from fglInfo -- glGetFloatv returns identity under the shader pipeline, which froze
    // the billboards to a fixed world direction.
    float vm[16];
    readMat16(FGL_INFO_MODELVIEW_MATRIX, view, vm);
    pvec3 billRight = norm(pvec3{ vm[0], vm[4], vm[8] });
    pvec3 billUp    = norm(pvec3{ vm[1], vm[5], vm[9] });
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
