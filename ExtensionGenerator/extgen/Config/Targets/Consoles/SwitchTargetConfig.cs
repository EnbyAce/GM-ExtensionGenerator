using extgen.Config;
using System.Text.Json.Serialization;

namespace extgen.Config.Targets.Consoles
{
    // ============================================================
    // Switch target
    // ============================================================

    public sealed class SwitchTargetConfig : GeneratorConfigBase
    {
        /// <summary>
        /// Switch builds commonly depend on importing a user-provided MSBuild .props.
        /// You should never ship the props; users point to it.
        /// </summary>
        [JsonPropertyName("userProps")]
        public string? UserProps { get; set; }

        public override string OutputFolder { get; set; } = "../";
    }
}
