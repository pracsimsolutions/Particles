---
title: Particles
summary: "The Particles module namespace. Provides the global accessor to the one Particles.System per model."
order: 1
---

Visual particle emitters (smoke, sparks, fountains) drawn analytically at draw time so they add zero events to the simulation. Drop a [Particles.Emitter](Particles.Emitter.md) from the library; the [Particles.System](Particles.System.md) is created automatically.

```flexscript
Particles.System sys = Particles.system;
Particles.Emitter e = Model.find("ParticleEmitter1");
```

## Properties

| Property | Description |
| --- | --- |
| [system](#system) | The model's single [Particles.System](Particles.System.md) (NULL if no emitter has been created yet). |

## Property details

### system

`static readonly Particles.System system`

The model's single [Particles.System](Particles.System.md) (NULL if no emitter has been created yet).
