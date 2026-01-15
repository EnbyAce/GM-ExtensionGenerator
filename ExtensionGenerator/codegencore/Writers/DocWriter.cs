using codegencore.Ir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codegencore.Writers
{
    public class DocWriter(ICodeWriter io) : BaseWriter<DocWriter>(io)
    {
        public static string JsDocType(IrType t)
        {
            if (t.IsCollection)
            {
                var inner = t with { IsCollection = false };
                return $"Array[{JsDocType(inner)}]";
            }

            return t.Kind switch
            {
                IrTypeKind.Scalar when t.Name == "bool" => "Bool",
                IrTypeKind.Scalar when t.IsNumericScalar => "Real",
                IrTypeKind.Scalar when t.IsStringScalar => "String",
                IrTypeKind.Scalar => "Real",
                IrTypeKind.AnyArray => "Array",
                IrTypeKind.AnyMap => "Struct",
                IrTypeKind.Function => $"Function",
                IrTypeKind.Buffer => $"Id.Buffer",
                IrTypeKind.Struct => $"Struct.{t.Name}",
                IrTypeKind.Enum => $"Enum.{t.Name}",
                IrTypeKind.Variant => "Any",
                IrTypeKind.Void => throw new NotImplementedException(),
                _ => throw new NotImplementedException($"JSDoc conversion not implemented for type: {t}"),
            };
        }
    }
}
