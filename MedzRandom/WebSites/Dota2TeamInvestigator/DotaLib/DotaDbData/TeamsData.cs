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

        public int? GetMinTeamIDForUpdate()
        {
            // Search searches upwards via ID so better chance of hitting others that we are looking for.
            // But might leave some teams completely in the dark.
            string q = "SELECT MIN(ID) FROM dbo.Teams\n";
            q += "WHERE LastUpdated<CONVERT(DATE, GETDATE())";

            // OR

            // Chasing tail style
            //SELECT TOP 1 ID FROM dbo.Teams
            //WHERE LastUpdated<CONVERT(DATE, GETDATE())
            //ORDER BY LastUpdated

            SqlCommand cmd = dataHelper.CreateCommand(q);

            var maxID = dataHelper.ExecuteScalar(cmd);

            if (maxID != DBNull.Value)
                return Convert.ToInt32(maxID);
            else
                return null;
        }
    }
}
