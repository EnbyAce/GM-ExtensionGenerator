using extgen.Config;
using extgen.Config.Build;
using extgen.Config.Targets.Mobile;

internal sealed class EmitterPlan
{
    public required ExtGenConfig Cfg { get; init; }

    public bool HasWindows => Cfg.Targets.Windows?.Enabled == true;
    public bool HasMac => Cfg.Targets.MacOS?.Enabled == true;
    public bool HasLinux => Cfg.Targets.Linux?.Enabled == true;

    public bool HasXbox => Cfg.Targets.Xbox?.Enabled == true;
    public bool HasPs4 => Cfg.Targets.Ps4?.Enabled == true;
    public bool HasPs5 => Cfg.Targets.Ps5?.Enabled == true;
    public bool HasSwitch => Cfg.Targets.Switch?.Enabled == true;

    public bool AndroidEnabled => Cfg.Targets.Android?.Enabled == true;
    public bool IosEnabled => Cfg.Targets.Ios?.Enabled == true;
    public bool TvosEnabled => Cfg.Targets.Tvos?.Enabled == true;

    public AndroidMode AndroidMode => Cfg.Targets.Android?.Mode ?? AndroidMode.Java;
    public AppleMobileMode IosMode => Cfg.Targets.Ios?.Mode ?? AppleMobileMode.Objc;
    public AppleMobileMode TvosMode => Cfg.Targets.Tvos?.Mode ?? AppleMobileMode.Objc;

    public bool AllowBindings => Cfg.Profile is BuildProfile.Full or BuildProfile.BindingsOnly;
    public bool AllowBuild => Cfg.Profile is BuildProfile.Full or BuildProfile.BuildOnly;

    public bool NeedsCpp =>
        HasWindows || HasMac || HasLinux ||
        HasXbox || HasPs4 || HasPs5 || HasSwitch ||
        (AndroidEnabled && AndroidMode == AndroidMode.Jni) ||
        (IosEnabled && IosMode == AppleMobileMode.Native) ||
        (TvosEnabled && TvosMode == AppleMobileMode.Native);

    // Useful to enforce "target driven" expectations
    public void Validate()
    {
        // Example rule: no iOS/tvOS without AppleMobile target block
        // (you can add stricter checks as you like)

        if (AndroidEnabled && Cfg.Targets.Android is null)
            throw new InvalidOperationException("Android target is enabled but cfg.Targets.Android is null.");

        if (IosEnabled && Cfg.Targets.Ios is null)
            throw new InvalidOperationException("iOS target is enabled but cfg.Targets.Ios is null.");

        if (TvosEnabled && Cfg.Targets.Tvos is null)
            throw new InvalidOperationException("tvOS target is enabled but cfg.Targets.Tvos is null.");
    }
}
