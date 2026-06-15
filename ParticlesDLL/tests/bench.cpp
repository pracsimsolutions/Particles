#include "test_framework.h"
#include "../ParticleEvaluator.h"
#include <vector>
#include <chrono>

TEST(benchmark_throughput) {
    EmitterSpec s; s.rate = 100000; s.lifetime = 1.0f; s.lifetimeJitter = 0.2f; s.swirlAmp = 0.1f;
    std::vector<Particle> buf(200000);
    auto t0 = std::chrono::high_resolution_clock::now();
    int n = 0; const int iters = 50;
    for (int it = 0; it < iters; ++it) n = evaluate(s, 5.0f, buf.data(), (int)buf.size());
    auto t1 = std::chrono::high_resolution_clock::now();
    double ms = std::chrono::duration<double, std::milli>(t1 - t0).count() / iters;
    std::printf("  [bench] %d particles/eval, %.3f ms/eval (%.1f M particles/sec)\n",
                n, ms, (n / ms) / 1000.0);
    CHECK(n > 0);   // sanity; timing is informational
}
