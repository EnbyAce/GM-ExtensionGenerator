using System.Text.Json.Serialization;

namespace extgen.Models.Config.GameMaker
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum YyMode
    {
        [JsonStringEnumMemberName("plain")] Plain,
        [JsonStringEnumMemberName("patch")] Patch
    }
}
