using extgen.Models.Config.Build;
using extgen.Models.Config.Extras;
using extgen.Models.Config.GameMaker;
using extgen.Models.Config.Targets;
using System.Text.Json.Serialization;

namespace extgen.Models.Config
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

        [JsonPropertyName("gamemaker")] public GameMakerConfig GameMaker { get; set; } = new GameMakerConfig();

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
