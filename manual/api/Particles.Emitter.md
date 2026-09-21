---
title: Particles.Emitter
summary: "A placeable particle emitter. Holds the declarative spec (shape, motion, appearance); the singleton Particles.System reads every emitter and batch-draws its particles analytically at draw time, adding zero events to the simulation."
order: 3
---

Inherits from `Object`.

Particles are a closed-form function of model time T (like kinematics), evaluated only when the scene is drawn, so emitters never slow the discrete-event simulation and are frame-skip invariant and deterministic per [seedField](Particles.Emitter.md#seedfield).

The emission region is sized by the object's own resize handles; particle size is independent of object scale. Drop an emitter and it auto-creates the [Particles.System](Particles.System.md).

```flexscript
Particles.Emitter e = Model.find("ParticleEmitter1");
e.shapeField = Particles.Shape.Sphere;
e.gravity.z = -9.8;
e.startColor = Color.orange;
```

Units: length = the model length unit, time = the model time unit. Angles are degrees.

## Properties

| Property | Description |
| --- | --- |
| [rate](#rate) | Emission rate, particles per time unit. Birth schedule: birth = startTime + i/rate. |
| [startTime](#starttime) | Model time at which emission begins (0 = from run start). May be a number OR a FlexScript expression in the property; evaluated each draw. |
| [stopTimeField](#stoptimefield) | Model time at which emission ends (0 = never). May be a number OR a FlexScript expression. |
| [prewarm](#prewarm) | How far back to pre-simulate emission (in model time units), so the cloud is already full at reset / T = 0 (evaluates at T + prewarm). |
| [lifetime](#lifetime) | Particle lifetime in time units. |
| [lifetimeJitter](#lifetimejitter) | Random extra lifetime per particle, between 0 and this value. |
| [shapeField](#shapefield) | Emission shape; use [Particles.Shape](Particles.Shape.md) (Point/Line/Disk/Plane/Box/Sphere). The region fills the object's resized footprint. |
| [directionField](#directionfield) | Launch direction mode; use [Particles.Direction](Particles.Direction.md) (Aimed = cone around the aim arrow / local +Z, Omni = all directions). |
| [coneHalfAngleDeg](#conehalfangledeg) | Spread: the half-angle (degrees) of the Aimed launch cone. |
| [speed](#speed) | Initial launch speed, length per time unit. |
| [speedJitter](#speedjitter) | Random launch-speed spread, applied as +/- jitter. |
| [gravity](#gravity) | Constant acceleration (length / time^2). Node-backed: read/write components, e.g. `e.gravity.z = -9.8;` or assign a whole Vec3. |
| [wind](#wind) | Additional constant acceleration (length / time^2), added to gravity. With drag > 0 it acts as a steady drift toward (gravity+wind)/drag. |
| [drag](#drag) | Exponential velocity-decay rate (1 / time). 0 = none; velocity carries a factor e^(-drag\*age). |
| [swirlAmp](#swirlamp) | Radius (length) of a circular wobble added to each particle's path, giving a corkscrew/spiral look. 0 = off. |
| [swirlFreq](#swirlfreq) | Angular frequency of the swirl, radians per time unit (period = 2\*pi/swirlFreq). |
| [startColor](#startcolor) | Color (and alpha) at birth. Node-backed: `e.startColor.r = 0.5;` or `e.startColor = Color.red;` |
| [endColor](#endcolor) | Color (and alpha) at end of life. The particle color interpolates startColor -> endColor over its life. |
| [sizeStart](#sizestart) | Particle size (world diameter) at birth. |
| [sizeEnd](#sizeend) | Particle size (world diameter) at end of life. |
| [styleField](#stylefield) | Render style; use [Particles.Style](Particles.Style.md) (Points = built-in soft dot, Sprite = the object's own image). Every particle is a camera-facing billboard. |
| [seedField](#seedfield) | Random seed for this emitter (determinism). |
| [disabled](#disabled) | 1 = turn this emitter off (it produces no particles); 0 = active. The emitter's handle still draws while disabled, so you can find and re-enable it. |
| [statLiveCount](#statlivecount) | Read-only: the number of live particles this emitter drew last frame. |

## Property details

### rate

`double rate`

Emission rate, particles per time unit. Birth schedule: birth = startTime + i/rate.

### startTime

`double startTime`

Model time at which emission begins (0 = from run start). May be a number OR a FlexScript expression in the property; evaluated each draw.

### stopTimeField

`double stopTimeField`

Model time at which emission ends (0 = never). May be a number OR a FlexScript expression.

### prewarm

`double prewarm`

How far back to pre-simulate emission (in model time units), so the cloud is already full at reset / T = 0 (evaluates at T + prewarm).

### lifetime

`double lifetime`

Particle lifetime in time units.

### lifetimeJitter

`double lifetimeJitter`

Random extra lifetime per particle, between 0 and this value.

### shapeField

`int shapeField`

Emission shape; use [Particles.Shape](Particles.Shape.md) (Point/Line/Disk/Plane/Box/Sphere). The region fills the object's resized footprint.

### directionField

`int directionField`

Launch direction mode; use [Particles.Direction](Particles.Direction.md) (Aimed = cone around the aim arrow / local +Z, Omni = all directions).

### coneHalfAngleDeg

`double coneHalfAngleDeg`

Spread: the half-angle (degrees) of the Aimed launch cone.

### speed

`double speed`

Initial launch speed, length per time unit.

### speedJitter

`double speedJitter`

Random launch-speed spread, applied as +/- jitter.

### gravity

`Vec3 gravity`

Constant acceleration (length / time^2). Node-backed: read/write components, e.g. `e.gravity.z = -9.8;` or assign a whole Vec3.

### wind

`Vec3 wind`

Additional constant acceleration (length / time^2), added to gravity. With drag > 0 it acts as a steady drift toward (gravity+wind)/drag.

### drag

`double drag`

Exponential velocity-decay rate (1 / time). 0 = none; velocity carries a factor e^(-drag\*age).

### swirlAmp

`double swirlAmp`

Radius (length) of a circular wobble added to each particle's path, giving a corkscrew/spiral look. 0 = off.

### swirlFreq

`double swirlFreq`

Angular frequency of the swirl, radians per time unit (period = 2\*pi/swirlFreq).

### startColor

`Color startColor`

Color (and alpha) at birth. Node-backed: `e.startColor.r = 0.5;` or `e.startColor = Color.red;`

### endColor

`Color endColor`

Color (and alpha) at end of life. The particle color interpolates startColor -> endColor over its life.

### sizeStart

`double sizeStart`

Particle size (world diameter) at birth.

### sizeEnd

`double sizeEnd`

Particle size (world diameter) at end of life.

### styleField

`int styleField`

Render style; use [Particles.Style](Particles.Style.md) (Points = built-in soft dot, Sprite = the object's own image). Every particle is a camera-facing billboard.

### seedField

`int seedField`

Random seed for this emitter (determinism).

### disabled

`int disabled`

1 = turn this emitter off (it produces no particles); 0 = active. The emitter's handle still draws while disabled, so you can find and re-enable it.

### statLiveCount

`readonly int statLiveCount`

Read-only: the number of live particles this emitter drew last frame.
