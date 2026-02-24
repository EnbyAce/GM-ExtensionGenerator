using System.Text.Json.Serialization;

namespace extgen.Models.Config.GameMaker
{
    
    public sealed class YyConfig : IGeneratorConfig
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonPropertyName("outputFile")]
        public string OutputFile { get; set; } = "./extension.yy";

        [JsonPropertyName("mode"), JsonRequired()]
        public YyMode Mode { get; set; } = YyMode.Patch;

        [JsonPropertyName("extensionName")]
        public string? ExtensionName { get; set; } = null;

        [JsonPropertyName("extensionFileName")]
        public string? ExtensionFileName { get; set; } = null;

        [JsonPropertyName("patchFrameworks")]
        public bool PatchFrameworks { get; set; } = false;
    }
}
