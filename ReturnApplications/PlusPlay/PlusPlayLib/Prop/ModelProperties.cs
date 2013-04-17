using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using System.ComponentModel;

namespace PlusPlayLib.Prop
{
    public partial class ModelProperties : BaseProperties
    {
        private string _modelName;
        public string ModelName
        {
            get { return _modelName; }
            set
            {
                _modelName = value;
                HasChanged = true;
                OnPropertyChanged("ModelName");
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
                OnPropertyChanged("ModelName");
            }
        }
    }
}
