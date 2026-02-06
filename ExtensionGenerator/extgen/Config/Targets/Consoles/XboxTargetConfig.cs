using extgen.Config;

namespace extgen.Config.Targets.Consoles
{
    // ============================================================
    // Xbox targets (GDK)
    // ============================================================

    public sealed class XboxTargetConfig : GeneratorConfigBase
    {
        public override string OutputFolder { get; set; } = "../";
    }
}
