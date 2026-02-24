namespace extgen.Emitters.CppInjectors
{
    public sealed class CppInjectorsEmitterSettings
    {
        public required string OutputFolder { get; set; } // relative to rc.OutputDir
        public string? ExtensionName { get; internal set; }
        public string? ExtensionFileName { get; internal set; }
    }
}