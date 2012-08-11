using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class ExtensionTypeProperties : PropertiesBase
    {

        public ExtensionTypeProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private byte _id;
        public byte ID
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

        partial void OnExtensionDescriptionChanging();
        partial void OnExtensionDescriptionChanged();
        private string _extensionDescription;
        public string ExtensionDescription
        {
            get { return _extensionDescription; }
            set
            {
                OnExtensionDescriptionChanging();
                _extensionDescription = value;
                base.HasChanged = true;
                OnExtensionDescriptionChanged();
            }
        }
    }
}