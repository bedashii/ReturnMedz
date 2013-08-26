using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class TeamsData : TeamsProperties
    {
        public int? GetMaxTeamID()
        {
            string q = "SELECT MAX(ID) FROM dbo.Teams";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            var maxID = dataHelper.ExecuteScalar(cmd);

            if (maxID != DBNull.Value)
                return Convert.ToInt32(maxID);
            else
                return null;
        }
    }
}
