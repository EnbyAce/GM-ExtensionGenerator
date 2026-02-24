using extgen.Emitters;
using extgen.Emitters.Cpp;
using extgen.Emitters.CppInjectors;
using extgen.Emitters.Doc;
using extgen.Emitters.Gml;
using extgen.Emitters.Yy;
using extgen.Mappers;
using extgen.Models.Config.GameMaker;
using extgen.Models.Config.Targets.Mobile;

namespace extgen.Planning
{
    public static class EmitterBuilder
    {
        public static Dictionary<string, IIrEmitter> Build(ResolvedConfig rc)
        {
            var emitters = new Dictionary<string, IIrEmitter>(StringComparer.OrdinalIgnoreCase);

            // Core C++ only if required
            if (rc.NeedsCpp)
            {
                var cppSettings = new CppEmitterSettings
                {
                    SourceFilename = rc.Raw.Targets.SourceFilename,
                    SourceFolder = rc.Raw.Targets.SourceFolder
                };
                emitters["cpp"] = new CppEmitter(cppSettings, rc.Raw.Runtime);
            }

            // Bindings (GML + YY are coupled)
            if (rc.AllowBindings)
            {
                if (rc.Raw.GameMaker.Wrappers is { Enabled: true } wrapperCfg)
                    emitters["gml"] = new GmlEmitter(wrapperCfg.ToSettings());

                if (rc.Raw.GameMaker.Runtime is { Enabled: true } runtimeCfg)
                    emitters["runtime"] = new GmlEmitter(runtimeCfg.ToSettings());

                if (rc.Raw.GameMaker.Extension is { Enabled: true } yyConfig)
                    emitters["extension"] = new YyEmitter(yyConfig.ToSettings(rc.AndroidEnabled, rc.IosEnabled, rc.TvosEnabled), rc.Raw.Runtime);

                if (rc.Raw.GameMaker.Injectors is { Enabled: true } injectorsCfg)
                {
                    ExtensionConfig extConfig = rc.Raw.GameMaker.Extension ?? new();
                    emitters["injectors"] = new CppInjectorsEmitter(injectorsCfg.ToSettings(extConfig), rc.Raw.Runtime);
                }


            }

            // Android
            if (rc.Raw.Targets.Android is AndroidTargetConfig { Enabled: true } androidCfg)
            {
                emitters["android"] = AndroidEmitterFactory.Create(rc, androidCfg);
            }

            // iOS
            if (rc.Raw.Targets.Ios is IosTargetConfig { Enabled: true } iosCfg)
            {
                emitters["ios"] = AppleEmitterFactory.CreateIos(rc, iosCfg);
            }

            // tvOS
            if (rc.Raw.Targets.Tvos is TvosTargetConfig { Enabled: true } tvosCfg)
            {
                emitters["tvos"] = AppleEmitterFactory.CreateTvos(rc, tvosCfg);
            }

            // Docs (extras)
            if (rc.Raw.Extras.Docs is { Enabled: true } d)
            {
                emitters["docs"] = new DocEmitter(d.ToSettings(), rc.Raw.Runtime);
            }

            return emitters;
        }
    }
}
