using System;
using System.Linq;

namespace MahApps.Metro.IconPacks.Browser
{
    public static class PathHelper
    {
        public static string GetTypeFromString(string type, string name)
        {
            switch (type)
            {
                case "PackIconBoxIcons":
                    {
                        var factory = PackIconBoxIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconEntypo":
                    {
                        var factory = PackIconBoxIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconEvaIcons":
                    {
                        var factory = PackIconEvaIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconFeatherIcons":
                    {
                        var factory = PackIconFeatherIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconFontAwesome":
                    {
                        var factory = PackIconFontAwesomeDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconIonicons":
                    {
                        var factory = PackIconIoniconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconJamIcons":
                    {
                        var factory = PackIconJamIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconMaterial":
                    {
                        var factory = PackIconMaterialDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconMaterialDesign":
                    {
                        var factory = PackIconMaterialDesignDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconMaterialLight":
                    {
                        var factory = PackIconMaterialLightDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconMicrons":
                    {
                        var factory = PackIconMicronsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconModern":
                    {
                        var factory = PackIconModernDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconOcticons":
                    {
                        var factory = PackIconOcticonsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconPicolIcons":
                    {
                        var factory = PackIconPicolIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconRPGAwesome":
                    {
                        var factory = PackIconRPGAwesomeDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconSimpleIcons":
                    {
                        var factory = PackIconSimpleIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconTypicons":
                    {
                        var factory = PackIconTypiconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconUnicons":
                    {
                        var factory = PackIconUniconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconWeatherIcons":
                    {
                        var factory = PackIconWeatherIconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
                case "PackIconZondicons":
                    {
                        var factory = PackIconZondiconsDataFactory.Create();
                        foreach (var key in factory.Keys)
                        {
                            var keyString = key.ToString();
                            if (name != keyString)
                                continue;
                            return factory[key];
                        }
                        break;
                    }
            }
            return string.Empty;
        }
    }
}
