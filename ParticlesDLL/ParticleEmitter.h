#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "Mesh.h"
#include "EmitterSpec.h"
#include "PropertyTypes.h"

namespace Particles {

// A lightweight, placeable emitter (ObjectDataType, like the FlexSim Light).
// Holds the declarative spec; the ParticleSystem reads every emitter and
// batch-draws the particles. This object draws ONLY its handle (the emission
// region outline + aim arrow) so it stays selectable/draggable/resizable; the
// object's size (resize handles) drives the emission area. onDraw is wired via
// an OnDraw tree trigger in Particles.fsx.
class ParticleEmitter : public ObjectDataType
{
public:
    virtual void bindVariables() override;
    virtual void bindInterface() override;   // FlexScript API (all fields are also
                                             // reachable as bound variables, e.g. emitter.rate)
    double onDraw(treenode view);

    // colorStart/colorEnd are node-backed ColorProperty SDTs (children r,g,b,a). These
    // getters return the wrapper from the tree node so FlexScript sees a "Particles.Color"
    // with a persistent address -> emitter.startColor.r = 0.5 writes through to the node.
    ColorProperty* __getStartColor() {
        treenode n = getvarnode(holder, "colorStart");
        return objectexists(n) ? n->objectAs(ColorProperty) : nullptr;
    }
    ColorProperty* __getEndColor() {
        treenode n = getvarnode(holder, "colorEnd");
        return objectexists(n) ? n->objectAs(ColorProperty) : nullptr;
    }
    // gravity/wind are node-backed Vec3Property SDTs (children x,y,z) -> emitter.gravity.y = 5
    // writes through to the node, and emitter.gravity / .wind read+assign as Vec3.
    Vec3Property* __getGravity() {
        treenode n = getvarnode(holder, "gravity");
        return objectexists(n) ? n->objectAs(Vec3Property) : nullptr;
    }
    Vec3Property* __getWind() {
        treenode n = getvarnode(holder, "wind");
        return objectexists(n) ? n->objectAs(Vec3Property) : nullptr;
    }

    // FlexScript convenience methods (write all channels at once). Defined in the .cpp.
    void setColorStart(double r, double g, double b, double a = 1.0);
    void setColorEnd(double r, double g, double b, double a = 1.0);

    // --- Config fields (bound -> persist + GUI-editable). Match Particles.fsx. ---
    // colorStart/colorEnd are NOT here: they live in the tree as structured rgba nodes and
    // are read at draw time in buildSpec (see readColorNode). Alpha is the node's 'a' channel.
    double rate = 200, lifetime = 2, lifetimeJitter = 0.4;
    double startTime = 0, stopTimeField = 0;
    double shapeField = (double)EmitShape::Plane;        // 0=Point 1=Line 2=Disk 3=Plane 4=Box 5=Sphere
    double directionField = (double)DirectionMode::Aimed; // 0=Aimed 1=Omni
    double coneHalfAngleDeg = 25;                         // spread
    double speed = 2, speedJitter = 0.5;
    double drag = 0;
    double swirlAmp = 0, swirlFreq = 1;
    double sizeStart = 0.2, sizeEnd = 0.05;
    double styleField = (double)RenderStyle::Points;
    double textureIndex = 0;
    double seedField = 12345;
    double statLiveCount = 0;

    // gravity/wind live in the tree as node-backed Vec3Property SDTs (see __getGravity /
    // __getWind and Particles.fsx) -- not plain members -- so component writes persist.

    // FlexScript property accessors: one get/set per field so emitter.<name>
    // works (bound variables alone are not exposed as object properties).
    #define PE_ACC(n) double pget_##n() { return n; } void pset_##n(double v) { n = v; }
    PE_ACC(rate) PE_ACC(lifetime) PE_ACC(lifetimeJitter) PE_ACC(startTime) PE_ACC(stopTimeField)
    PE_ACC(shapeField) PE_ACC(directionField) PE_ACC(coneHalfAngleDeg)
    PE_ACC(speed) PE_ACC(speedJitter)
    PE_ACC(drag)
    PE_ACC(swirlAmp) PE_ACC(swirlFreq)
    PE_ACC(sizeStart) PE_ACC(sizeEnd)
    PE_ACC(styleField) PE_ACC(textureIndex) PE_ACC(seedField)
    double pget_statLiveCount() { return statLiveCount; }
    #undef PE_ACC

    EmitterSpec buildSpec();        // reads object size -> region; not const

    Mesh handleMesh;
    void drawRegionOutline(EmitShape shape, const float* col);
    // Arrow is built in WORLD coords at constant world size (no object scale) so it
    // never deforms/explodes when the emitter is resized. base/rot are the emitter's
    // base-center world position and Euler rotation; draw under an fglRotate(-90) bracket.
    void drawArrow(double arrowSize, const pvec3& base, const pvec3& rot, const float* col);
};

}  // namespace Particles
