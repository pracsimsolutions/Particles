#include "test_framework.h"
#include "../pmath.h"

TEST(pvec3_add_scale) {
    pvec3 a{1, 2, 3}, b{4, 5, 6};
    pvec3 c = a + b;
    CHECK_NEAR(c.x, 5, 1e-9); CHECK_NEAR(c.y, 7, 1e-9); CHECK_NEAR(c.z, 9, 1e-9);
    pvec3 d = a * 2.0f;
    CHECK_NEAR(d.x, 2, 1e-9); CHECK_NEAR(d.z, 6, 1e-9);
}

TEST(pvec3_length_normalize) {
    pvec3 v{3, 4, 0};
    CHECK_NEAR(v.length(), 5, 1e-6);
    pvec3 n = v.normalized();
    CHECK_NEAR(n.length(), 1, 1e-6);
}

TEST(rgba_lerp) {
    rgba a{0, 0, 0, 0}, b{1, 1, 1, 1};
    rgba m = lerp(a, b, 0.5f);
    CHECK_NEAR(m.r, 0.5, 1e-6); CHECK_NEAR(m.a, 0.5, 1e-6);
}
