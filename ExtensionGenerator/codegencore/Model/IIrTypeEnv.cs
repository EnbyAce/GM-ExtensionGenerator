namespace codegencore.Model
{
    public interface IIrTypeEnv
    {
        bool TryResolveNamed(string name, out IrNamedTypeInfo namedType);
    }
}