#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "Mesh.h"
#include "ParticleEmitter.h"
#include "ParticleEvaluator.h"
#include <vector>
#include <map>

namespace Particles {

// Singleton manager that draws every ParticleEmitter in one batched pass: a
// single GL_POINTS draw for all point-style emitters plus one GL_TRIANGLES draw
// per sprite texture. Emitters are discovered by scanning the model (no per-
// emitter registration needed), so an emitter can be a pure data ObjectDataType.
// The system object itself is never selectable, and particles are never drawn
// during the pick pass.
class ParticleSystem : public FlexSimEventHandler
{
public:
    ParticleSystem() {}
    ~ParticleSystem();
    static ParticleSystem* instance;
    static ParticleSystem* getInstance() { return instance; }

    virtual void   bindVariables() override;
    virtual void   bindInterface() override;   // FlexScript API + the Particles.system accessor
    virtual double onCreate(double dropx, double dropy, double dropz, int iscopy) override;
    virtual double onReset() override;
    virtual double onDraw(treenode view) override;

    // FlexScript method (bound vars cover the properties; e.g. Particles.system.liveCap).
    double setCap(double maxLivePerEmitter) { liveCap = maxLivePerEmitter; return 1; }

    // Static FlexScript namespace: exposes the global accessor `Particles.system`.
    class Statics {
    public:
        static void bindInterface();
        static ParticleSystem* getSystem() { return ParticleSystem::instance; }
    };

    // System-wide controls (bound, GUI-editable). Defaults must match Particles.fsx.
    double pointSize = 5;        // uniform size for the batched points draw
    double liveCap = 200000;     // max live particles per emitter
    // Handle visibility (always-on by default) + arrow world size.
    double showPlanes = 1;       // draw emitter region outlines
    double showArrows = 1;       // draw emitter aim arrows
    double arrowSize = 1;        // world-unit length of the aim arrow

    // Aggregate stats (bound, read-only)
    double statEmitterCount = 0, statTotalLive = 0, statBuildMs = 0, statDrawMs = 0;

private:
    Mesh pointsMesh;
    std::map<int, Mesh> spriteMeshes;            // one mesh per texture index
    std::vector<Particle> scratch;               // per-emitter evaluation buffer

    void drawPointsBatch(const std::vector<Particle>& pts);
    void drawSpriteBatch(int texIndex, const std::vector<Particle>& sprites);
};

}  // namespace Particles
