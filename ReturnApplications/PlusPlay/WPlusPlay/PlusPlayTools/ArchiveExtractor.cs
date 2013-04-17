using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPlusPlay.PlusPlayTools
{
    public class ArchiveExtractor
    {
        /// <summary>
        /// Extracts archive into tempoary location
        /// </summary>
        /// <param name="filepathFrom"></param>
        public void ExtractArchive(string archivePath)
        {
            Directory.CreateDirectory("TEMP");
            DirectoryInfo dinfo = new DirectoryInfo("TEMP");

            try
            {
                Ionic.Zip.ZipFile archive = Ionic.Zip.ZipFile.Read(archivePath);
                ReadZip(archive, dinfo);
                MoveFilesToSingleFolder(dinfo, "All");
                archive.Dispose();
                dinfo = null;
            }
            catch (IOException) { dinfo.Delete(true); }
            catch (Exception) { dinfo.Delete(true); }
        }

        void ReadZip(Ionic.Zip.ZipFile archive, DirectoryInfo dinfo)
        {
            foreach (Ionic.Zip.ZipEntry entry in archive)
                entry.Extract(dinfo.FullName);
        }

        void MoveFilesToSingleFolder(DirectoryInfo root, string destinationPath)
        {
            Directory.CreateDirectory(root.FullName + @"\" + destinationPath);
            DirectoryInfo dinfoAll = new DirectoryInfo(root.FullName + @"\" + destinationPath);

            foreach (DirectoryInfo di in dinfoAll.Parent.GetDirectories())
                if (di.Name != destinationPath)
                    foreach (FileInfo fi in di.GetFiles())
                        File.Move(fi.FullName, dinfoAll.FullName + @"\" + fi.Name);

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }
    }
}
