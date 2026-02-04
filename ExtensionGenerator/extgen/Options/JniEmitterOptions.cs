using System.Text.Json.Serialization;

namespace extgen.Options
{
    public sealed class JniEmitterOptions
    {
        [JsonPropertyName("enabled")] public bool Enabled { get; set; } = true;

        [JsonPropertyName("outputFolder")]
        public string OutputFolder { get; set; } = "../AndroidSource/";

        public string OutputNativeFolder => "./code_gen/android";
    }
}
