#pragma once

namespace Particles {

// Process-wide particle settings/counters. For v1 the cap is enforced
// per-emitter (each emitter limits its own live output to liveCap); see README.
struct GlobalParticleStats {
    long liveCap = 200000;     // max live particles per emitter
    static GlobalParticleStats& get() { static GlobalParticleStats g; return g; }
};

}  // namespace Particles
