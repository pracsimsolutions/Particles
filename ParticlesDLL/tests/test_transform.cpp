#include "test_framework.h"
#include "../pmath.h"

TEST(rotate_about_z_90) {
    pvec3 r = rotateEulerZYX(pvec3{1,0,0}, 0, 0, 90);
    CHECK_NEAR(r.x, 0, 1e-5); CHECK_NEAR(r.y, 1, 1e-5); CHECK_NEAR(r.z, 0, 1e-5);
}

TEST(rotate_about_y_90) {
    pvec3 r = rotateEulerZYX(pvec3{1,0,0}, 0, 90, 0);
    CHECK_NEAR(r.x, 0, 1e-5); CHECK_NEAR(r.y, 0, 1e-5); CHECK_NEAR(r.z, -1, 1e-5);
}

TEST(rotate_about_x_90) {
    pvec3 r = rotateEulerZYX(pvec3{0,1,0}, 90, 0, 0);
    CHECK_NEAR(r.x, 0, 1e-5); CHECK_NEAR(r.y, 0, 1e-5); CHECK_NEAR(r.z, 1, 1e-5);
}

TEST(identity_rotation_is_noop) {
    pvec3 r = rotateEulerZYX(pvec3{2,-3,5}, 0, 0, 0);
    CHECK_NEAR(r.x, 2, 1e-6); CHECK_NEAR(r.y, -3, 1e-6); CHECK_NEAR(r.z, 5, 1e-6);
}

TEST(local_to_world_translates_after_rotation) {
    // rotate (1,0,0) by 90 about Z -> (0,1,0), then translate by (10,20,30)
    pvec3 w = localToWorld(pvec3{1,0,0}, pvec3{10,20,30}, pvec3{0,0,90});
    CHECK_NEAR(w.x, 10, 1e-4); CHECK_NEAR(w.y, 21, 1e-4); CHECK_NEAR(w.z, 30, 1e-4);
}
