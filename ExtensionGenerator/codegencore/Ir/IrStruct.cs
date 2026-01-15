using System.Collections.Immutable;

namespace codegencore.Ir
{
    public sealed record IrStruct(string Name, ImmutableArray<IrField> Fields, string? Description = null);
}
