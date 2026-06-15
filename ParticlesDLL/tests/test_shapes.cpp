#include "test_framework.h"
#include "../ParticleEvaluator.h"
#include <cmath>

// Region dims come from the object size; here we set them directly on the spec.

TEST(plane_spawns_within_rectangle) {
    EmitterSpec s; s.shape = EmitShape::Plane; s.regionX = 8; s.regionY = 4;
    for (long i = 0; i < 600; ++i) {
        pvec3 p0, v0; float life; initialConditions(s, i, p0, v0, life);
        CHECK(p0.x >= -4.0001f && p0.x <= 4.0001f);
        CHECK(p0.y >= -2.0001f && p0.y <= 2.0001f);
        CHECK(std::fabs(p0.z) < 1e-5f);          // flat
    }
}

TEST(box_spawns_within_volume) {
    EmitterSpec s; s.shape = EmitShape::Box; s.regionX = 6; s.regionY = 2; s.regionZ = 10;
    bool sawZ = false;
    for (long i = 0; i < 600; ++i) {
        pvec3 p0, v0; float life; initialConditions(s, i, p0, v0, life);
        CHECK(std::fabs(p0.x) <= 3.0001f);
        CHECK(std::fabs(p0.y) <= 1.0001f);
        CHECK(std::fabs(p0.z) <= 5.0001f);
        if (std::fabs(p0.z) > 0.5f) sawZ = true;
    }
    CHECK(sawZ);                                 // box has depth, unlike plane
}

TEST(line_spawns_along_x) {
    EmitterSpec s; s.shape = EmitShape::Line; s.regionX = 10;
    for (long i = 0; i < 300; ++i) {
        pvec3 p0, v0; float life; initialConditions(s, i, p0, v0, life);
        CHECK(std::fabs(p0.x) <= 5.0001f);
        CHECK(std::fabs(p0.y) < 1e-5f);
        CHECK(std::fabs(p0.z) < 1e-5f);
    }
}

TEST(disk_spawns_within_ellipse) {
    EmitterSpec s; s.shape = EmitShape::Disk; s.regionX = 8; s.regionY = 4;  // radii 4, 2
    for (long i = 0; i < 600; ++i) {
        pvec3 p0, v0; float life; initialConditions(s, i, p0, v0, life);
        float e = (p0.x/4.0f)*(p0.x/4.0f) + (p0.y/2.0f)*(p0.y/2.0f);
        CHECK(e <= 1.0001f);                     // inside the ellipse
        CHECK(std::fabs(p0.z) < 1e-5f);
    }
}

TEST(aimed_launches_along_plus_z) {
    EmitterSpec s; s.shape = EmitShape::Point; s.direction = DirectionMode::Aimed;
    s.coneHalfAngleDeg = 20; s.speed = 1; s.speedJitter = 0;
    for (long i = 0; i < 300; ++i) {
        pvec3 p0, v0; float life; initialConditions(s, i, p0, v0, life);
        CHECK(v0.z > 0.0f);                      // within a 20deg cone of +Z, vz always positive
    }
}

TEST(omni_launches_all_directions) {
    EmitterSpec s; s.shape = EmitShape::Point; s.direction = DirectionMode::Omni;
    s.speed = 1; s.speedJitter = 0;
    bool down = false, up = false;
    for (long i = 0; i < 600; ++i) {
        pvec3 p0, v0; float life; initialConditions(s, i, p0, v0, life);
        if (v0.z < -0.3f) down = true;
        if (v0.z >  0.3f) up = true;
    }
    CHECK(down && up);                           // omni emits downward AND upward
}
