using extgen.Bridge.Objc;
using extgen.Config;
using extgen.Emitters.AppleMobile;
using extgen.Model;
using extgen.Model.Utils;
using extgen.TypeSystem.Objc;

namespace extgen.Emitters.AppleMobile.Objc
{
    public sealed class ObjcEmitter(IAppleMobileEmitterOptions options, RuntimeNaming runtime) : IIrEmitter
    {
        private readonly ObjcTypeMap typeMap = new(runtime);

        public void Emit(IrCompilation comp, string dir)
        {
            ObjcEmitterContext ctx = new(comp.Name, options, runtime);
            ObjcLayout layout = new(dir, options);

            EmitAll(ctx, comp, layout);
        }

        private void EmitAll(ObjcEmitterContext ctx, IrCompilation c, ObjcLayout layout)
        {
            var enums = new IrTypeEnumResolver(c.Enums);
            ObjcBridge bridge = new(enums);

            ObjcCommonEmitter common = new(ctx, typeMap, bridge);
            common.EmitInternal(c, layout);
            common.EmitObjcUserShell(c, layout);
        }
    }
}
