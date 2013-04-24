using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Data
{
    public class SystemConfigData : SystemConfigProperties
    {
        DataHelper dh = new DataHelper();

        public SystemConfigData()
        {
            dh.InitializeDB();
        }

        internal void Insert()
        {
            string q = "INSERT INTO SystemConfig (ConfigKey,ConfigValue)\n";
            q += "VALUES('" + ConfigKey + "','" + ConfigValue + "')";

            this.RecordExists = true;

            dh.ExecuteNonQuery(q);
        }

        internal void Update()
        {
            string q = "UPDATE SystemConfig\n";
            q += "SET ConfigKey = '" + ConfigKey + "',\n";
            q += "ConfigValye = '" + ConfigValue + "'\n";
            q += "Where ID = " + ID;

            dh.ExecuteNonQuery(q);

            this.AnyPropertiesChanged = false;
        }

        internal void Delete()
        {
            string q = "DELETE FROM SystemConfig\n";
            q += "WHERE ID = " + ID;

            dh.ExecuteNonQuery(q);
        }

        internal Lists.SystemConfigList GetAll()
        {
            Lists.SystemConfigList list = new Lists.SystemConfigList();

            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT * FROM SystemConfig";

                //Create Command
                MySqlCommand cmd = new MySqlCommand(q, dh.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                SystemConfig sc = null;

                while (dataReader.Read())
                {
                    sc = new SystemConfig();

                    if (dh.HasColumn(dataReader, "ID"))
                        sc.ID = Convert.ToInt32(dataReader["ID"]);
                    if (dh.HasColumn(dataReader, "ConfigKey"))
                        sc.ConfigKey = dataReader["ConfigKey"].ToString();
                    if (dh.HasColumn(dataReader, "ConfigValue"))
                        sc.ConfigValue = dataReader["ConfigValue"].ToString();

                    sc.RecordExists = true;

                    list.Add(sc);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                dh.CloseConnection();
            }

            return list;
        }

        internal List<SystemConfig> GetByKey(string key)
        {
            Lists.SystemConfigList list = new Lists.SystemConfigList();

            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT * FROM SystemConfig\n";
                q += "WHERE ConfigKey = '" + key + "'";

                //Create Command
                MySqlCommand cmd = new MySqlCommand(q, dh.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                SystemConfig sc = null;

                while (dataReader.Read())
                {
                    sc = new SystemConfig();

                    if (dh.HasColumn(dataReader, "ID"))
                        sc.ID = Convert.ToInt32(dataReader["ID"]);
                    if (dh.HasColumn(dataReader, "ConfigKey"))
                        sc.ConfigKey = dataReader["ConfigKey"].ToString();
                    if (dh.HasColumn(dataReader, "ConfigValue"))
                        sc.ConfigValue = dataReader["ConfigValue"].ToString();

                    sc.RecordExists = true;

                    list.Add(sc);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                dh.CloseConnection();
            }

            return list;
        }
    }
}
