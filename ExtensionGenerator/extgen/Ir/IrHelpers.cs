using codegencore.Ir;

namespace extgen.Ir
{
    internal static class IrHelpers
    {
        /// <summary>
        /// For a collection type T[], List<T>, etc., return the element IrType.
        /// </summary>
        public static IrType Element(IrType t) =>
            t with { IsCollection = false, FixedLength = null };
    }
}
