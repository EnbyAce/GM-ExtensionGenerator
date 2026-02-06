using System.Text.Json.Serialization;

namespace extgen.Config.Extras
{
    // ============================================================
    // Extras (never required; purely optional)
    // ============================================================

    public sealed class ExtrasConfig
    {
        [JsonPropertyName("docs")] public DocsConfig? Docs { get; set; }
    }
}
