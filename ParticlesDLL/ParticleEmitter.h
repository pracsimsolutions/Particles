#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "Mesh.h"
#include "EmitterSpec.h"

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

    // FlexScript convenience methods.
    void setColorStart(double r, double g, double b) { colorStartR = r; colorStartG = g; colorStartB = b; }
    void setColorEnd(double r, double g, double b)   { colorEndR = r;   colorEndG = g;   colorEndB = b; }

    // --- Config fields (bound -> persist + GUI-editable). Match Particles.fsx. ---
    double rate = 200, lifetime = 2, lifetimeJitter = 0.4;
    double startTime = 0, stopTimeField = 0;
    double shapeField = (double)EmitShape::Plane;        // 0=Point 1=Line 2=Disk 3=Plane 4=Box 5=Sphere
    double directionField = (double)DirectionMode::Aimed; // 0=Aimed 1=Omni
    double coneHalfAngleDeg = 25;                         // spread
    double speed = 2, speedJitter = 0.5;
    double gravX = 0, gravY = 0, gravZ = -2;
    double drag = 0, windX = 0, windY = 0, windZ = 0;
    double swirlAmp = 0, swirlFreq = 1;
    double sizeStart = 0.2, sizeEnd = 0.05, alphaStart = 1, alphaEnd = 0;
    double colorStartR = 1, colorStartG = 1, colorStartB = 1;
    double colorEndR = 1, colorEndG = 1, colorEndB = 1;
    double styleField = (double)RenderStyle::Points;
    double textureIndex = 0;
    double seedField = 12345;
    double statLiveCount = 0;

    EmitterSpec buildSpec();        // reads object size -> region; not const

private:
    Mesh handleMesh;
    void drawRegionOutline(EmitShape shape, const float* col);
    void drawArrow(double arrowSize, const Vec3& objSize, const float* col);
};

}  // namespace Particles
