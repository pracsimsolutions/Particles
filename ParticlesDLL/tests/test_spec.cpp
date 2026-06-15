#include "test_framework.h"
#include "../EmitterSpec.h"

TEST(spec_defaults_are_sane) {
    EmitterSpec s;   // default-constructed
    CHECK(s.rate > 0.0f);
    CHECK(s.lifetime > 0.0f);
    CHECK(s.shape == EmitShape::Cone);
    CHECK(s.style == RenderStyle::Points);
    CHECK(s.colorStops.count >= 2);
    CHECK(s.maxLifetime() >= s.lifetime);   // jitter-inclusive ceiling
}

TEST(gradient_samples_endpoints_and_mid) {
    EmitterSpec s;
    s.colorStops.count = 2;
    s.colorStops.stops[0] = {0.0f, rgba{1, 0, 0, 1}};
    s.colorStops.stops[1] = {1.0f, rgba{0, 0, 1, 1}};
    CHECK_NEAR(s.colorStops.sample(0.0f).r, 1.0, 1e-6);
    CHECK_NEAR(s.colorStops.sample(1.0f).b, 1.0, 1e-6);
    CHECK_NEAR(s.colorStops.sample(0.5f).r, 0.5, 1e-6);
}
