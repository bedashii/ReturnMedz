using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class AudioLanguagesProperties : PropertiesBase
    {

        public AudioLanguagesProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private short _id;
        public short ID
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

        partial void OnDescriptionChanging();
        partial void OnDescriptionChanged();
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                OnDescriptionChanging();
                _description = value;
                base.HasChanged = true;
                OnDescriptionChanged();
            }
        }
    }
}