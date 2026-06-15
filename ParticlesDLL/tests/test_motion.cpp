#include "test_framework.h"
#include "../ParticleEvaluator.h"

TEST(ballistic_no_forces) {
    EmitterSpec s; s.gravity = {0,0,0}; s.drag = 0; s.wind = {0,0,0}; s.swirlAmp = 0;
    pvec3 p0{0,0,0}, v0{1,0,0};
    pvec3 p = positionAt(s, 0, p0, v0, 3.0f);
    CHECK_NEAR(p.x, 3.0, 1e-5); CHECK_NEAR(p.z, 0.0, 1e-5);
}

TEST(gravity_parabola) {
    EmitterSpec s; s.gravity = {0,0,-10}; s.drag = 0; s.wind = {0,0,0}; s.swirlAmp = 0;
    pvec3 p0{0,0,0}, v0{0,0,0};
    pvec3 p = positionAt(s, 0, p0, v0, 2.0f);
    CHECK_NEAR(p.z, -20.0, 1e-4);   // 0.5*-10*4
}

TEST(drag_decays_velocity) {
    EmitterSpec s; s.gravity = {0,0,0}; s.drag = 1.0f; s.wind = {0,0,0}; s.swirlAmp = 0;
    pvec3 p0{0,0,0}, v0{10,0,0};
    // With drag k=1: x = (v0/k)(1-e^-k a). As a->inf, x->10. At a=large, near 10.
    pvec3 p = positionAt(s, 0, p0, v0, 20.0f);
    CHECK_NEAR(p.x, 10.0, 0.01);
}
