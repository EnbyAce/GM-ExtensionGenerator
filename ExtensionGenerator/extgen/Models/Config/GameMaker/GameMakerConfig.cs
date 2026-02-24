using System.Runtime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace extgen.Models.Config.GameMaker
{
    public sealed class GameMakerConfig
    {
        [JsonPropertyName("wrappers")]
        public WrapperConfig? Wrappers { get; set; }

        [JsonPropertyName("runtime")]
        public RuntimeConfig? Runtime { get; set; }

        [JsonPropertyName("extension")]
        public ExtensionConfig? Extension { get; set; }

        [JsonPropertyName("injectors")]
        public InjectorsConfig? Injectors { get; set; }
    }
}
