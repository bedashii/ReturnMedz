using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Properties
{
    public partial class FormatProperties:PropertiesBase
    {
        public FormatProperties()
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

        partial void OnFormatNameChanging();
        partial void OnFormatNameChanged();
        private string _formatName;
        public string FormatName
        {
            get { return _formatName; }
            set
            {
                OnFormatNameChanging();
                _formatName = value;
                base.HasChanged = true;
                OnFormatNameChanged();
            }
        }

        partial void OnFormatExtensionChanging();
        partial void OnFormatExtensionChanged();
        private string _formatExtension;
        public string FormatExtension
        {
            get { return _formatExtension; }
            set
            {
                OnFormatExtensionChanging();
                _formatExtension = value;
                base.HasChanged = true;
                OnFormatExtensionChanged();
            }
        }
    }
}
