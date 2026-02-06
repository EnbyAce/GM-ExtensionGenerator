using extgen.Config.Extras;
using extgen.Config.Utils;

namespace extgen.Emitters.Doc
{
    public class DocEmitterOptions : IFromConfig<DocEmitterOptions, DocsConfig>
    {
        public string OutputFolder { get; set; } = "./";

        public string OutputFilename { get; set; } = "documentation";

        public static DocEmitterOptions FromConfig(DocsConfig targetOptions)
        {
            return new DocEmitterOptions() { OutputFilename = targetOptions.OutputFileName, OutputFolder = targetOptions.OutputFolder };
        }
    }
}
