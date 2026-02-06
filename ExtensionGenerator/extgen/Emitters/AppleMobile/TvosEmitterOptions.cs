using extgen.Config.Targets.Mobile;
using extgen.Config.Utils;

namespace extgen.Emitters.AppleMobile
{
    public sealed class TvosEmitterOptions : IAppleMobileEmitterOptions, IFromConfig<TvosEmitterOptions, TvosTargetConfig>
    {
        public bool Enabled { get; set; } = true;
        public string SourceFolder { get; set; } = "./tvos";
        public string SourceFilename { get; set; } = "{0}_tvos";
        public string OutputFolder { get; set; } = "../tvOSSourceFromMac";

        public string Platform => "tvos";

        public static TvosEmitterOptions FromConfig(TvosTargetConfig targetOptions)
        {
            return new TvosEmitterOptions() { OutputFolder = targetOptions.OutputFolder, SourceFilename = targetOptions.SourceFilename, SourceFolder = targetOptions.SourceFilename }; ;
        }
    }
}
