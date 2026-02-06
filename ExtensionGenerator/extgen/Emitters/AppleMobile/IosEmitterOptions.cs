using extgen.Config.Targets.Mobile;
using extgen.Config.Utils;

namespace extgen.Emitters.AppleMobile
{
    public sealed class IosEmitterOptions : IAppleMobileEmitterOptions, IFromConfig<IosEmitterOptions, IosTargetConfig>
    {
        public bool Enabled { get; set; } = true;
        public string SourceFolder { get; set; } = "./ios";
        public string SourceFilename { get; set; } = "{0}_ios";
        public string OutputFolder { get; set; } = "../iOSSourceFromMac";

        public string Platform => "ios";

        public static IosEmitterOptions FromConfig(IosTargetConfig targetOptions)
        {
            return new IosEmitterOptions() { OutputFolder = targetOptions.OutputFolder, SourceFilename = targetOptions.SourceFilename, SourceFolder = targetOptions.SourceFolder };
        }
    }
}
