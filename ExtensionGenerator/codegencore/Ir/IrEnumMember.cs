namespace codegencore.Ir
{
    public sealed record IrEnumMember(string Name, string? DefaultLiteral, string? Description = null);
}
