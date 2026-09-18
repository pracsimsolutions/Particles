---
title: Welcome to Particles
summary: Visual particle emitters for FlexSim (smoke, sparks and fountains) that add zero events to the simulation.
order: 1
---

Visual particle emitters (smoke, sparks, fountains) drawn analytically at draw time so they add zero events to the simulation. Drop a [Particles.Emitter](api/Particles.Emitter.md) from the library; the [Particles.System](api/Particles.System.md) is created automatically.

```flexscript
Particles.System sys = Particles.system;
Particles.Emitter e = Model.find("ParticleEmitter1");
```

## Where to next

- [Particle Emitter Properties](panels/emitter-panel.md): the fields on an emitter's Quick Properties pane.
- [Particle System Properties](panels/system-panel.md): the model-wide display and level-of-detail settings.
- [Particles.Emitter](api/Particles.Emitter.md): every emitter property as a scripted property, with a code example.
- [Particles](api/Particles.md): the module namespace and the accessor for the one system per model.
- [What's New](whats-new.md): release notes.
