using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Lists;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class PlayersData : PlayersProperties
    {
        public void LoadUnprocessedPlayers(PlayersList playersList, int topCount)
        {
            string q = "SELECT TOP 100 " + _selectColumnNames + " FROM dbo.Players P\n";
            q += "WHERE PersonaName IS NULL\n";
            q += "OR LastUpdated < CONVERT(DATE, GETDATE())\n";
            q += "ORDER BY SteamID";

            DataTable dt = dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
            PopulateList(playersList, dt);
        }
    }
}
