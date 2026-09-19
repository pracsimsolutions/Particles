---
title: Particles.System
summary: "The singleton manager for the Particles module. Discovers every Particles.Emitter in the model and batch-draws all of their particles in one pass at draw time."
order: 2
---

Inherits from `Object`.

Exactly one system exists per model (auto-created when the first emitter is dropped). Access it via the static `Particles.system` accessor:

```flexscript
Particles.System sys = Particles.system;
sys.liveCap = 50000;
print(sys.statTotalLive);
```

Holds global render/visibility controls and read-only performance stats. The emitters own their handles and per-emitter spec; the system only draws particles.

## Properties

| Property | Description |
| --- | --- |
| [liveCap](#livecap) | Hard cap on the number of live particles evaluated per emitter (graceful degradation for heavy scenes). |
| [showPlanes](#showplanes) | 1 = draw every emitter's region outline (the wireframe shape); 0 = hide. |
| [showArrows](#showarrows) | 1 = draw every emitter's aim pyramid; 0 = hide. |
| [arrowSize](#arrowsize) | World-unit size of the aim pyramid handle (constant size, independent of emitter scale). |
| [lod](#lod) | 1 = distance LOD on. Far emitters emit fewer particles (the emission rate is scaled by (lodStart/distance)^2 beyond lodStart), cutting draw cost. |
| [lodStart](#lodstart) | Distance (length units) within which an emitter keeps full detail; beyond it, the LOD rate falloff begins. |
| [lodMin](#lodmin) | Floor on the LOD multiplier (0-1): how sparse a far emitter is allowed to get. 1 = never thin. |
| [statEmitterCount](#statemittercount) | Read-only: number of emitters found this frame. |
| [statTotalLive](#stattotallive) | Read-only: total live particles drawn this frame across all emitters. |
| [statBuildMs](#statbuildms) | Read-only: milliseconds spent evaluating particles this frame. |
| [statDrawMs](#statdrawms) | Read-only: milliseconds spent drawing particles this frame. |

## Property details

### liveCap

`double liveCap`

Hard cap on the number of live particles evaluated per emitter (graceful degradation for heavy scenes).

### showPlanes

`double showPlanes`

1 = draw every emitter's region outline (the wireframe shape); 0 = hide.

### showArrows

`double showArrows`

1 = draw every emitter's aim pyramid; 0 = hide.

### arrowSize

`double arrowSize`

World-unit size of the aim pyramid handle (constant size, independent of emitter scale).

### lod

`double lod`

1 = distance LOD on. Far emitters emit fewer particles (the emission rate is scaled by (lodStart/distance)^2 beyond lodStart), cutting draw cost.

### lodStart

`double lodStart`

Distance (length units) within which an emitter keeps full detail; beyond it, the LOD rate falloff begins.

### lodMin

`double lodMin`

Floor on the LOD multiplier (0-1): how sparse a far emitter is allowed to get. 1 = never thin.

### statEmitterCount

`readonly double statEmitterCount`

Read-only: number of emitters found this frame.

### statTotalLive

`readonly double statTotalLive`

Read-only: total live particles drawn this frame across all emitters.

### statBuildMs

`readonly double statBuildMs`

Read-only: milliseconds spent evaluating particles this frame.

### statDrawMs

`readonly double statDrawMs`

Read-only: milliseconds spent drawing particles this frame.
