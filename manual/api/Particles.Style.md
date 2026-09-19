---
title: Particles.Style
summary: "An enumeration of the particle render styles, for styleField. Every particle is a camera-facing billboard regardless of style."
order: 8
---

```flexscript
Model.find("ParticleEmitter1").as(Particles.Emitter).styleField = Particles.Style.Sprite;
```

## Properties

| Property | Description |
| --- | --- |
| [Points](#points) | Render with the built-in soft round dot. |
| [Sprite](#sprite) | Render with the emitter object's own image (set it the normal way with the image picker). Falls back to the soft dot if no image is set. |

## Property details

### Points

`static readonly int Points`

Render with the built-in soft round dot.

Value: `0`

### Sprite

`static readonly int Sprite`

Render with the emitter object's own image (set it the normal way with the image picker). Falls back to the soft dot if no image is set.

Value: `1`
