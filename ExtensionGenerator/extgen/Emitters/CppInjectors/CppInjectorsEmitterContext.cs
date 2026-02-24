using extgen.Emitters.Cpp;
using extgen.Emitters.Utils;
using extgen.Models;
using extgen.Models.Config;

namespace extgen.Emitters.CppInjectors
{
    internal sealed record CppInjectorsEmitterContext(
        IrCompilation Compilation,
        CppInjectorsEmitterSettings Settings,
        RuntimeNaming Runtime,
        IReadOnlyList<IrFunction> StartFunctions,
        IReadOnlyList<IrFunction> FinishFunctions
    // add more later: Groups, NativeNames, Runtime symbols, etc
    ) : IEmitterContext<CppInjectorsEmitterSettings>
    {
        public string ExtName => Compilation.Name;
    }
}