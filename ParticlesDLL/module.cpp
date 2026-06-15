// PracSim Particles — module DLL entry points.

#include "FlexsimDefs.h"
#include "allobjects.h"

visible void dllinitialize() {
}

namespace Particles {

// Smoke-test export so we can confirm the DLL loads and FlexScript can reach it.
// Bound from Particles.fsx via:  dll:"module:Particles" func:"Particles_ping"
__declspec(dllexport) Variant Particles_ping(FLEXSIMINTERFACE)
{
	return 1;
}

}  // namespace Particles
