#include "ParticleEmitter.h"
#include "ParticleSystem.h"
#include "pmath.h"
#include <algorithm>
#include <vector>
#include <cmath>

namespace Particles {

void ParticleEmitter::bindVariables() {
    bindVariable(rate); bindVariable(lifetime); bindVariable(lifetimeJitter);
    bindVariable(startTime); bindVariable(stopTimeField);
    bindVariable(shapeField); bindVariable(directionField); bindVariable(coneHalfAngleDeg);
    bindVariable(speed); bindVariable(speedJitter);
    bindVariable(gravX); bindVariable(gravY); bindVariable(gravZ);
    bindVariable(drag); bindVariable(windX); bindVariable(windY); bindVariable(windZ);
    bindVariable(swirlAmp); bindVariable(swirlFreq);
    bindVariable(sizeStart); bindVariable(sizeEnd); bindVariable(alphaStart); bindVariable(alphaEnd);
    bindVariable(colorStartR); bindVariable(colorStartG); bindVariable(colorStartB);
    bindVariable(colorEndR); bindVariable(colorEndG); bindVariable(colorEndB);
    bindVariable(styleField); bindVariable(textureIndex); bindVariable(seedField);
    bindVariable(statLiveCount);
}

void ParticleEmitter::bindInterface() {
    //bindParentClass("Object");   // REQUIRED before bindTypedProperty, or the whole
                                 // interface fails to register (no props or methods show).
    // Expose every field as a FlexScript property (emitter.rate, emitter.shapeField, ...).
    #define PE_BIND(n) bindTypedProperty(n, double, &ParticleEmitter::pget_##n, &ParticleEmitter::pset_##n)
    PE_BIND(rate); PE_BIND(lifetime); PE_BIND(lifetimeJitter); PE_BIND(startTime); PE_BIND(stopTimeField);
    PE_BIND(shapeField); PE_BIND(directionField); PE_BIND(coneHalfAngleDeg);
    PE_BIND(speed); PE_BIND(speedJitter);
    PE_BIND(gravX); PE_BIND(gravY); PE_BIND(gravZ);
    PE_BIND(drag); PE_BIND(windX); PE_BIND(windY); PE_BIND(windZ);
    PE_BIND(swirlAmp); PE_BIND(swirlFreq);
    PE_BIND(sizeStart); PE_BIND(sizeEnd); PE_BIND(alphaStart); PE_BIND(alphaEnd);
    PE_BIND(colorStartR); PE_BIND(colorStartG); PE_BIND(colorStartB);
    PE_BIND(colorEndR); PE_BIND(colorEndG); PE_BIND(colorEndB);
    PE_BIND(styleField); PE_BIND(textureIndex); PE_BIND(seedField);
    #undef PE_BIND
    bindTypedProperty(statLiveCount, double, &ParticleEmitter::pget_statLiveCount, nullptr);  // read-only
    bindMethod(setColorStart, ParticleEmitter, "void setColorStart(double r, double g, double b)");
    bindMethod(setColorEnd, ParticleEmitter, "void setColorEnd(double r, double g, double b)");
}

EmitterSpec ParticleEmitter::buildSpec() {
    EmitterSpec s;
    s.rate = (float)std::max(1e-4, rate);
    s.lifetime = (float)lifetime; s.lifetimeJitter = (float)lifetimeJitter;
    s.startTime = (float)startTime;
    s.stopTime = stopTimeField > 0 ? (float)stopTimeField : 1e30f;
    s.shape = (EmitShape)(int)shapeField;
    s.direction = (DirectionMode)(int)directionField;
    s.coneHalfAngleDeg = (float)coneHalfAngleDeg;
    // Region = the object's size (resize handles drive the emission area).
    Vec3 sz = size;
    s.regionX = (float)sz.x; s.regionY = (float)sz.y; s.regionZ = (float)sz.z;
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
    s.seed = (uint32_t)seedField;
    return s;
}

// ---- handle geometry helpers (positions are filled into flat float arrays) ----
static void line(std::vector<float>& v, float ax,float ay,float az, float bx,float by,float bz) {
    v.push_back(ax); v.push_back(ay); v.push_back(az);
    v.push_back(bx); v.push_back(by); v.push_back(bz);
}
static void tri(std::vector<float>& v, pvec3 a, pvec3 b, pvec3 c) {
    v.push_back(a.x); v.push_back(a.y); v.push_back(a.z);
    v.push_back(b.x); v.push_back(b.y); v.push_back(b.z);
    v.push_back(c.x); v.push_back(c.y); v.push_back(c.z);
}
static void circle(std::vector<float>& v, int axis, float r) {
    // axis 0=XY (z=0), 1=XZ (y=0), 2=YZ (x=0)
    const int N = 28;
    for (int i = 0; i < N; ++i) {
        float a = i / (float)N * 6.2831853f, b = (i + 1) / (float)N * 6.2831853f;
        float ca=std::cos(a)*r, sa=std::sin(a)*r, cb=std::cos(b)*r, sb=std::sin(b)*r;
        if (axis == 0) line(v, ca,sa,0, cb,sb,0);
        else if (axis == 1) line(v, ca,0,sa, cb,0,sb);
        else line(v, 0,ca,sa, 0,cb,sb);
    }
}

// Draw positions with an explicit per-vertex color (self-contained: doesn't depend
// on leftover GL color/material state, so it never picks up another object's color).
static void drawColored(Mesh& m, const std::vector<float>& pos, const float* col, int mode) {
    int n = (int)pos.size() / 3;
    if (n <= 0) return;
    std::vector<float> cols((size_t)n * 4);
    for (int k = 0; k < n; ++k) { cols[k*4]=col[0]; cols[k*4+1]=col[1]; cols[k*4+2]=col[2]; cols[k*4+3]=col[3]; }
    m.init(n, MESH_POSITION | MESH_AMBIENT_AND_DIFFUSE4, MESH_DYNAMIC_DRAW);
    m.defineVertexAttribs(MESH_POSITION, (float*)pos.data());
    m.defineVertexAttribs(MESH_AMBIENT_AND_DIFFUSE4, cols.data());
    m.draw(mode);
}

void ParticleEmitter::drawRegionOutline(EmitShape shape, const float* col) {
    std::vector<float> v;
    const float h = 0.5f;  // unit region (object scale makes it the real size)
    switch (shape) {
        case EmitShape::Point:
            line(v,-0.12f,0,0, 0.12f,0,0); line(v,0,-0.12f,0, 0,0.12f,0); line(v,0,0,-0.12f, 0,0,0.12f); break;
        case EmitShape::Line:
            line(v,-h,0,0, h,0,0); break;
        case EmitShape::Disk:
            circle(v, 0, h); break;
        case EmitShape::Plane:
            line(v,-h,-h,0, h,-h,0); line(v,h,-h,0, h,h,0); line(v,h,h,0, -h,h,0); line(v,-h,h,0, -h,-h,0); break;
        case EmitShape::Box: {
            float c[8][3]={{-h,-h,-h},{h,-h,-h},{h,h,-h},{-h,h,-h},{-h,-h,h},{h,-h,h},{h,h,h},{-h,h,h}};
            int e[12][2]={{0,1},{1,2},{2,3},{3,0},{4,5},{5,6},{6,7},{7,4},{0,4},{1,5},{2,6},{3,7}};
            for (auto& ed : e) line(v, c[ed[0]][0],c[ed[0]][1],c[ed[0]][2], c[ed[1]][0],c[ed[1]][1],c[ed[1]][2]);
            break; }
        case EmitShape::Sphere:
            circle(v,0,h); circle(v,1,h); circle(v,2,h); break;
    }
    glLineWidth(1.6f);
    drawColored(handleMesh, v, col, GL_LINES);
    glLineWidth(1.0f);
}

void ParticleEmitter::drawArrow(double arrowSize, const Vec3& objSize, const float* col) {
    // Drawn in object scale; divide the world arrowSize by the object size so it stays
    // roughly a constant world size as the emitter is resized. Per-face normals so it
    // shades under the scene lighting (caller leaves lighting on).
    float ox = (float)std::max(1e-3, std::fabs(objSize.x));
    float oy = (float)std::max(1e-3, std::fabs(objSize.y));
    float oz = (float)std::max(1e-3, std::fabs(objSize.z));
    float A = (float)arrowSize;
    float shaftH = 0.62f*A/oz, tipH = 0.42f*A/oz;
    float hwx = 0.05f*A/ox, hwy = 0.05f*A/oy, twx = 0.12f*A/ox, twy = 0.12f*A/oy;
    std::vector<float> pos, nrm;
    auto addTri = [&](pvec3 a, pvec3 b, pvec3 c) {
        pvec3 e1{b.x-a.x, b.y-a.y, b.z-a.z}, e2{c.x-a.x, c.y-a.y, c.z-a.z};
        pvec3 nn{ e1.y*e2.z-e1.z*e2.y, e1.z*e2.x-e1.x*e2.z, e1.x*e2.y-e1.y*e2.x };
        float l = std::sqrt(nn.x*nn.x+nn.y*nn.y+nn.z*nn.z); if (l>1e-6f){nn.x/=l;nn.y/=l;nn.z/=l;}
        pvec3 ps[3]={a,b,c};
        for (auto& p : ps) { pos.push_back(p.x);pos.push_back(p.y);pos.push_back(p.z);
                             nrm.push_back(nn.x);nrm.push_back(nn.y);nrm.push_back(nn.z); }
    };
    pvec3 c8[8] = {{-hwx,-hwy,0},{hwx,-hwy,0},{hwx,hwy,0},{-hwx,hwy,0},{-hwx,-hwy,shaftH},{hwx,-hwy,shaftH},{hwx,hwy,shaftH},{-hwx,hwy,shaftH}};
    int f[12][3]={{0,1,2},{0,2,3},{4,6,5},{4,7,6},{0,4,5},{0,5,1},{1,5,6},{1,6,2},{2,6,7},{2,7,3},{3,7,4},{3,4,0}};
    for (auto& t : f) addTri(c8[t[0]], c8[t[1]], c8[t[2]]);
    pvec3 ap{0,0,shaftH+tipH}, p0{-twx,-twy,shaftH}, p1{twx,-twy,shaftH}, p2{twx,twy,shaftH}, p3{-twx,twy,shaftH};
    addTri(p0,p1,ap); addTri(p1,p2,ap); addTri(p2,p3,ap); addTri(p3,p0,ap);
    addTri(p0,p2,p1); addTri(p0,p3,p2);

    int n = (int)pos.size() / 3;
    std::vector<float> cols((size_t)n * 4);
    for (int k = 0; k < n; ++k) { cols[k*4]=col[0]; cols[k*4+1]=col[1]; cols[k*4+2]=col[2]; cols[k*4+3]=col[3]; }
    handleMesh.init(n, MESH_POSITION | MESH_NORMAL | MESH_AMBIENT_AND_DIFFUSE4, MESH_DYNAMIC_DRAW);
    handleMesh.defineVertexAttribs(MESH_POSITION, pos.data());
    handleMesh.defineVertexAttribs(MESH_NORMAL, nrm.data());
    handleMesh.defineVertexAttribs(MESH_AMBIENT_AND_DIFFUSE4, cols.data());
    handleMesh.draw(GL_TRIANGLES);
}

double ParticleEmitter::onDraw(treenode view) {
    // Keep resize/move/rotate handles; drop the port connectors an emitter never uses.
    setManipulationHandleDraw(DRAW_SIZER_ALL | DRAW_MOVE_AXIS_ALL | DRAW_MOVE_XY
                              | DRAW_ROTATOR_ALL | DRAW_ORB);
    // No 3D shape -> hide FlexSim's placeholder body box (our handle is the visual).
    switch_hideshape(holder, 1);

    ParticleSystem* sys = ParticleSystem::getInstance();
    bool showPlanes = !sys || sys->showPlanes != 0;
    bool showArrows = !sys || sys->showArrows != 0;
    double arrowSize = sys ? sys->arrowSize : 1.0;
    EmitShape shape = (EmitShape)(int)shapeField;
    bool aimed = (DirectionMode)(int)directionField == DirectionMode::Aimed;
    float col[4] = { 0.30f, 0.46f, 0.95f, 1.0f };

    // The emitter draws its own handle -- region outline (the shape/area) + the aim
    // arrow -- so the geometry is the object's own pickable surface (click it to select).
    fglEnable(GL_BLEND);
    fglPushMatrix();
    drawtoobjectscale(holder);
    fglTranslate(0.5f, 0.5f, 0.0f);           // object base center (z=0)
    fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);      // align local +Z with model up

    if (showPlanes && shape != EmitShape::Point) {
        fglDisable(GL_LIGHTING);
        drawRegionOutline(shape, col);
    }
    if (showArrows && aimed) {
        fglEnable(GL_LIGHTING);
        Vec3 sz = size;
        drawArrow(arrowSize, sz, col);
    }
    fglPopMatrix();

    // restore default GL state so the next object isn't affected
    fglDisable(GL_BLEND);
    fglEnable(GL_LIGHTING);
    fglColor(1.0f, 1.0f, 1.0f, 1.0f);
    glLineWidth(1.0f);
    return 0;
}

}  // namespace Particles
