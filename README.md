# Particles

A **free** FlexSim 2026 module that adds standalone *particle-emitter* objects:
purely visual effects (smoke, steam, dust, sparks, spray) drawn in the 3D view.

## Design goal: never slow the simulation

FlexSim is a discrete-event simulator that can fast-forward past hundreds of
thousands of frames. Particles here add **zero events** to the simulation queue.
Instead, every particle's position/color/size is an **analytic function of model
time `T`**, the same idea as FlexSim kinematics. All particle work happens
inside the object's draw call; when a draw occurs after the model has jumped far
ahead, the emitter computes exactly the particles that should be alive at the
current time, in closed form. Skipping frames costs nothing.

This makes the visuals essentially free for the simulation: the only cost is per
*repaint*, bounded by the viewport, never by simulated time.

## What it does

- Placeable `ParticleEmitter` objects. Drop one or many; a singleton
  `ParticleSystem` is created automatically and **batch-draws all of them**.
- Emitter region shapes: point, line, disk, plane, box, sphere. Each emitter's
  world position + rotation is baked into the batch.
- Closed-form motion: ballistic, gravity, exponential drag, wind, swirl.
- Appearance over life: color gradient, alpha fade, size curve.
- Two render paths: cheap `GL_POINTS` (sparks/dust) and textured **billboard
  sprites**, flat quads that always face the camera (smoke/steam/glow). Default
  textures included in `bitmaps/`.
- Built-in instrumentation: per-emitter live count (`statLiveCount`) and
  system aggregates (`statEmitterCount`/`statTotalLive`/`statBuildMs`/
  `statDrawMs`), a `Particles_stressTest` benchmark, and a graceful
  per-emitter live cap (`Particles.system.liveCap`).

## Architecture

A FlexSim-free analytic core (unit-tested standalone) plus a thin FlexSim layer
split into a **System (draws) + Emitters (data)** so that N emitters cost only a
handful of draw calls (one `GL_POINTS` batch for all point emitters plus one
`GL_TRIANGLES` batch per sprite texture) instead of one draw per emitter.

- `pmath.h`, `prng.h`: math, deterministic per-particle RNG, and the
  local-to-world transform used to bake each emitter into the shared batch.
- `EmitterSpec.h`: declarative emitter parameters.
- `ParticleEvaluator.{h,cpp}`: pure math (live-range, initial conditions,
  motion, appearance, `evaluate()`). No FlexSim, no OpenGL.
- `ParticleEmitter.{h,cpp}`: a `FlexSimObject` placeable handle that holds the
  spec and registers with the system on create. Does not draw.
- `ParticleSystem.{h,cpp}`: a `FlexSimEventHandler` singleton whose `onDraw`
  evaluates every emitter at `time()`, bakes transforms, and issues the batched draws.
- `module.cpp`: DLL entry, object factory (both classes), FlexScript commands.

## Build

Requires Visual Studio 2022 (v143) and an installed FlexSim 2026 (the SDK headers
and libs are staged automatically from `../../program/system` by `copyheaders.bat`).

```
# Build the module DLL (produces Particles.dll at the module root)
MSBuild ParticlesDLL\ParticlesDLL.sln /p:Configuration=Release /p:Platform=x64
```

## Tests

The analytic core has a standalone test executable (no FlexSim needed):

```
MSBuild ParticlesDLL\tests\ParticlesTests.vcxproj /p:Configuration=Debug /p:Platform=x64
ParticlesDLL\tests\x64\Debug\ParticlesTests.exe
```

Covers the deterministic RNG, closed-form live-range, per-shape initial
conditions, motion formulas, appearance curves, capacity safety, a throughput
benchmark, and the **frame-skip invariance** proof (the scene at time `T` is
identical regardless of draw history).

## Using it in FlexSim

No build is required to use it. The repo ships the prebuilt `Particles.dll`
alongside `Particles.fsx` and the `bitmaps/` textures. Copy the whole `Particles`
folder into your FlexSim 2026 `modules/` directory and restart FlexSim; the
**Particles** group then appears in the library. Drag a **ParticleEmitter** into
the 3D view and edit it in Quick Properties.

A FlexScript API reference for the `Particles.*` classes (System, Emitter, Color,
Vec3, Shape, Direction, Style) is built in: in-editor autocomplete shows each
property's docs, and the full pages are under **Help > Modules > Particles >
FlexScript API Reference**.

## License

Free / MIT (see `LICENSE.txt`).

## Contact

Questions, bugs, or feature requests: **josh@pracsimsolutions.com**.
