using extgen.Config;
using extgen.Emitters.Utils;
using extgen.Options.Android;

namespace extgen.Emitters.Android.Kotlin
{
    internal record KotlinEmitterContext(string ExtName, AndroidEmitterOptions Options, RuntimeNaming Runtime) : IEmitterContext<AndroidEmitterOptions>;
}
