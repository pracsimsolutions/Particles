---
title: Particles.Vec3
summary: "A node-backed 3-component vector used for an emitter's gravity and wind (both accelerations, length / time^2). Components can be read and written individually and persist in the tree."
order: 5
---

Because it is node-backed, component assignment writes through:

```flexscript
Particles.Emitter e = Model.find("ParticleEmitter1");
e.gravity.z = -9.8;            // component write, persists
e.wind = Vec3(1, 0, 0);       // whole-vector assign from a FlexSim Vec3
print(e.gravity);             // [x, y, z]
```

## Properties

| Property | Description |
| --- | --- |
| [x](#x) | X component. |
| [y](#y) | Y component. |
| [z](#z) | Z component. |

## Property details

### x

`double x`

X component.

### y

`double y`

Y component.

### z

`double z`

Z component.
