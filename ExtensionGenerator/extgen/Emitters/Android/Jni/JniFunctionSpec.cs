using extgen.Emitters.Utils;

namespace extgen.Emitters.Android.Jni
{
    internal sealed record JniFunctionSpec(
        string Name,
        string ExportName,
        string NativeName,
        IEnumerable<ExportParam> ExportParams,
        ExportType ExportReturnType
    );
}
