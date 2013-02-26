using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DownloadSorter
{
    public class CustomFile
    {
        public string FileName { get; set; }
        public string Extention { get; set; }
        public string FullPath { get; set; }
        //public string DestinationFileName { get; set; }
        public long Size { get; set; }
        public string DestinationFullPath { get; set; }
        public string ParentName { get; set; }
        //public CustomFile()
        //{

        //}

        public CustomFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                FullPath = fullPath;
                FileInfo details = new FileInfo(fullPath);
                Extention = details.Extension;
                Size = details.Length / 1024 / 1024;

                getParentName();
            }
            else
            {

            }
        }

        private void getParentName()
        {
            List<int> hierList = new List<int>();
            hierList.Add(FullPath.IndexOf('\\'));
            while (hierList.Last() != -1)
            {
                hierList.Add(FullPath.IndexOf('\\', hierList.Last() + 1));
            }
            ParentName = FullPath.Substring(hierList[hierList.Count - 3] + 1, hierList[hierList.Count - 2] - hierList[hierList.Count - 3] - 1);
        }
    }
}
