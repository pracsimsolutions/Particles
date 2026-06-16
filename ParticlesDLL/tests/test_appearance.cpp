#include "test_framework.h"
#include "../ParticleEvaluator.h"

TEST(alpha_fades_over_life) {
    // Alpha is folded into the rgba gradient stops -> sample() interpolates it directly.
    EmitterSpec s;
    s.colorStops.count = 2;
    s.colorStops.stops[0] = {0.0f, rgba{1,1,1,1}};
    s.colorStops.stops[1] = {1.0f, rgba{1,1,1,0}};
    CHECK_NEAR(colorAt(s, 0.0f).a, 1.0, 1e-5);
    CHECK_NEAR(colorAt(s, 1.0f).a, 0.0, 1e-5);
    CHECK_NEAR(colorAt(s, 0.5f).a, 0.5, 1e-5);
}

TEST(color_gradient_interpolates) {
    EmitterSpec s;
    s.colorStops.count = 2;
    s.colorStops.stops[0] = {0.0f, rgba{1,0,0,1}};
    s.colorStops.stops[1] = {1.0f, rgba{0,0,1,1}};
    rgba mid = colorAt(s, 0.5f);
    CHECK_NEAR(mid.r, 0.5, 1e-5); CHECK_NEAR(mid.b, 0.5, 1e-5);
}

TEST(size_curve_interpolates) {
    EmitterSpec s; s.sizeStart = 0.1f; s.sizeEnd = 0.5f;
    CHECK_NEAR(sizeAt(s, 0.0f), 0.1, 1e-6);
    CHECK_NEAR(sizeAt(s, 1.0f), 0.5, 1e-6);
}
