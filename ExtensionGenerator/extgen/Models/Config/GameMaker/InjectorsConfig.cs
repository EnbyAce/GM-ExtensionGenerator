using System.Text.Json.Serialization;

namespace extgen.Models.Config.GameMaker
{
    public sealed class InjectorsConfig : IGeneratorConfig
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonPropertyName("outputFolder")]
        public string OutputFolder { get; set; } = "../injections";
    }
}
