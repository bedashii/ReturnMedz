using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace ZipperLib
{
    public class Archive
    {
        #region Properties
        public List<FileInfo> Files { get; set; }

        private string _archiveName;
        public string ArchiveName 
        {
            get { return _archiveName + ".zip"; }
            set { _archiveName = value; }
        }

        private int _splitArchiveSize;
        public int SplitArchiveSize
        {
            get { return _splitArchiveSize * 1024 * 1024; }
            set { _splitArchiveSize = value; }
        }
        #endregion Properties

        public Archive(string archiveName, List<FileInfo> files, int splitArchiveSize = 0)
        {
            ArchiveName = archiveName;
            Files = files;
            SplitArchiveSize = splitArchiveSize;
        }

        public void CreateArchive()
        {
            using (ZipFile zipFile = new ZipFile())
            {
                foreach (FileInfo file in Files)
                    zipFile.AddFile(file.FullName);

                if (SplitArchiveSize != 0)
                    zipFile.MaxOutputSegmentSize = SplitArchiveSize;
                
                zipFile.Save(ArchiveName);
            }
        }
    }
}
