using System.Collections.Immutable;

namespace codegencore.Ir
{
    public sealed record IrEnum(string Name, IrType Underlying, ImmutableArray<IrEnumMember> Members, string? Description = null);
}
