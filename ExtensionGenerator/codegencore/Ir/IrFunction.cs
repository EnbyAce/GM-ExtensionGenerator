using System.Collections.Immutable;

namespace codegencore.Ir
{
    public sealed record IrFunction(string Name, IrType ReturnType, ImmutableArray<IrParameter> Parameters);

}
