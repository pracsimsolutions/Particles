#pragma once
#include <cstdint>

// Deterministic, stateless per-particle randomness. The frame-skip guarantee
// requires particle i to always produce identical randoms, so everything is a
// pure hash of (seed, particle index, stream).

inline uint32_t phash(uint32_t seed, uint32_t i, uint32_t stream) {
    uint32_t x = seed * 0x9E3779B1u + i * 0x85EBCA77u + stream * 0xC2B2AE3Du;
    x ^= x >> 16; x *= 0x7FEB352Du;
    x ^= x >> 15; x *= 0x846CA68Bu;
    x ^= x >> 16;
    return x;
}
// Uniform float in [0, 1).
inline float prandf(uint32_t seed, uint32_t i, uint32_t stream) {
    return (phash(seed, i, stream) >> 8) * (1.0f / 16777216.0f);  // 24-bit mantissa
}
// Uniform float in [lo, hi).
inline float prandRange(uint32_t seed, uint32_t i, uint32_t stream, float lo, float hi) {
    return lo + (hi - lo) * prandf(seed, i, stream);
}
