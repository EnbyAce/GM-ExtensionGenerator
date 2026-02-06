using extgen.Config;
using extgen.Emitters.AppleMobile;
using extgen.Emitters.Utils;

namespace extgen.Emitters.AppleMobile.Objc
{
    internal sealed record ObjcEmitterContext(string ExtName, IAppleMobileEmitterOptions Options, RuntimeNaming Runtime) : IEmitterContext<IAppleMobileEmitterOptions>;
}
