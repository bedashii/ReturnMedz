using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Lists
{
    public class SystemConfigList : List<SystemConfig>
    {
        SystemConfigData _data = new SystemConfigData();

        public SystemConfigList()
        {
            
        }

        public void GetAll()
        {
            this.Clear();

            this.AddRange(_data.GetAll());
        }

        public void GetByKey(string key)
        {
            this.Clear();
            this.AddRange(_data.GetByKey("MoviePath"));
        }
    }
}
