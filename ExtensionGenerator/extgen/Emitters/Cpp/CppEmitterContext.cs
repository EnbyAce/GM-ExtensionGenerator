using extgen.Config;
using extgen.Emitters.Utils;

namespace extgen.Emitters.Cpp
{
    internal sealed record CppEmitterContext(string ExtName, CppEmitterOptions Options, RuntimeNaming Runtime) : IEmitterContext<CppEmitterOptions>;
}
