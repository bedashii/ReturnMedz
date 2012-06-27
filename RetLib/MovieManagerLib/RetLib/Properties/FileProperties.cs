using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RetLib.Properties
{
    public partial class FileProperties : PropertiesBase
    {
        public FileProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                OnIDChanging();
                _id = value;
                base.HasChanged = true;
                OnIDChanged();
            }
        }

        partial void OnNameChanging();
        partial void OnNameChanged();
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                OnNameChanging();
                _name = value;
                base.HasChanged = true;
                OnNameChanged();
            }
        }

        partial void OnExtensionChanging();
        partial void OnExtensionChanged();
        private string _extension;
        public string Extension
        {
            get { return _extension; }
            set
            {
                OnExtensionChanging();
                _extension = value;
                base.HasChanged = true;
                OnExtensionChanged();
            }
        }

        partial void OnSizeChanging();
        partial void OnSizeChanged();
        private decimal _size;
        public decimal Size
        {
            get { return _size; }
            set
            {
                OnSizeChanging();
                _size = value;
                base.HasChanged = true;
                OnSizeChanged();
            }
        }
    }
}