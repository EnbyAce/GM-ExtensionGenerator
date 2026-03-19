import Foundation

@objcMembers
public final class gm: NSObject {

    @objcMembers
    public final class ExtUtils: NSObject {

        /// Swift-facing wrapper that mirrors the C++ API shape:
        ///   gm.ExtUtils.getExtensionOption(...)
        public static func getExtensionOption(_ extName: String,
                                              optionName optName: String) -> String? {
            GMExtUtilsBridge.getExtensionOption(extName, optionName: optName)
        }
    }
}