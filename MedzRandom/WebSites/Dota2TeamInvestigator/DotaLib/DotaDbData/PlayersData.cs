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
            string q = "SELECT TOP " + topCount + " " + _selectColumnNames + " FROM dbo.Players P\n";
            q += "WHERE PersonaName IS NULL\n";
            q += "OR LastUpdated < CONVERT(DATE, GETDATE())\n";
            q += "ORDER BY SteamID";

            DataTable dt = dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
            PopulateList(playersList, dt);
        }

        public long GetPlayerWithNoMatchRecords()
        {
            string q = "SELECT TOP 1 P.SteamID64 FROM dbo.TeamPlayers TP\n";
            q += "LEFT JOIN dbo.MatchPlayer MP ON TP.Player = MP.Player\n";
            q += "JOIN dbo.Players P ON TP.Player = P.SteamID\n";
            q += "WHERE MP.ID IS NULL\n";
            q += "AND CommunityVisibilityState = 5";

            object result = dataHelper.ExecuteScalar(dataHelper.CreateCommand(q));

            if (result != null && result != DBNull.Value)
                return Convert.ToInt64(result.ToString());
            else
                return -1;
        }

        protected void LoadBySteamID64(long steamId64)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Players P\n";
            q += "WHERE P.SteamID64 = @SteamID64\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@SteamID64", SqlDbType.BigInt).Value = steamId64;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
    }
}