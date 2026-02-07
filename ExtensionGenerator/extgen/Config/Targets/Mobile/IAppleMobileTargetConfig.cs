using System.Text.Json.Serialization;

namespace extgen.Config.Targets.Mobile
{
    // ============================================================
    // Apple Mobile targets (iOS/tvOS)
    // ============================================================

    public interface IAppleMobileTargetConfig : IGeneratorConfig
    {
        [JsonPropertyName("mode"), JsonRequired()]
        public AppleMobileMode Mode { get; set; }
    }
}
