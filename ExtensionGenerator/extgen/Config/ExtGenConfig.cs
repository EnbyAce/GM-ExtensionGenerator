using extgen.Config.Build;
using extgen.Config.Extras;
using extgen.Config.Gml;
using extgen.Config.Targets;
using System.Text.Json.Serialization;

namespace extgen.Config
{
    public sealed class ExtGenConfig
    {
        [JsonPropertyName("$schema")]
        public string? Schema { get; set; }

        [JsonPropertyName("input")]
        public string? Input { get; set; }

        [JsonPropertyName("root")]
        public string? Root { get; set; }

        [JsonPropertyName("profile")]
        public BuildProfile Profile { get; set; } = BuildProfile.Full;

        [JsonPropertyName("gml")] public GmlConfig Gml { get; set; } = new GmlConfig();

        [JsonPropertyName("targets")]
        public TargetsConfig Targets { get; set; } = new();

        [JsonPropertyName("extras")]
        public ExtrasConfig Extras { get; set; } = new();

        [JsonPropertyName("build")]
        public BuildConfig Build { get; set; } = new();

        [JsonPropertyName("runtime"), JsonIgnore()]
        public RuntimeNaming Runtime { get; set; } = new();
    }
}
