#pragma once
#include <cmath>

// FlexSim-free math primitives for the analytic particle core.
// Converted to FlexSim Vec3f/Vec4f only at the mesh-fill boundary.

struct pvec3 {
    float x = 0, y = 0, z = 0;
    pvec3 operator+(const pvec3& o) const { return {x+o.x, y+o.y, z+o.z}; }
    pvec3 operator-(const pvec3& o) const { return {x-o.x, y-o.y, z-o.z}; }
    pvec3 operator*(float s) const { return {x*s, y*s, z*s}; }
    float length() const { return std::sqrt(x*x + y*y + z*z); }
    pvec3 normalized() const { float l = length(); return l > 1e-12f ? pvec3{x/l, y/l, z/l} : pvec3{0,0,0}; }
};

struct rgba { float r = 1, g = 1, b = 1, a = 1; };

inline rgba lerp(const rgba& a, const rgba& b, float t) {
    return { a.r+(b.r-a.r)*t, a.g+(b.g-a.g)*t, a.b+(b.b-a.b)*t, a.a+(b.a-a.a)*t };
}
inline float lerpf(float a, float b, float t) { return a + (b - a) * t; }
inline float clampf(float v, float lo, float hi) { return v < lo ? lo : (v > hi ? hi : v); }
