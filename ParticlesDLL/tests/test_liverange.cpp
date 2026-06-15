#include "test_framework.h"
#include "../ParticleEvaluator.h"

TEST(liverange_continuous) {
    EmitterSpec s;
    s.mode = EmitMode::Continuous;
    s.rate = 10.0f; s.startTime = 0.0f; s.lifetime = 2.0f; s.lifetimeJitter = 0.0f;
    // computeLiveRange returns a CONSERVATIVE candidate range (it must, because
    // per-particle lifetime jitter makes the exact alive-set particle-dependent).
    // At T=5 the candidate range is [ceil((5-2)*10), floor(5*10)] = [30, 50].
    // Particle 30 (born t=3.0, age=2.0) is a candidate but evaluate() culls it
    // since age is not < lifetime; the exact alive-set is [31..50] (= 20, proven
    // by evaluate_fills_live_particles).
    LiveRange r = computeLiveRange(s, 5.0f);
    CHECK(r.iMin == 30); CHECK(r.iMax == 50);
}

TEST(liverange_before_start_is_empty) {
    EmitterSpec s; s.rate = 10; s.startTime = 4; s.lifetime = 2; s.lifetimeJitter = 0;
    LiveRange r = computeLiveRange(s, 1.0f);
    CHECK(r.iMax < r.iMin);   // empty
}

TEST(liverange_respects_stoptime) {
    EmitterSpec s; s.rate = 10; s.startTime = 0; s.stopTime = 3; s.lifetime = 100; s.lifetimeJitter = 0;
    // emission stops at T=3 -> last index = floor(3*10)=30, regardless of large T.
    LiveRange r = computeLiveRange(s, 50.0f);
    CHECK(r.iMax == 30);
}
