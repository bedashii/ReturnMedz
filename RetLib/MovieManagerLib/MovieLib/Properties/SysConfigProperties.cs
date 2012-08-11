using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class SysConfigProperties : PropertiesBase
    {

        public SysConfigProperties()
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

        partial void OnSettingChanging();
        partial void OnSettingChanged();
        private string _setting;
        public string Setting
        {
            get { return _setting; }
            set
            {
                OnSettingChanging();
                _setting = value;
                base.HasChanged = true;
                OnSettingChanged();
            }
        }

        partial void OnConfigChanging();
        partial void OnConfigChanged();
        private string _config;
        public string Config
        {
            get { return _config; }
            set
            {
                OnConfigChanging();
                _config = value;
                base.HasChanged = true;
                OnConfigChanged();
            }
        }
    }
}