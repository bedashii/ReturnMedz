using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class SystemConfigData : SystemConfigProperties
    {
        protected void LoadItemDataByKey(string key)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.SystemConfig S\n";
            q += "WHERE S.SCKey = @Key\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Key", SqlDbType.VarChar).Value = key;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
    }
}