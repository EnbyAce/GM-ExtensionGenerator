namespace extgen.Emitters.Gml
{
    internal sealed class GmlLayout
    {
        public string OutputFile { get; }
        public string OutputFolder { get; }

        public GmlLayout(string root, GmlEmitterSettings options)
        {
            var output = Path.GetFullPath(options.OutputFile, root);
            OutputFile = Path.GetFileNameWithoutExtension(output);
            OutputFolder = Path.GetDirectoryName(output) ?? root;

        }
    }
}
