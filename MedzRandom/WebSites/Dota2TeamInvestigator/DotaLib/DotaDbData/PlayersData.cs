using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Business;
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
            //q += "OR LastUpdated < CONVERT(DATE, GETDATE())\n";
            //q += "WHERE LastUpdated < CONVERT(DATE, GETDATE())\n";
            //q += "ORDER BY LastUpdated";
            q += "ORDER BY SteamID";

            DataTable dt = dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
            PopulateList(playersList, dt);
        }

        public long GetPlayerWithNoMatchRecords()
        {
            string q = "SELECT TOP 1 P.SteamID64 FROM dbo.TeamPlayers TP\n";
            q += "LEFT JOIN dbo.MatchPlayer MP ON TP.Player = MP.Player64\n";
            q += "JOIN dbo.Players P ON TP.Player = P.SteamID\n";
            q += "WHERE MP.ID IS NULL\n";
            q += "AND P.IsPrivate = 0";

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

        public bool LastMatchFound(long steamId64, out int matchId)
        {
            string q = "SELECT OldestMatchFound, Match FROM dbo.Players P\n";
            q += "LEFT JOIN dbo.MatchPlayer MP ON P.SteamID64 = MP.Player64\n";
            q += "WHERE P.SteamID64 = @SteamID64";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@SteamID64", SqlDbType.BigInt).Value = steamId64;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
            {
                base.RecordExists = false;
                matchId = 0;
                return false;
            }
            else
            {
                SetLastMatchFoundRowProperties(dt.Rows[0], this);
                matchId = this.OldestMatchID;
                return this.OldestMatchFound;
            }
        }

        private void SetLastMatchFoundRowProperties(DataRow dr, Properties.PlayersProperties row)
        {
            try
            {
                row.OldestMatchFound = Convert.ToBoolean(dr["OldestMatchFound"]);

                if ((dr["SteamID64"]) == DBNull.Value)
                    row.OldestMatchID = 0;
                else
                    row.OldestMatchID = Convert.ToInt32(dr["Match"]);
            }
            catch (Exception ex)
            {
                DataProcessHelper.ClearConnectionPools(ex);
                throw;
            }
        }

        public void GetByLikeName(string searchString, PlayersList list)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM Players AS P\n";
            q += "WHERE P.PersonaName LIKE '%" + searchString + "%'\n";
            q += "ORDER BY PersonaName";

            PopulateList(list, dataHelper.ExecuteQuery(dataHelper.CreateCommand(q)));
        }

        internal void LoadAll(List<Players> list, int count)
        {
            string q = "SELECT ";
                q += " TOP " + count + " ";
            q += _selectColumnNames + "\n";
            q += "FROM Players AS P\n";
            q += "WHERE P.PersonaName IS NOT NULL\n";
            q += "ORDER BY PersonaName";

            PopulateList(list, dataHelper.ExecuteQuery(dataHelper.CreateCommand(q)));
        }
    }
}