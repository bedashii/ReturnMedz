using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PlusPlayDBGenLib;
using PlusPlayDBGenLib.Business;
using PlusPlayDBGenLib.Lists;

namespace PlusPlayProcessors
{
    public class GalleryEditorProcessor
    {
        public Galleries CurrentGallery;

        public GalleryEditorProcessor()
        {
        }

        public void CreateGallery(string modelName, string galleryDirectory)
        {
            CurrentGallery = new Galleries();
            CurrentGallery.GalleryDirectory = galleryDirectory;
        }

        private void CreateGalleryName(DirectoryInfo dinfo)
        {

        }
    }
}
