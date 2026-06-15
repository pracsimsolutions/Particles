// PracSim Particles — module DLL entry points.

#include "FlexsimDefs.h"
#include "allobjects.h"
#include "ParticleEmitter.h"
#include "ParticleSystem.h"
#include "ParticleEvaluator.h"
#include <vector>
#include <chrono>
#include <cstring>
#include <string>

visible void dllinitialize() {
}

namespace Particles {

// Object factory: dropping these in the model instantiates the C++ classes.
// Dropping a ParticleEmitter auto-creates the ParticleSystem (see onCreate).
visible ObjectDataType* createodtderivative(char* classname)
{
    if (strcmp(classname, "ParticleEmitter") == 0) return new ParticleEmitter;
    if (strcmp(classname, "ParticleSystem") == 0)  return new ParticleSystem;
    return nullptr;
}

// Emitter draw event, called directly as a DLL function from the object's OnDraw
// (dll:"module:Particles" func:"ParticleEmitter_OnDraw"). c = the emitter object,
// eventdatanode = the view. Draws the handle (region outline + aim arrow).
__declspec(dllexport) Variant ParticleEmitter_OnDraw(FLEXSIMINTERFACE)
{
    ParticleEmitter* e = c->objectAs(ParticleEmitter);
    if (e) e->onDraw(eventdatanode);
    return 0;
}

// Smoke-test export — confirms the DLL loads and FlexScript can reach it.
__declspec(dllexport) Variant Particles_ping(FLEXSIMINTERFACE)
{
    return 1;
}

// Set the per-emitter live-particle cap (graceful degradation for heavy scenes).
__declspec(dllexport) Variant Particles_setCap(FLEXSIMINTERFACE)
{
    if (ParticleSystem::instance)
        ParticleSystem::instance->liveCap = (double)param(1);
    return 1;
}

// Load a particle texture into FlexSim's media list and return its index.
// Args: param(1)=file path (relative to model/module), param(2)=a unique name.
// Assign the returned index to an emitter's textureIndex field + set style=Sprite.
__declspec(dllexport) Variant Particles_loadTexture(FLEXSIMINTERFACE)
{
    std::string file = param(1);
    std::string name = param(2);
    return loadimage(file.c_str(), name.c_str());
}

// Benchmark: run `numEmitters` evaluate() passes of `particlesEach` particles.
// Returns [totalParticles, elapsedMs] so the sim's draw-time cost can be measured.
__declspec(dllexport) Variant Particles_stressTest(FLEXSIMINTERFACE)
{
    int numE = (int)param(1);
    int each = (int)param(2);
    if (numE < 1) numE = 1;
    if (each < 1) each = 1;

    EmitterSpec s;
    s.rate = (float)each; s.lifetime = 1.0f; s.lifetimeJitter = 0.2f; s.swirlAmp = 0.1f;
    std::vector<Particle> buf(each + 16);

    auto t0 = std::chrono::high_resolution_clock::now();
    long total = 0;
    for (int e = 0; e < numE; ++e)
        total += evaluate(s, 5.0f, buf.data(), (int)buf.size());
    auto t1 = std::chrono::high_resolution_clock::now();

    Array out;
    out.push((double)total);
    out.push(std::chrono::duration<double, std::milli>(t1 - t0).count());
    return out;
}

}  // namespace Particles
