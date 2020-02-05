using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LainsDecryptor.Models
{
    public static class Configs
    {
        private static string ignoreList => System.Configuration.ConfigurationManager.AppSettings.Get("IgnoreList");
        public static List<string> IgnoreList => ignoreList.Split(',').ToList();

        private static string watchList => System.Configuration.ConfigurationManager.AppSettings.Get("WatchList");
        public static List<string> WatchList => watchList.Split(',').ToList();
    }
}
