#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "EmitterSpec.h"

namespace Particles {

// A lightweight, placeable particle-emitter handle. Holds the emitter's
// declarative spec; it does NOT draw. All drawing is done in one batched pass
// by the ParticleSystem this emitter registers with on create.
class ParticleEmitter : public FlexSimObject
{
public:
    ParticleEmitter() {}

    virtual double onCreate(double dropx, double dropy, double dropz, int iscopy) override;
    virtual double onReset() override;
    virtual double onDestroy(treenode view) override;
    virtual void   bindVariables() override;

    treenode system = nullptr;   // coupling back to the owning ParticleSystem

    // --- Config fields (bound -> persist with the model, GUI-editable) ---
    // NOTE: these initializers are the source-of-truth defaults, but FlexSim
    // takes the value stored in Particles.fsx when an object is instantiated.
    // Keep the two in sync (see the <variables> block in Particles.fsx).
    double rate = 200, lifetime = 2, lifetimeJitter = 0.4;
    double startTime = 0, stopTimeField = 0;          // stopTimeField<=0 means "never"
    double shapeField = (double)EmitShape::Cone;
    double coneHalfAngleDeg = 25, shapeSize = 0;
    double speed = 2, speedJitter = 0.5;
    double gravX = 0, gravY = 0, gravZ = -2;
    double drag = 0, windX = 0, windY = 0, windZ = 0;
    double swirlAmp = 0, swirlFreq = 1;
    double sizeStart = 0.2, sizeEnd = 0.05, alphaStart = 1, alphaEnd = 0;
    double colorStartR = 1, colorStartG = 1, colorStartB = 1;
    double colorEndR = 1, colorEndG = 1, colorEndB = 1;
    double styleField = (double)RenderStyle::Points;   // 0=Points, 1=Sprite
    double textureIndex = 0;                            // sprite texture (0 = untextured quad)
    double seedField = 12345;

    // Live stat (written by the system each draw; bound so the GUI can read it)
    double statLiveCount = 0;

    EmitterSpec buildSpec() const;                     // marshal fields -> spec
};

}  // namespace Particles
