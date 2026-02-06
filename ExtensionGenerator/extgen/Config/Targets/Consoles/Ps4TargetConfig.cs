using extgen.Config;

namespace extgen.Config.Targets.Consoles
{
    // ============================================================
    // PlayStation targets
    // ============================================================

    public sealed class Ps4TargetConfig : GeneratorConfigBase
    {
        public override string OutputFolder { get; set; } = "../";
    }
}
