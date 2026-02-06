using System.Text.Json.Serialization;

namespace extgen.Config
{
    public interface IGeneratorConfig
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}
