#include "test_framework.h"
#include "../ParticleEvaluator.h"
#include <cmath>

TEST(point_shape_starts_at_origin) {
    EmitterSpec s; s.shape = EmitShape::Point; s.coneHalfAngleDeg = 0; s.speedJitter = 0; s.speed = 2;
    pvec3 p0, v0; float life;
    initialConditions(s, 0, p0, v0, life);
    CHECK_NEAR(p0.length(), 0, 1e-6);
    CHECK_NEAR(v0.length(), 2, 1e-5);   // speed magnitude, no jitter
}

TEST(lifetime_jitter_within_bounds) {
    EmitterSpec s; s.lifetime = 2; s.lifetimeJitter = 0.5f;
    for (long i = 0; i < 500; ++i) {
        pvec3 p0, v0; float life;
        initialConditions(s, i, p0, v0, life);
        CHECK(life >= 2.0f && life <= 2.5f);
    }
}

TEST(sphere_shape_on_radius) {
    EmitterSpec s; s.shape = EmitShape::Sphere;
    s.regionX = s.regionY = s.regionZ = 6.0f;   // radius = 3
    pvec3 p0, v0; float life;
    initialConditions(s, 5, p0, v0, life);
    CHECK_NEAR(p0.length(), 3.0, 1e-4);   // on sphere surface
}
