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
    public partial class TeamPlayersData : TeamPlayersProperties
    {
        protected void GetByTeamPlayer(int teamId, int playerId)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.TeamPlayers T\n";
            q += "WHERE T.Team = @Team and T.Player = @Player\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Team", SqlDbType.Int).Value = teamId;
            cmd.Parameters.Add("@Player", SqlDbType.Int).Value = playerId;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        public void GetByTeam(TeamPlayersList teamPlayersList, int team)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM TeamPlayers AS T\n";
            q += "WHERE Team = @Team";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Team", SqlDbType.Int).Value = team;

            PopulateList(teamPlayersList, dataHelper.ExecuteQuery(cmd));
        }
    }
}
