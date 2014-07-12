using DiscordiaGenLib.GenLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Business
{
    public class SystemConfig : SystemConfigData
    {
        public SystemConfig()
        {

        }
        public SystemConfig(string key, string value)
        {
            this.ConfigKey = key;
            this.ConfigValue = value;
        }
    }
}
