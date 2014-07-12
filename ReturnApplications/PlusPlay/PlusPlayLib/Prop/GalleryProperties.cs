using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlusPlayLib.Prop
{
    public partial class GalleryProperties : BaseProperties
    {
        private string _galleryName;
        public string GalleryName
        {
            get { return _galleryName; }
            set
            {
                _galleryName = value;
                HasChanged = true;
                OnPropertyChanged("GalleryName");
            }
        }

        private DirectoryInfo _location;
        public DirectoryInfo Location
        {
            get { return _location; }
            set
            {
                _location = value;
                HasChanged = true;
                OnPropertyChanged("Location");
            }
        }

        private List<FileInfo> _files;
        public List<FileInfo> Files
        {
            get { return _files; }
            set
            {
                _files = value;
                HasChanged = true;
                OnPropertyChanged("Files");
            }
        }

    }
}
