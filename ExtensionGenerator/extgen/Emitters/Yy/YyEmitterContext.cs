using extgen.Config;
using extgen.Emitters.Utils;

namespace extgen.Emitters.Yy;

internal sealed record YyEmitterContext(string ExtName, YyEmitterOptions Options, RuntimeNaming Runtime) : IEmitterContext<YyEmitterOptions>;
