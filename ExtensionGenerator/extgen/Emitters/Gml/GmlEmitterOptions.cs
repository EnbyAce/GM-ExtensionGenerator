using extgen.Config.Gml;
using extgen.Config.Utils;
using System.Text.Json.Serialization;

namespace extgen.Emitters.Gml
{
    public sealed class GmlEmitterOptions : IFromConfig<GmlEmitterOptions, GmlConfig>
    {
        public bool EmitRuntime { get; set; }

        public required string OutputFile { get; set; }

        public required string RuntimeFile { get; set; }

        public static GmlEmitterOptions FromConfig(GmlConfig options)
        {
            return new GmlEmitterOptions() { OutputFile = options.OutputFile, RuntimeFile = options.RuntimeFile, EmitRuntime = options.EmitRuntime };
        }
    }
}
