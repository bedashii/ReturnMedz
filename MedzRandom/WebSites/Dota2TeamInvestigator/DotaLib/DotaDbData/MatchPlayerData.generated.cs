using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Business;


/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace DotaDbGenLib.Data
{
    public partial class MatchPlayerData : Properties.MatchPlayerProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "M.[ID], M.[Match], M.[Player], M.[Player64], M.[Slot], M.[Hero]";

        public MatchPlayerData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.MatchPlayer M\n";
            q += "WHERE M.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<MatchPlayer> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<MatchPlayer> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.MatchPlayer \n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            
            dataHelper.ExecuteNonQuery(cmd);
        }        
/* FOR LATER REFACTORING:
        private void AddPrimaryKeyParameters(SqlCommand cmd, int iD)
        {
            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
        }
*/        
        internal void SetRowProperties(DataRow dr, Properties.MatchPlayerProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.Match = Convert.ToInt32(dr["Match"]);

				if ((dr["Player"]) == DBNull.Value)
					row.Player = null;
				else
					row.Player = Convert.ToInt32(dr["Player"]);

				if ((dr["Player64"]) == DBNull.Value)
					row.Player64 = null;
				else
					row.Player64 = Convert.ToInt64(dr["Player64"]);

				row.Slot = Convert.ToInt32(dr["Slot"]);
				row.Hero = Convert.ToInt32(dr["Hero"]);

                row.RecordExists = true;
                row.AnyPropertyChanged = false;
            }
            catch (Exception ex)
            {
                DataProcessHelper.ClearConnectionPools(ex);
                throw;
            }
        }
        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM MatchPlayer AS M\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.MatchPlayer SET [Match] = @Match, [Player] = @Player, [Player64] = @Player64, [Slot] = @Slot, [Hero] = @Hero\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@Match", SqlDbType.Int, 4).Value = Match;
			
			if (Player == null)
				cmd.Parameters.Add("@Player", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Player", SqlDbType.Int, 4).Value = Player;
			
			
			if (Player64 == null)
				cmd.Parameters.Add("@Player64", SqlDbType.BigInt, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Player64", SqlDbType.BigInt, 8).Value = Player64;
			
			cmd.Parameters.Add("@Slot", SqlDbType.Int, 4).Value = Slot;
			cmd.Parameters.Add("@Hero", SqlDbType.Int, 4).Value = Hero;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.MatchPlayer ( [Match], [Player], [Player64], [Slot], [Hero] )\n";
            q += "VALUES  ( @Match, @Player, @Player64, @Slot, @Hero )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@Match", SqlDbType.Int, 4).Value = Match;
			
			if (Player == null)
				cmd.Parameters.Add("@Player", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Player", SqlDbType.Int, 4).Value = Player;
			
			
			if (Player64 == null)
				cmd.Parameters.Add("@Player64", SqlDbType.BigInt, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Player64", SqlDbType.BigInt, 8).Value = Player64;
			
			cmd.Parameters.Add("@Slot", SqlDbType.Int, 4).Value = Slot;
			cmd.Parameters.Add("@Hero", SqlDbType.Int, 4).Value = Hero;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;


            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.MatchPlayer> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.MatchPlayer p = new Business.MatchPlayer();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        public virtual void ValidateFields()
        {}

        public virtual void Update()
        {
            ValidateFields();
            Data.UpdateProperties up = this.UpdateData();
            if (up.RowsAffected == 0)
                throw new Exception(string.Format("MatchPlayer record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
        }

        public virtual void Insert()
        {
            ValidateFields();
            this.InsertData();
        }
        
        public virtual void InsertOrUpdate()
        {
            if (this.RecordExists)
                this.Update();
            else
                this.Insert();
        }        

        public string GetPrimaryKeyValues()
        {
            string pkValues = "PK:[";
            pkValues += "ID=" + ID.ToString();
            return pkValues + "]";
        }}
}
