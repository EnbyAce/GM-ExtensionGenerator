using codegencore.Model;
using extgen.Model;

namespace extgen.TypeSystem
{
    /// <summary>
    /// Cross-language mapping from IrType -> language-specific type name.
    /// </summary>
    public interface IIrTypeMap
    {
        /// <summary>
        /// Map a type for general usage (parameters, fields).
        /// </summary>
        string Map(IrType t, bool owned = false);

        string MapPassType(IrType type, bool owned = false);
    }
}
