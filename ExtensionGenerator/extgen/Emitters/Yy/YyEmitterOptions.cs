using extgen.Config.Gml;
using extgen.Config.Utils;
using System.Text.Json.Serialization;

namespace extgen.Emitters.Yy
{
    public sealed class YyEmitterOptions : IFromConfig<YyEmitterOptions, GmlConfig>
    {
        public required string OutputFile { get; set; }

        public static YyEmitterOptions FromConfig(GmlConfig options)
        {
            return new YyEmitterOptions() { OutputFile = options.DeclarationsFile };
        }
    }
}
