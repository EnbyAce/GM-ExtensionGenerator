using extgen.Config;
using extgen.Config.Targets.Mobile;
using extgen.Config.Utils;

namespace extgen.Options.Android
{
    public sealed class AndroidEmitterOptions : IGeneratorConfig, IFromConfig<AndroidEmitterOptions, AndroidTargetConfig>
    {
        public bool Enabled { get; set; } = true;
        public AndroidMode Mode { get; set; } = AndroidMode.Java;
        public string OutputFolder { get; set; } = "../AndroidSource";

        public string OutputNativeFolder => "./code_gen/android";

        public static AndroidEmitterOptions FromConfig(AndroidTargetConfig targetOptions)
        {
            return new AndroidEmitterOptions() { OutputFolder = targetOptions.OutputFolder };
        }
    }
}
