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
    bindVariable(drag);
    // gravity/wind are node-backed Vec3Property SDTs in the tree (read in buildSpec); not bound here.
    bindVariable(swirlAmp); bindVariable(swirlFreq);
    bindVariable(sizeStart); bindVariable(sizeEnd);
    // colorStart/colorEnd are structured rgba nodes in the tree (read in buildSpec); not bound here.
    bindVariable(styleField); bindVariable(textureIndex); bindVariable(seedField);
    bindVariable(statLiveCount);
}

void ParticleEmitter::bindInterface() {
    // Expose every field as a FlexScript property (emitter.rate, emitter.shapeField, ...).
    #define PE_BIND(n) bindTypedProperty(n, double, &ParticleEmitter::pget_##n, &ParticleEmitter::pset_##n)
    PE_BIND(rate); PE_BIND(lifetime); PE_BIND(lifetimeJitter); PE_BIND(startTime); PE_BIND(stopTimeField);
    PE_BIND(shapeField); PE_BIND(directionField); PE_BIND(coneHalfAngleDeg);
    PE_BIND(speed); PE_BIND(speedJitter);
    PE_BIND(drag);
    PE_BIND(swirlAmp); PE_BIND(swirlFreq);
    PE_BIND(sizeStart); PE_BIND(sizeEnd);
    PE_BIND(styleField); PE_BIND(textureIndex); PE_BIND(seedField);
    #undef PE_BIND
    bindTypedProperty(statLiveCount, double, &ParticleEmitter::pget_statLiveCount, nullptr);  // read-only
    // Node-backed wrappers: persistent component read+write (emitter.startColor.r = 0.5,
    // emitter.gravity.y = 5). The "&" in the typeName marks the property as an l-value
    // reference (so component writes are allowed); `false` keeps the helper type out of
    // the visible class list.
    bindClassByName<ColorProperty>("Particles.Color", false);
    bindTypedPropertyByName<ColorProperty>("startColor", "Particles.Color&",
        force_cast<void*>(&ParticleEmitter::__getStartColor), nullptr);
    bindTypedPropertyByName<ColorProperty>("endColor", "Particles.Color&",
        force_cast<void*>(&ParticleEmitter::__getEndColor), nullptr);
    bindClassByName<Vec3Property>("Particles.Vec3", false);
    bindTypedPropertyByName<Vec3Property>("gravity", "Particles.Vec3&",
        force_cast<void*>(&ParticleEmitter::__getGravity), nullptr);
    bindTypedPropertyByName<Vec3Property>("wind", "Particles.Vec3&",
        force_cast<void*>(&ParticleEmitter::__getWind), nullptr);
    // Enum namespaces (visible) so scripts use names, e.g. emitter.shapeField = Particles.Shape.Sphere.
    bindClassByName<Shape>("Particles.Shape", true);
    bindClassByName<Direction>("Particles.Direction", true);
    bindClassByName<Style>("Particles.Style", true);
    bindMethod(setColorStart, ParticleEmitter, "void setColorStart(double r, double g, double b, double a = 1)");
    bindMethod(setColorEnd, ParticleEmitter, "void setColorEnd(double r, double g, double b, double a = 1)");
}

// colorStart/colorEnd and gravity/wind are node-backed SDTs; read their live members.
static rgba readColor(ColorProperty* c) {
    return c ? rgba{ (float)c->r, (float)c->g, (float)c->b, (float)c->a } : rgba{ 1, 1, 1, 1 };
}
static pvec3 readVec3(Vec3Property* v, float dz) {
    return v ? pvec3{ (float)v->x, (float)v->y, (float)v->z } : pvec3{ 0, 0, dz };
}

void ParticleEmitter::setColorStart(double r, double g, double b, double a) {
    if (ColorProperty* c = __getStartColor()) { c->r = r; c->g = g; c->b = b; c->a = a; }
}
void ParticleEmitter::setColorEnd(double r, double g, double b, double a) {
    if (ColorProperty* c = __getEndColor()) { c->r = r; c->g = g; c->b = b; c->a = a; }
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
    s.gravity = readVec3(__getGravity(), -2.0f);
    s.drag = (float)drag; s.wind = readVec3(__getWind(), 0.0f);
    s.swirlAmp = (float)swirlAmp; s.swirlFreq = (float)swirlFreq;
    s.sizeStart = (float)sizeStart; s.sizeEnd = (float)sizeEnd;
    // colorStart/colorEnd are rgba (alpha folded in) -> the gradient carries alpha directly.
    s.colorStops.count = 2;
    s.colorStops.stops[0] = { 0.0f, readColor(__getStartColor()) };
    s.colorStops.stops[1] = { 1.0f, readColor(__getEndColor()) };
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
    drawColored(handleMesh, v, col, GL_LINES);   // line width is set by the caller
}

void ParticleEmitter::drawArrow(double arrowSize, const pvec3& base, const pvec3& rot, const float* col) {
    // Wireframe aim marker: a stem capped by a pyramid (local +Z is the aim direction).
    // Stem runs 0 -> stemTop; the pyramid base sits on the stem top and rises by pyrH.
    // Scaled by A (= system arrowSize). GL_LINES, no lighting.
    float A = (float)arrowSize;
    float stemTop = 0.5f * A;          // stem height / pyramid base height
    float pyrH    = 0.25f * A;         // pyramid height
    float apexZ   = stemTop + pyrH;    // apex
    float hw      = 0.125f * A;        // pyramid base half-width
    std::vector<float> v;
    auto L = [&](pvec3 a, pvec3 b) {
        pvec3 wa = localToWorld(a, base, rot), wb = localToWorld(b, base, rot);
        line(v, wa.x, wa.y, wa.z, wb.x, wb.y, wb.z);
    };
    // stem: one line from the center up to the pyramid base
    L(pvec3{0, 0, 0}, pvec3{0, 0, stemTop});
    // pyramid: base square on the stem top + four edges to the apex
    pvec3 ap{0, 0, apexZ};
    pvec3 p0{-hw,-hw,stemTop}, p1{hw,-hw,stemTop}, p2{hw,hw,stemTop}, p3{-hw,hw,stemTop};
    L(p0,p1); L(p1,p2); L(p2,p3); L(p3,p0);   // base square
    L(p0,ap); L(p1,ap); L(p2,ap); L(p3,ap);   // edges to apex
    drawColored(handleMesh, v, col, GL_LINES);
}

double ParticleEmitter::onDraw(treenode view)
{
    fglDisable(GL_LIGHTING);
    fglDisable(GL_TEXTURE_2D);

    // ---- selection state (AStar/Barrier pattern): hover = yellow, selected = red ----
    int pickingMode = getpickingmode(view);
    treenode selObj   = selectedobject(view);
    treenode hoverObj = tonode(getpickingdrawfocus(view, PICK_OBJECT, PICK_HOVERED));
    bool isSelected = (selObj == holder) || (switch_selected(holder, -1) != 0);
    bool isHovered  = (hoverObj == holder);

    const float blue[4]   = { 0.30f, 0.46f, 0.95f, 1.0f };   // idle handle (PracSim blue)
    const float yellow[4] = { 1.00f, 0.85f, 0.10f, 1.0f };   // hovered
    const float red[4]    = { 0.95f, 0.15f, 0.15f, 1.0f };   // selected
    const float* col = isSelected ? red : (isHovered ? yellow : blue);

    // Fat pick-line trick (from AStar): during the pick pass draw the wireframe ~3x
    // thicker so the thin lines are easy to click; emphasize a bit when hovered/selected.
    const float baseW = 2.0f;
    if (pickingMode)                   fglLineWidth(baseW * 3.0f);
    else if (isSelected || isHovered)  fglLineWidth(baseW * 1.5f);
    else                               fglLineWidth(baseW);

    // Route any click on our geometry to this emitter (whole object is one pick target).
    setpickingdrawfocus(view, holder, 0, 0, OVERRIDE_DRAW_ALL);

    // ============================ draw everything here ============================
    // The onDraw entry frame already carries this object's position + rotation + size
    // scale (verified against FlexSim's VisualTool: it divides by b_spatials at the top of
    // onDraw and never calls drawtoobjectscale or fglRotate(-90)). So geometry drawn here
    // scales with the object. Everything is centered on the object center (FlexSim box is
    // local x[0,1], y[-1,0], z[0,1] -> center (0.5,-0.5,0.5)) and is wireframe GL_LINES.
    ParticleSystem* sys = ParticleSystem::getInstance();
    bool showPlanes = !sys || sys->showPlanes != 0;
    bool showArrows = !sys || sys->showArrows != 0;
    double arrowLen = sys ? sys->arrowSize : 1.0;     // constant WORLD length of the arrow
    EmitShape shape = (EmitShape)(int)shapeField;
    // The aim pyramid only means something for DIRECTIONAL emission: show it when Aimed,
    // but never for a Sphere (it is inherently radial/omni -- an aim direction is meaningless).
    bool aimed = (DirectionMode)(int)directionField == DirectionMode::Aimed
                 && shape != EmitShape::Sphere;
    const float cx = 0.5f, cy = -0.5f, cz = 0.5f;     // object center

    Vec3 sz = size;
    float sx  = (float)std::max(1e-4, std::fabs(sz.x));
    float sy  = (float)std::max(1e-4, std::fabs(sz.y));
    float szz = (float)std::max(1e-4, std::fabs(sz.z));

    // The DLL OnDraw frame is FlexSim's draw convention -- rotated +90deg about X from the
    // model's Z-up (the same convention Barrier handles). fglRotate(-90,1,0,0) FIRST cancels
    // it, so afterwards we are in plain model-aligned, object-scaled coordinates: the object
    // footprint is x[0,1], y[-1,0], z[0,1] (center 0.5,-0.5,0.5), +Z is up, XY is horizontal.

    // region outline -- the emission area; scales with the object (intentional).
    if (showPlanes && shape != EmitShape::Point) {
        fglPushMatrix();
        fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);        // -> model-aligned
        fglTranslate(cx, cy, cz);                   // object center
        drawRegionOutline(shape, col);
        fglPopMatrix();
    }

    // aim pyramid -- CONSTANT world size (undo the object scale with fglScale(1/S) so resizing
    // never deforms it). Placed at the object BASE (z=0 footprint center); +Z is up in the
    // model-aligned frame, so the pyramid (apex along +Z) points up with no further rotation.
    if (showArrows && aimed) {
        fglPushMatrix();
        fglRotate(-90.0f, 1.0f, 0.0f, 0.0f);        // -> model-aligned
        fglTranslate(cx, cy, cz);                   // object center (pyramid base sits here)
        fglScale(1.0f / sx, 1.0f / sy, 1.0f / szz); // -> constant world size
        drawArrow(arrowLen, pvec3{ 0, 0, 0 }, pvec3{ 0, 0, 0 }, col);
        fglPopMatrix();
    }
    // =============================================================================
    setManipulationHandleDraw(DRAW_ORB | DRAW_SIZER_ALL | DRAW_ALL_AXIS_SIZER | DRAW_MOVE_X | DRAW_MOVE_Y | DRAW_MOVE_Z | DRAW_ROTATOR_Z);
    fglEnable(GL_LIGHTING);
    fglEnable(GL_TEXTURE_2D);
    fglLineWidth(1.0f);
    return 0;
}

}  // namespace Particles
