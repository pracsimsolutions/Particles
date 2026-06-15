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

// Rotate v by Euler angles (degrees), applied X then Y then Z (R = Rz*Ry*Rx).
// Used to bake an emitter's world orientation into particle positions so the
// whole system can draw in one batch.
inline pvec3 rotateEulerZYX(const pvec3& v, float rxDeg, float ryDeg, float rzDeg) {
    const float d2r = 3.14159265358979f / 180.0f;
    float cx = std::cos(rxDeg*d2r), sx = std::sin(rxDeg*d2r);
    float cy = std::cos(ryDeg*d2r), sy = std::sin(ryDeg*d2r);
    float cz = std::cos(rzDeg*d2r), sz = std::sin(rzDeg*d2r);
    // Rx
    pvec3 a{ v.x, v.y*cx - v.z*sx, v.y*sx + v.z*cx };
    // Ry
    pvec3 b{ a.x*cy + a.z*sy, a.y, -a.x*sy + a.z*cy };
    // Rz
    return { b.x*cz - b.y*sz, b.x*sz + b.y*cz, b.z };
}

// Transform a particle position from emitter-local space to world space.
inline pvec3 localToWorld(const pvec3& local, const pvec3& worldPos, const pvec3& rotDeg) {
    return rotateEulerZYX(local, rotDeg.x, rotDeg.y, rotDeg.z) + worldPos;
}
