using extgen.Config;

namespace extgen.Emitters.AppleMobile
{
    public interface IAppleMobileEmitterOptions : IGeneratorConfig
    {
        public string Platform { get; }

        public string SourceFolder { get; set; }

        public string SourceFilename { get; set; }
    }
}
