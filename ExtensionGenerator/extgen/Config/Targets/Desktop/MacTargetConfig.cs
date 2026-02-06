using extgen.Config;
using System.Text.Json.Serialization;

namespace extgen.Config.Targets.Desktop
{
    public sealed class MacTargetConfig : GeneratorConfigBase
    {
        [JsonPropertyName("outputFolder")]
        public override string OutputFolder { get; set; } = "../";
    }
}
