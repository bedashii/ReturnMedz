using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Properties
{
    public class SystemConfigProperties : PropertiesBase
    {
        int _iD;
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                if (_iD != value)
                {
                    _iD = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        string _configKey;
        public string ConfigKey
        {
            get
            {
                return _configKey;
            }
            set
            {
                if (_configKey != value)
                {
                    _configKey = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        string _configValue;
        public string ConfigValue
        {
            get
            {
                return _configValue;
            }
            set
            {
                if (_configValue != value)
                {
                    _configValue = value;
                    AnyPropertiesChanged = true;
                }
            }
        }
    }
}
