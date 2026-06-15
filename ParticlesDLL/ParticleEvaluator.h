#pragma once
#include "EmitterSpec.h"
#include "prng.h"
#include <cstdint>

struct LiveRange { long iMin; long iMax; };   // inclusive; empty if iMax < iMin

struct Particle {
    pvec3 position;
    rgba  color;
    float size;
};

// Closed-form set of currently-live particle indices at time T (continuous mode).
LiveRange computeLiveRange(const EmitterSpec& s, float T);

// Initial conditions for particle i (deterministic).
void initialConditions(const EmitterSpec& s, long i, pvec3& p0, pvec3& v0, float& lifetime);

// Position at age a given initial conditions (closed-form motion).
pvec3 positionAt(const EmitterSpec& s, long i, const pvec3& p0, const pvec3& v0, float a);

// Appearance at normalized life u in [0,1].
rgba colorAt(const EmitterSpec& s, float u);
float sizeAt(const EmitterSpec& s, float u);

// Fill `out` (capacity outCap) with live particles at time T; returns count written.
int evaluate(const EmitterSpec& s, float T, Particle* out, int outCap);
