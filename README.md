# Particles

A **free** FlexSim 2026 module that adds standalone *particle-emitter* objects —
purely visual effects (smoke, steam, dust, sparks, spray) drawn in the 3D view.

## Design goal: never slow the simulation

FlexSim is a discrete-event simulator that can fast-forward past hundreds of
thousands of frames. Particles here add **zero events** to the simulation queue.
Instead, every particle's position/color/size is an **analytic function of model
time `T`** — the same idea as FlexSim kinematics. All particle work happens
inside the object's draw call; when a draw occurs after the model has jumped far
ahead, the emitter computes exactly the particles that should be alive at the
current time, in closed form. Skipping frames costs nothing.

This makes the visuals essentially free for the simulation: the only cost is per
*repaint*, bounded by the viewport, never by simulated time.

## What it does

- Standalone `ParticleEmitter` 3D object (attach-to-other-objects is a future
  addition; the data model is ready for it).
- Emitter shapes: point, cone, sphere, disk, line.
- Closed-form motion: ballistic, gravity, exponential drag, wind, swirl.
- Appearance over life: color gradient, alpha fade, size curve.
- Two render paths: cheap `GL_POINTS` (sparks/dust) and textured **billboard
  sprites** (smoke/steam/glow). Default textures included in `bitmaps/`.
- Built-in instrumentation: per-emitter live count + build/draw timing
  (`statLiveCount`/`statBuildMs`/`statDrawMs`), a `Particles_stressTest`
  benchmark, and a graceful per-emitter live-particle cap (`Particles_setCap`).

## Architecture

A FlexSim-free analytic core (unit-tested standalone) plus a thin FlexSim object:

- `pmath.h`, `prng.h` — math + deterministic per-particle RNG.
- `EmitterSpec.h` — declarative emitter parameters.
- `ParticleEvaluator.{h,cpp}` — pure math: live-range, initial conditions,
  motion, appearance, `evaluate()`. No FlexSim, no OpenGL.
- `ParticleEmitter.{h,cpp}` — `FlexSimEventHandler` object; `onDraw` calls the
  evaluator at `time()` and renders one reused `Mesh`.
- `module.cpp` — DLL entry, object factory, FlexScript commands.

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

The DLL is independent of the FlexSim-side library. To expose the object and its
GUI, author `Particles.fsx` — see [docs/FSX-AUTHORING.md](docs/FSX-AUTHORING.md).

## License

Free / MIT (see `LICENSE.txt`).
