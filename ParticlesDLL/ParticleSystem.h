#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "Mesh.h"
#include "ParticleEmitter.h"
#include "ParticleEvaluator.h"
#include <vector>
#include <map>

namespace Particles {

// Singleton system that owns all ParticleEmitters and draws them in one batched
// pass: a single GL_POINTS draw for every point-style emitter, plus one
// GL_TRIANGLES draw per distinct sprite texture. This keeps the per-frame draw
// cost a handful of calls regardless of how many emitters exist.
class ParticleSystem : public FlexSimEventHandler
{
public:
    ParticleSystem() {}
    ~ParticleSystem();
    static ParticleSystem* instance;
    static ParticleSystem* getInstance() { return instance; }

    virtual void   bindVariables() override;
    virtual double onCreate(double dropx, double dropy, double dropz, int iscopy) override;
    virtual double onReset() override;
    virtual double onDraw(treenode view) override;

    typedef NodeListArray<ParticleEmitter, nullptr, nullptr, OneBased::rankOffset>::ObjStoredAttCouplingType EmitterArray;
    EmitterArray emitterMembers;
    TreeNode* emitters = nullptr;
    EmitterArray& getEmitters() { return emitterMembers; }

    // System-wide controls (bound, GUI-editable). Defaults must match the
    // <variables> block in Particles.fsx (FlexSim uses the stored value).
    double pointSize = 5;        // uniform size for the batched points draw
    double liveCap = 200000;     // max live particles per emitter

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
