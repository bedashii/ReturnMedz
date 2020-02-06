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

        private static string lastIndices => System.Configuration.ConfigurationManager.AppSettings.Get("LastIndices");
        public static List<string> LastIndices => lastIndices.Split(',').ToList();

        public static Dictionary<string, string> IndexDictionary => BuildIndices();

        private static Dictionary<string, string> BuildIndices()
        {
            if (WatchList.Count() != LastIndices.Count())
                throw new ApplicationException("Indices count not valid");

            var indices = new Dictionary<string, string>();

            for (int i = 0; i < WatchList.Count(); i++)
            {
                indices.Add(WatchList[i], LastIndices[i]);
            }

            return indices;
        }
    }
}
