using codegencore.Model;
using System.Collections.Immutable;

namespace extgen.Model
{
    public sealed record IrFunction(string Name, IrType ReturnType, ImmutableArray<IrParameter> Parameters);

}
