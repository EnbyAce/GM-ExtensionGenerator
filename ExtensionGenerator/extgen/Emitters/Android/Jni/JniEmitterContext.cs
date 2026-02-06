using extgen.Config;
using extgen.Emitters.Utils;
using extgen.Options.Android;

namespace extgen.Emitters.Android.Jni
{
    internal sealed record JniEmitterContext(string ExtName, AndroidEmitterOptions Options, RuntimeNaming Runtime) : IEmitterContext<AndroidEmitterOptions>
    {
        public string BridgeClass => $"{ExtName}Bridge";
        public string BridgePackageUnderscore => Runtime.BridgePackage.Replace('.', '_');
        public string LibraryName => string.Format(Runtime.LibraryNameFormat, ExtName);
    }
}
