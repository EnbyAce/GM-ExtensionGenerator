
namespace extgen.Emitters.AppleMobile.Objc
{
    internal sealed class ObjcLayout
    {
        public string CoreDir { get; }
        public string CodeGenDir { get; }
        public string SourceDir { get; }
        public string OutputSource { get; }

        public ObjcLayout(string root, IAppleMobileEmitterSettings settings)
        {
            CoreDir = Path.GetFullPath(Path.Combine($"./code_gen/core"), root);
            CodeGenDir = Path.GetFullPath(Path.Combine($"./code_gen/{settings.Platform}"), root);
            SourceDir = Path.GetFullPath(Path.Combine($"./src/{settings.SourceFolder}"), root);
            OutputSource = Path.GetFullPath(settings.OutputSourceFolder, root);

            if (Directory.Exists(CodeGenDir)) Directory.Delete(CodeGenDir, true);

            Directory.CreateDirectory(CoreDir);
            Directory.CreateDirectory(CodeGenDir);
            Directory.CreateDirectory(SourceDir);
        }
    }
}
