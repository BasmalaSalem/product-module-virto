using VirtoCommerce.Platform.Core.Settings;

namespace BaseProductModule.Core;

public static class ModuleConstants
{
    public static class Security
    {
        public static class Permissions
        {
            public const string Access = "ProductModule:access";
            public const string Create = "ProductModule:create";
            public const string Read = "ProductModule:read";
            public const string Update = "ProductModule:update";
            public const string Delete = "ProductModule:delete";

            public static string[] AllPermissions { get; } =
            {
                Access,
                Create,
                Read,
                Update,
                Delete,
            };
        }
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor ProductModuleEnabled { get; } = new()
            {
                Name = "ProductModule.ProductModuleEnabled",
                GroupName = "ProductModule|General",
                ValueType = SettingValueType.Boolean,
                DefaultValue = false,
            };

            public static SettingDescriptor ProductModulePassword { get; } = new()
            {
                Name = "ProductModule.ProductModulePassword",
                GroupName = "ProductModule|Advanced",
                ValueType = SettingValueType.SecureString,
                DefaultValue = "P@ssw0rd",
            };

            public static IEnumerable<SettingDescriptor> AllGeneralSettings
            {
                get
                {
                    yield return ProductModuleEnabled;
                    yield return ProductModulePassword;
                }
            }
        }

        public static IEnumerable<SettingDescriptor> AllSettings
        {
            get
            {
                return General.AllGeneralSettings;
            }
        }
    }
}
