using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class SteamRequestsData : SteamRequestsProperties
    {
        protected void LoadByDate(DateTime now)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.SteamRequests S\n";
            q += "WHERE S.Date = @Date\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = now;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
    }
}
