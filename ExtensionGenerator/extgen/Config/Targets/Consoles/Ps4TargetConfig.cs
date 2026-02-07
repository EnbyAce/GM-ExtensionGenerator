using extgen.Config;
using System.Text.Json.Serialization;

namespace extgen.Config.Targets.Consoles
{
    // ============================================================
    // PlayStation targets
    // ============================================================

    public sealed class Ps4TargetConfig : GeneratorConfigBase
    {
        [JsonPropertyName("outputFolder")]
        public override string OutputFolder { get; set; } = "../";
    }
}
