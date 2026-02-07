using extgen.Config;
using System.Text.Json.Serialization;

namespace extgen.Config.Targets.Consoles
{
    // ============================================================
    // Xbox targets (GDK)
    // ============================================================

    public sealed class XboxTargetConfig : GeneratorConfigBase
    {
        [JsonPropertyName("outputFolder")]
        public override string OutputFolder { get; set; } = "../";
    }
}
