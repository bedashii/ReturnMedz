using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using static BooruHelper.Consts.ConfigsHelper;
using static BooruHelper.Consts.Enums;

namespace BooruHelper.Consts
{
    public static class Configs
    {
        public static string ImageFilePathConfig => GetConfigString("ImageFilePath");
        public static string ImagePrefixConfig => GetConfigString("ImagePrefix");
        public static string ImageNameConfig => GetConfigString("ImageName");
        public static string ImageExtensionConfig => GetConfigString("ImageExtension");
        public static int CopyIntervalConfig => GetConfigInt32("CopyInterval");
        public static DateTime StartTimeConfig => GetConfigTime("StartTime");
        public static DateTime EndTimeConfig => GetConfigTime("EndTime");
        public static string FrameRateConfig => GetConfigString("FrameRate");
        public static string StartingImageNumberConfig => GetConfigString("StartingImageNumber");
        public static string VideoResolutionConfig => GetConfigString("VideoResolution");
        public static string CodecConfig => GetConfigString("Codec");
        public static string VideoExtensionConfig => GetConfigString("VideoExtension");
        public static int ZeroPaddingConfig => GetConfigInt32("ZeroPadding");
    }

    public static class ConfigsHelper
    {
        public static string GetConfigString(string configName)
        {
            return ConfigurationManager.AppSettings.Get(configName);
        }

        public static int GetConfigInt32(string configName)
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get(configName));

        }

        public static DateTime GetConfigTime(string configName)
        {
            return DateTime.ParseExact(ConfigurationManager.AppSettings.Get(configName), "HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
