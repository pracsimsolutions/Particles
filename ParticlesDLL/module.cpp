// PracSim Particles — module DLL entry points.

#include "FlexsimDefs.h"
#include "allobjects.h"
#include "ParticleEmitter.h"
#include "ParticleEvaluator.h"
#include "Instrumentation.h"
#include <vector>
#include <chrono>
#include <cstring>

visible void dllinitialize() {
}

namespace Particles {

// Object factory: dropping a "ParticleEmitter" in the model instantiates this.
visible ObjectDataType* createodtderivative(char* classname)
{
    if (strcmp(classname, "ParticleEmitter") == 0) return new ParticleEmitter;
    return nullptr;
}

// Smoke-test export — confirms the DLL loads and FlexScript can reach it.
__declspec(dllexport) Variant Particles_ping(FLEXSIMINTERFACE)
{
    return 1;
}

// Set the per-emitter live-particle cap (graceful degradation for heavy scenes).
__declspec(dllexport) Variant Particles_setCap(FLEXSIMINTERFACE)
{
    GlobalParticleStats::get().liveCap = (long)param(1);
    return 1;
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
