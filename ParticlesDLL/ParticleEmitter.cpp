#include "ParticleEmitter.h"
#include <algorithm>

namespace Particles {

void ParticleEmitter::bindVariables() {
    bindVariable(rate); bindVariable(lifetime); bindVariable(lifetimeJitter);
    bindVariable(startTime); bindVariable(stopTimeField);
    bindVariable(shapeField); bindVariable(coneHalfAngleDeg); bindVariable(shapeSize);
    bindVariable(speed); bindVariable(speedJitter);
    bindVariable(gravX); bindVariable(gravY); bindVariable(gravZ);
    bindVariable(drag); bindVariable(windX); bindVariable(windY); bindVariable(windZ);
    bindVariable(swirlAmp); bindVariable(swirlFreq);
    bindVariable(sizeStart); bindVariable(sizeEnd); bindVariable(alphaStart); bindVariable(alphaEnd);
    bindVariable(colorStartR); bindVariable(colorStartG); bindVariable(colorStartB);
    bindVariable(colorEndR); bindVariable(colorEndG); bindVariable(colorEndB);
    bindVariable(styleField); bindVariable(textureIndex); bindVariable(seedField);
    bindVariable(statLiveCount);
}

EmitterSpec ParticleEmitter::buildSpec() const {
    EmitterSpec s;
    s.rate = (float)std::max(1e-4, rate);
    s.lifetime = (float)lifetime; s.lifetimeJitter = (float)lifetimeJitter;
    s.startTime = (float)startTime;
    s.stopTime = stopTimeField > 0 ? (float)stopTimeField : 1e30f;
    s.shape = (EmitShape)(int)shapeField;
    s.coneHalfAngleDeg = (float)coneHalfAngleDeg; s.shapeSize = (float)shapeSize;
    s.speed = (float)speed; s.speedJitter = (float)speedJitter;
    s.gravity = { (float)gravX, (float)gravY, (float)gravZ };
    s.drag = (float)drag; s.wind = { (float)windX, (float)windY, (float)windZ };
    s.swirlAmp = (float)swirlAmp; s.swirlFreq = (float)swirlFreq;
    s.sizeStart = (float)sizeStart; s.sizeEnd = (float)sizeEnd;
    s.alphaStart = (float)alphaStart; s.alphaEnd = (float)alphaEnd;
    s.colorStops.count = 2;
    s.colorStops.stops[0] = { 0.0f, rgba{(float)colorStartR,(float)colorStartG,(float)colorStartB,1} };
    s.colorStops.stops[1] = { 1.0f, rgba{(float)colorEndR,(float)colorEndG,(float)colorEndB,1} };
    s.style = (RenderStyle)(int)styleField;
    s.seed = (uint32_t)seedField;
    return s;
}

}  // namespace Particles
