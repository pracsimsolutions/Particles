---
title: Particles.Direction
summary: "An enumeration of the launch-direction modes, for directionField."
order: 7
---

```flexscript
Model.find("ParticleEmitter1").as(Particles.Emitter).directionField = Particles.Direction.Omni;
```

## Properties

| Property | Description |
| --- | --- |
| [Aimed](#aimed) | Launch in a cone around the aim arrow (local +Z), with the half-angle set by coneHalfAngleDeg. |
| [Omni](#omni) | Launch uniformly in all directions (the aim arrow is hidden). |

## Property details

### Aimed

`static readonly int Aimed`

Launch in a cone around the aim arrow (local +Z), with the half-angle set by coneHalfAngleDeg.

Value: `0`

### Omni

`static readonly int Omni`

Launch uniformly in all directions (the aim arrow is hidden).

Value: `1`
