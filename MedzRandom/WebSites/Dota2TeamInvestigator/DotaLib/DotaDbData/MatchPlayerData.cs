﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class MatchPlayerData : MatchPlayerProperties
    {
        protected void LoadByMatchPlayer64(int matchId, long player64)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.MatchPlayer M\n";
            q += "WHERE Match = @MatchID AND Player64 = @Player64";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@MatchID", SqlDbType.Int).Value = matchId;
            cmd.Parameters.Add("@Player64", SqlDbType.BigInt).Value = player64;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        protected void LoadByMatchPlayer(int matchId, int player)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.MatchPlayer M\n";
            q += "WHERE Match = @MatchID AND Player = @Player";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@MatchID", SqlDbType.Int).Value = matchId;
            cmd.Parameters.Add("@Player", SqlDbType.Int).Value = player;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        protected void LoadByMatchSlot(int matchId, int slot)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.MatchPlayer M\n";
            q += "WHERE Match = @MatchID AND Slot = @Slot";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@MatchID", SqlDbType.Int).Value = matchId;
            cmd.Parameters.Add("@Slot", SqlDbType.Int).Value = slot;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
    }
}
