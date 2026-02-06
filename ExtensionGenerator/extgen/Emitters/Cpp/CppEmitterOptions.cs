using System.Text.Json.Serialization;

namespace extgen.Emitters.Cpp
{
    public sealed class CppEmitterOptions
    {
        public required string SourceFolder { get; set; }

        public required string SourceFilename { get; set; }
    }
}
