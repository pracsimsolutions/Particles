#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "Mesh.h"
#include "EmitterSpec.h"
#include "ParticleEvaluator.h"
#include <vector>

namespace Particles {

// A standalone FlexSim 3D object that emits particles purely at draw time,
// as an analytic function of model time. Adds zero events to the sim queue.
class ParticleEmitter : public FlexSimEventHandler
{
public:
    ParticleEmitter() {}

    virtual double onCreate(double dropx, double dropy, double dropz, int iscopy) override;
    virtual double onReset() override;
    virtual double onDraw(treenode view) override;
    virtual void   bindVariables() override;

    // --- Config fields (bound -> persist with the model, GUI-editable) ---
    double rate = 50, lifetime = 2, lifetimeJitter = 0.3;
    double startTime = 0, stopTimeField = 0;          // stopTimeField<=0 means "never"
    double shapeField = (double)EmitShape::Cone;
    double coneHalfAngleDeg = 20, shapeSize = 0;
    double speed = 1, speedJitter = 0.2;
    double gravX = 0, gravY = 0, gravZ = -1;
    double drag = 0, windX = 0, windY = 0, windZ = 0;
    double swirlAmp = 0, swirlFreq = 1;
    double sizeStart = 0.1, sizeEnd = 0.1, alphaStart = 1, alphaEnd = 0;
    double colorStartR = 1, colorStartG = 1, colorStartB = 1;
    double colorEndR = 1, colorEndG = 1, colorEndB = 1;
    double styleField = (double)RenderStyle::Points;
    double pointSize = 3, luminous = 1, seedField = 12345;
    double textureIndex = 0;                           // 0 = untextured

    // --- Live stats (bound so the GUI can read them; updated each draw) ---
    double statLiveCount = 0, statBuildMs = 0, statDrawMs = 0;

    EmitterSpec buildSpec() const;                     // marshal fields -> spec

private:
    Mesh mesh;
    std::vector<Particle> scratch;

    void drawPoints(int n, const EmitterSpec& s);
    void drawSprites(treenode view, int n, const EmitterSpec& s);
};

}  // namespace Particles
