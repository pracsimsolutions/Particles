---
title: Particles.Shape
summary: "An enumeration of the emission region shapes, for shapeField. The region is sized by the emitter object's resize handles."
order: 6
---

```flexscript
Model.find("ParticleEmitter1").as(Particles.Emitter).shapeField = Particles.Shape.Sphere;
```

## Properties

| Property | Description |
| --- | --- |
| [Point](#point) | Emit from a single point. |
| [Line](#line) | Emit along a line (the object's X extent). |
| [Disk](#disk) | Emit from a filled ellipse in the object's footprint. |
| [Plane](#plane) | Emit from a filled rectangle (the object's footprint). |
| [Box](#box) | Emit from anywhere within the object's 3D volume. |
| [Sphere](#sphere) | Emit from within an ellipsoid volume (naturally omnidirectional; the aim arrow is hidden). |

## Property details

### Point

`static readonly int Point`

Emit from a single point.

Value: `0`

### Line

`static readonly int Line`

Emit along a line (the object's X extent).

Value: `1`

### Disk

`static readonly int Disk`

Emit from a filled ellipse in the object's footprint.

Value: `2`

### Plane

`static readonly int Plane`

Emit from a filled rectangle (the object's footprint).

Value: `3`

### Box

`static readonly int Box`

Emit from anywhere within the object's 3D volume.

Value: `4`

### Sphere

`static readonly int Sphere`

Emit from within an ellipsoid volume (naturally omnidirectional; the aim arrow is hidden).

Value: `5`
