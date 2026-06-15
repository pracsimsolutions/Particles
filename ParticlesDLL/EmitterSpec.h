#pragma once
#include "pmath.h"
#include <cstdint>

enum class EmitShape { Point, Cone, Sphere, Disk, Line };
enum class EmitMode  { Continuous, Burst, LoopingBurst };
enum class RenderStyle { Points, Sprite };  // Instanced is a future style

struct ColorStop { float u; rgba color; };   // u in [0,1] over normalized life
struct Gradient {
    static constexpr int MAX = 4;
    ColorStop stops[MAX];
    int count = 0;
    rgba sample(float u) const {
        if (count <= 0) return rgba{};
        if (u <= stops[0].u) return stops[0].color;
        for (int k = 1; k < count; ++k)
            if (u <= stops[k].u) {
                float span = stops[k].u - stops[k-1].u;
                float t = span > 1e-6f ? (u - stops[k-1].u) / span : 0.0f;
                return lerp(stops[k-1].color, stops[k].color, t);
            }
        return stops[count-1].color;
    }
};

struct EmitterSpec {
    // Emission
    float rate = 50.0f;            // particles/sec
    float startTime = 0.0f;
    float stopTime = 1e30f;        // effectively never
    EmitMode mode = EmitMode::Continuous;
    int   burstCount = 100;
    float burstPeriod = 1.0f;      // for LoopingBurst

    // Shape
    EmitShape shape = EmitShape::Cone;
    float coneHalfAngleDeg = 20.0f;
    float shapeSize = 0.0f;        // sphere/disk radius, line half-length

    // Launch
    float speed = 1.0f, speedJitter = 0.2f;
    float lifetime = 2.0f, lifetimeJitter = 0.3f;

    // Forces (closed-form)
    pvec3 gravity{0, 0, -1.0f};
    float drag = 0.0f;             // exponential coefficient k; 0 = none
    pvec3 wind{0, 0, 0};
    float swirlAmp = 0.0f, swirlFreq = 1.0f;

    // Appearance
    Gradient colorStops;           // initialized in ctor below
    float sizeStart = 0.1f, sizeEnd = 0.1f;   // size over life (sizeCurve)
    float alphaStart = 1.0f, alphaEnd = 0.0f; // alpha over life

    // Render
    RenderStyle style = RenderStyle::Points;
    float pointSize = 3.0f;        // px, points style only
    bool  luminous = true;         // flat emissive (lighting off)

    // Determinism
    uint32_t seed = 12345;

    EmitterSpec() {
        colorStops.count = 2;
        colorStops.stops[0] = {0.0f, rgba{1, 1, 1, 1}};
        colorStops.stops[1] = {1.0f, rgba{1, 1, 1, 0}};
    }

    float maxLifetime() const { return lifetime + (lifetimeJitter > 0 ? lifetimeJitter : 0); }
};
