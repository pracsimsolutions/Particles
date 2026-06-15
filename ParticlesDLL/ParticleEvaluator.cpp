#include "ParticleEvaluator.h"
#include <cmath>
#include <algorithm>

LiveRange computeLiveRange(const EmitterSpec& s, float T) {
    float emitEnd = std::min(T, s.stopTime);
    long iMax = (long)std::floor((emitEnd - s.startTime) * s.rate);
    long iMin = (long)std::ceil((T - s.maxLifetime() - s.startTime) * s.rate);
    if (iMin < 0) iMin = 0;
    return { iMin, iMax };
}

static pvec3 sampleConeDir(const EmitterSpec& s, long i) {
    // Cone around +Z, half-angle coneHalfAngleDeg. u1 -> cos(theta), u2 -> phi.
    float maxCos = std::cos(s.coneHalfAngleDeg * 3.14159265f / 180.0f);
    float c = prandRange(s.seed, (uint32_t)i, 0, maxCos, 1.0f);
    float sinT = std::sqrt(std::max(0.0f, 1.0f - c * c));
    float phi = prandRange(s.seed, (uint32_t)i, 1, 0.0f, 6.2831853f);
    return { sinT * std::cos(phi), sinT * std::sin(phi), c };
}

static pvec3 sampleUnitSphere(const EmitterSpec& s, long i) {
    float z = prandRange(s.seed, (uint32_t)i, 2, -1.0f, 1.0f);
    float phi = prandRange(s.seed, (uint32_t)i, 3, 0.0f, 6.2831853f);
    float r = std::sqrt(std::max(0.0f, 1.0f - z * z));
    return { r * std::cos(phi), r * std::sin(phi), z };
}

void initialConditions(const EmitterSpec& s, long i, pvec3& p0, pvec3& v0, float& lifetime) {
    pvec3 dir;
    switch (s.shape) {
        case EmitShape::Point: p0 = {0,0,0}; dir = sampleConeDir(s, i); break;
        case EmitShape::Cone:  p0 = {0,0,0}; dir = sampleConeDir(s, i); break;
        case EmitShape::Sphere: { pvec3 u = sampleUnitSphere(s, i); p0 = u * s.shapeSize; dir = u; break; }
        case EmitShape::Disk: {
            float ang = prandRange(s.seed,(uint32_t)i,2,0,6.2831853f);
            float rad = s.shapeSize * std::sqrt(prandf(s.seed,(uint32_t)i,3));
            p0 = { rad*std::cos(ang), rad*std::sin(ang), 0 }; dir = {0,0,1}; break;
        }
        case EmitShape::Line:
            p0 = { 0, 0, prandRange(s.seed,(uint32_t)i,2,-s.shapeSize,s.shapeSize) };
            dir = sampleConeDir(s, i); break;
        default: p0 = {0,0,0}; dir = {0,0,1};
    }
    float spd = s.speed + prandRange(s.seed,(uint32_t)i,4,-s.speedJitter,s.speedJitter);
    v0 = dir.normalized() * spd;
    lifetime = s.lifetime + prandf(s.seed,(uint32_t)i,5) * s.lifetimeJitter;
}

pvec3 positionAt(const EmitterSpec& s, long i, const pvec3& p0, const pvec3& v0, float a) {
    pvec3 p;
    if (s.drag > 1e-6f) {
        float k = s.drag;
        float e = std::exp(-k * a);
        // integral of v0*e^-k t  = (v0/k)(1 - e^-k a)
        pvec3 dragPart = v0 * ((1.0f - e) / k);
        // gravity+wind as constant accel g: position contribution = g*(a/k - (1-e)/k^2)
        pvec3 g = s.gravity + s.wind;
        float gp = (a / k) - (1.0f - e) / (k * k);
        p = p0 + dragPart + g * gp;
    } else {
        pvec3 g = s.gravity + s.wind;
        p = p0 + v0 * a + g * (0.5f * a * a);
    }
    if (s.swirlAmp > 1e-6f) {
        float ph = prandf(s.seed, (uint32_t)i, 6) * 6.2831853f;
        float w = s.swirlFreq;
        p.x += s.swirlAmp * std::sin(w * a + ph);
        p.y += s.swirlAmp * std::cos(w * a + ph);
    }
    return p;
}

rgba colorAt(const EmitterSpec& s, float u) {
    u = clampf(u, 0.0f, 1.0f);
    rgba c = s.colorStops.sample(u);
    c.a *= lerpf(s.alphaStart, s.alphaEnd, u);   // alpha curve modulates gradient alpha
    return c;
}

float sizeAt(const EmitterSpec& s, float u) {
    return lerpf(s.sizeStart, s.sizeEnd, clampf(u, 0.0f, 1.0f));
}

int evaluate(const EmitterSpec& s, float T, Particle* out, int outCap) {
    LiveRange r = computeLiveRange(s, T);
    int n = 0;
    for (long i = r.iMin; i <= r.iMax && n < outCap; ++i) {
        float birth = s.startTime + (float)i / s.rate;
        float age = T - birth;
        if (age < 0) continue;
        pvec3 p0, v0; float life;
        initialConditions(s, i, p0, v0, life);
        if (age >= life) continue;            // lifetime-jitter cull
        float u = age / life;
        out[n].position = positionAt(s, i, p0, v0, age);
        out[n].color = colorAt(s, u);
        out[n].size = sizeAt(s, u);
        ++n;
    }
    return n;
}
