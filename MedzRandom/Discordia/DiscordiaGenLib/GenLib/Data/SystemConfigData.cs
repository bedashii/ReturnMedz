using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            q += "ConfigValue = '" + ConfigValue + "'\n";
            q += "Where ROWID = " + ID;

            dh.ExecuteNonQuery(q);

            this.AnyPropertiesChanged = false;
        }

        public void Delete()
        {
            string q = "DELETE FROM SystemConfig\n";
            q += "WHERE ROWID = " + ID;

            dh.ExecuteNonQuery(q);
        }

        internal Lists.SystemConfigList GetAll()
        {
            Lists.SystemConfigList list = new Lists.SystemConfigList();

            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT ROWID,ConfigKey,ConfigValue FROM SystemConfig";

                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(q, dh.connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                SystemConfig sc = null;

                while (dataReader.Read())
                {
                    sc = new SystemConfig();

                    if (dh.HasColumn(dataReader, "ROWID"))
                        sc.ID = Convert.ToInt32(dataReader["ROWID"]);
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
                string q = "SELECT ROWID,ConfigKey,ConfigValue FROM SystemConfig\n";
                q += "WHERE ConfigKey = '" + key + "'";

                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(q, dh.connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                SystemConfig sc = null;

                while (dataReader.Read())
                {
                    sc = new SystemConfig();

                    if (dh.HasColumn(dataReader, "ROWID"))
                        sc.ID = Convert.ToInt32(dataReader["ROWID"]);
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
