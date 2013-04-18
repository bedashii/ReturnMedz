using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBoxLinkerLib
{
    public class Linker
    {
        public static string GetPublicURLFromFile(string path)
        {
            // replace Windows slashes with network slashes
            path = path.Replace('\\', '/');

            // create full URL
            return String.Format(@"{0}/{1}/{2}",
                 System.Configuration.ConfigurationManager.AppSettings.Get("HttpPath"),
                System.Configuration.ConfigurationManager.AppSettings.Get("UserID"),
                Uri.EscapeUriString(path.Substring(path.IndexOf("Dropbox/Public") + "Dropbox/Public".Length + 1)));
        }

        public static string[] GetPublicURLFromFolder(string path, string extension)
        {
            System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = extension == "" ? dinfo.GetFiles() : dinfo.GetFiles("*." + extension);
            List<string> urls = new List<string>();


            foreach (System.IO.FileInfo file in files)
            {
                string s = file.FullName.Replace('\\', '/');
                s = String.Format(@"{0}/{1}/{2}",
                 System.Configuration.ConfigurationManager.AppSettings.Get("HttpPath"),
                System.Configuration.ConfigurationManager.AppSettings.Get("UserID"),
                Uri.EscapeUriString(s.Substring(s.IndexOf(System.Configuration.ConfigurationManager.AppSettings.Get("SyncDirectory")) +
                System.Configuration.ConfigurationManager.AppSettings.Get("SyncDirectory").Length + 1)));
                urls.Add(s);
            }

            return urls.ToArray();
        }
    }
}
