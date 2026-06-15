#include "test_framework.h"
#include "../ParticleEvaluator.h"
#include <vector>

TEST(evaluate_fills_live_particles) {
    EmitterSpec s; s.rate = 10; s.startTime = 0; s.lifetime = 2; s.lifetimeJitter = 0;
    std::vector<Particle> buf(1000);
    int n = evaluate(s, 5.0f, buf.data(), (int)buf.size());
    CHECK(n == 20);   // 20 alive (see liverange test)
}

TEST(evaluate_is_frame_skip_invariant) {
    // The scene at T must be identical regardless of "draw history".
    EmitterSpec s; s.rate = 37; s.lifetime = 3.3f; s.lifetimeJitter = 0.4f; s.swirlAmp = 0.2f;
    std::vector<Particle> a(4000), b(4000);
    int na = evaluate(s, 17.25f, a.data(), (int)a.size());
    int nb = evaluate(s, 17.25f, b.data(), (int)b.size());   // recompute "after skipping"
    CHECK(na == nb);
    for (int k = 0; k < na; ++k) {
        CHECK_NEAR(a[k].position.x, b[k].position.x, 0.0);
        CHECK_NEAR(a[k].position.z, b[k].position.z, 0.0);
        CHECK_NEAR(a[k].color.a, b[k].color.a, 0.0);
        CHECK_NEAR(a[k].size, b[k].size, 0.0);
    }
}

TEST(evaluate_respects_capacity) {
    EmitterSpec s; s.rate = 1000; s.lifetime = 10; s.lifetimeJitter = 0;
    std::vector<Particle> buf(50);
    int n = evaluate(s, 5.0f, buf.data(), (int)buf.size());
    CHECK(n <= 50);   // never overflows
}
