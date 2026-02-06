using extgen.Config;
using System.Text.Json.Serialization;

namespace extgen.Config.Extras
{
    public sealed class DocsConfig : GeneratorConfigBase
    {
        public override string OutputFolder { get; set; } = "./";

        [JsonPropertyName("outputFileName")] public string OutputFileName { get; set; } = "documentation";

        /// <summary>If true, overwrite existing files. If false, try to be additive.</summary>
        [JsonPropertyName("overwrite")] public bool Overwrite { get; set; } = true;
    }
}
