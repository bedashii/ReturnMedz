using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusPlayLib.Bus
{
    public class Gallery : Prop.GalleryProperties
    {
        //private System.IO.DirectoryInfo directoryInfo;

        public Gallery()
        {
            Files = new List<System.IO.FileInfo>();
        }

        public Gallery(string galleryName, System.IO.DirectoryInfo location)
        {
            Files = new List<System.IO.FileInfo>();

            this.GalleryName = galleryName;
            this.Location = location;
        }
    }
}
