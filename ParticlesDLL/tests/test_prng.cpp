#include "test_framework.h"
#include "../prng.h"

TEST(prng_is_deterministic) {
    // Same (seed, i, stream) -> identical output, every call.
    CHECK_NEAR(prandf(123, 7, 0), prandf(123, 7, 0), 0.0);
    CHECK(prandf(123, 7, 0) != prandf(123, 8, 0));   // different particle
    CHECK(prandf(123, 7, 0) != prandf(123, 7, 1));   // different stream
    CHECK(prandf(999, 7, 0) != prandf(123, 7, 0));   // different seed
}

TEST(prng_in_unit_range) {
    for (uint32_t i = 0; i < 1000; ++i) {
        float v = prandf(42, i, 0);
        CHECK(v >= 0.0f && v < 1.0f);
    }
}

TEST(prng_roughly_uniform_mean) {
    double sum = 0; const int N = 20000;
    for (int i = 0; i < N; ++i) sum += prandf(7, i, 2);
    CHECK_NEAR(sum / N, 0.5, 0.02);   // mean near 0.5
}
