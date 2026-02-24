
namespace extgen.Emitters.Gml
{
    public enum GmlEmitterMode { Wrapper, Runtime }

    public sealed class GmlEmitterSettings
    {
        public required GmlEmitterMode Mode { get; set; }

        public required string OutputFile { get; set; }
    }
}
