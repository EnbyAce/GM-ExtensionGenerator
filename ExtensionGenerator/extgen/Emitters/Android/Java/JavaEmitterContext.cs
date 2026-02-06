using extgen.Config;
using extgen.Emitters.Utils;
using extgen.Options.Android;

namespace extgen.Emitters.Android.Java
{
    internal sealed record JavaEmitterContext(string ExtName, AndroidEmitterOptions Options, RuntimeNaming Runtime) : IEmitterContext<AndroidEmitterOptions>;
}
