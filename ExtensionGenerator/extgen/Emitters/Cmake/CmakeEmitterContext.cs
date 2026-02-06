using extgen.Config;
using extgen.Config.Build;
using extgen.Emitters.Utils;

namespace extgen.Emitters.Cmake
{
    internal sealed record CmakeEmitterContext(string ExtName, ExtGenConfig Config) : IEmitterContext<CmakeEmitterOptions> 
    {
        public CmakeEmitterOptions Options => Config.Build.Cmake;
        public RuntimeNaming Runtime => Config.Runtime;
    }
}
