---
title: Particles.Color
summary: "A node-backed RGBA color used for an emitter's startColor and endColor. Each channel is 0-1; the components can be read and written individually and persist in the tree."
order: 4
---

Because it is node-backed, component assignment writes through (unlike a plain value type):

```flexscript
Particles.Emitter e = Model.find("ParticleEmitter1");
e.startColor.r = 0.5;          // component write, persists
e.startColor = Color.red;      // whole-color assign from a FlexSim Color
print(e.startColor);           // [r, g, b, a]
```

## Properties

| Property | Description |
| --- | --- |
| [r](#r) | Red channel, 0-1. |
| [g](#g) | Green channel, 0-1. |
| [b](#b) | Blue channel, 0-1. |
| [a](#a) | Alpha (opacity) channel, 0-1. |

## Property details

### r

`double r`

Red channel, 0-1.

### g

`double g`

Green channel, 0-1.

### b

`double b`

Blue channel, 0-1.

### a

`double a`

Alpha (opacity) channel, 0-1.
