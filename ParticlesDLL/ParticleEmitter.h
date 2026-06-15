#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "EmitterSpec.h"

namespace Particles {

// A lightweight, placeable emitter. Inherits ObjectDataType directly (like the
// FlexSim Light object) so it carries NONE of the FlexSimObject item-flow
// variables -- just its own clean variable list. It holds only the declarative
// spec and does not draw; the ParticleSystem reads every emitter and batch-draws
// them. The system is created on drag via this object's OnCreate tree trigger
// in Particles.fsx (ObjectDataType objects don't auto-dispatch onCreate).
class ParticleEmitter : public ObjectDataType
{
public:
    virtual void bindVariables() override;

    // --- Config fields (bound -> persist + GUI-editable). Defaults must match
    //     the <variables> block in Particles.fsx (FlexSim uses the stored value). ---
    double rate = 200, lifetime = 2, lifetimeJitter = 0.4;
    double startTime = 0, stopTimeField = 0;          // stopTimeField<=0 means "never"
    double shapeField = (double)EmitShape::Cone;       // 0=Point,1=Cone,2=Sphere,3=Disk,4=Line
    double coneHalfAngleDeg = 25, shapeSize = 0;
    double speed = 2, speedJitter = 0.5;
    double gravX = 0, gravY = 0, gravZ = -2;
    double drag = 0, windX = 0, windY = 0, windZ = 0;
    double swirlAmp = 0, swirlFreq = 1;
    double sizeStart = 0.2, sizeEnd = 0.05, alphaStart = 1, alphaEnd = 0;
    double colorStartR = 1, colorStartG = 1, colorStartB = 1;
    double colorEndR = 1, colorEndG = 1, colorEndB = 1;
    double styleField = (double)RenderStyle::Points;   // 0=Points, 1=Sprite
    double textureIndex = 0;                            // sprite texture (0 = untextured)
    double seedField = 12345;

    // Live stat (written by the system each draw; bound so the GUI can read it)
    double statLiveCount = 0;

    EmitterSpec buildSpec() const;                     // marshal fields -> spec
};

}  // namespace Particles
