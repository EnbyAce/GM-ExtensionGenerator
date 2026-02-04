using extgen.Options;

namespace extgen.Emitters.GmlRuntime
{
    internal sealed class GmlRuntimeLayout
    {
        public string OutputFile { get; }
        public string OutputFolder { get; }

        public GmlRuntimeLayout(string root, GmlRuntimeEmitterOptions options)
        {
            var fullpath = Path.GetFullPath(options.OutputFile, root);

            if (!File.Exists(fullpath))
                throw new ArgumentException($"GML Emitter: output file path doesn't exist ({fullpath}).");

            OutputFile = Path.GetFileNameWithoutExtension(fullpath);
            OutputFolder = Path.GetDirectoryName(fullpath) ?? root;
        }
    }
}
