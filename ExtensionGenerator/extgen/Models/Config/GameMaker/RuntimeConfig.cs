using System.Text.Json.Serialization;

namespace extgen.Models.Config.GameMaker
{

    public sealed class RuntimeConfig : IGeneratorConfig
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonPropertyName("outputFile")]
        public string OutputFile { get; set; } = "./runtime.gml";
    }
}
