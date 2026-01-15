using codegencore.Ir;
using System.Collections.Immutable;

namespace extgen.Ir
{
    public sealed record IrCompilation(string Name, ImmutableArray<IrEnum> Enums, ImmutableArray<IrStruct> Structs, ImmutableArray<IrFunction> Functions, ImmutableArray<IrConstant> Constants);

}
