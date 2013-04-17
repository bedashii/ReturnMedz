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
    public partial class BaseProperties: INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        private bool _hasChanged;
        public bool HasChanged 
        {
            get { return _hasChanged; }
            set { _hasChanged = value; }
        }

        private bool _exists;
        public bool Exists
        {
            get { return _exists; }
            set { _exists = value; }
        }
    }
}
