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
    public partial class TeamsData : Properties.TeamsProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "T.[ID], T.[TeamName], T.[Tag], T.[TimeCreated], T.[Rating], T.[Logo], T.[LogoSponsor], T.[CountryCode], T.[URL], T.[GamesPlayed], T.[AdminAccount], T.[LastUpdated]";

        public TeamsData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Teams T\n";
            q += "WHERE T.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<Teams> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<Teams> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.Teams \n";
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
        internal void SetRowProperties(DataRow dr, Properties.TeamsProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.TeamName = Convert.ToString(dr["TeamName"]);

				if ((dr["Tag"]) == DBNull.Value)
					row.Tag = null;
				else
					row.Tag = Convert.ToString(dr["Tag"]);

				if ((dr["TimeCreated"]) == DBNull.Value)
					row.TimeCreated = null;
				else
					row.TimeCreated = Convert.ToString(dr["TimeCreated"]);

				if ((dr["Rating"]) == DBNull.Value)
					row.Rating = null;
				else
					row.Rating = Convert.ToString(dr["Rating"]);

				if ((dr["Logo"]) == DBNull.Value)
					row.Logo = null;
				else
					row.Logo = Convert.ToString(dr["Logo"]);

				if ((dr["LogoSponsor"]) == DBNull.Value)
					row.LogoSponsor = null;
				else
					row.LogoSponsor = Convert.ToString(dr["LogoSponsor"]);

				if ((dr["CountryCode"]) == DBNull.Value)
					row.CountryCode = null;
				else
					row.CountryCode = Convert.ToString(dr["CountryCode"]);

				if ((dr["URL"]) == DBNull.Value)
					row.URL = null;
				else
					row.URL = Convert.ToString(dr["URL"]);

				if ((dr["GamesPlayed"]) == DBNull.Value)
					row.GamesPlayed = null;
				else
					row.GamesPlayed = Convert.ToInt32(dr["GamesPlayed"]);

				if ((dr["AdminAccount"]) == DBNull.Value)
					row.AdminAccount = null;
				else
					row.AdminAccount = Convert.ToInt32(dr["AdminAccount"]);

				row.LastUpdated = Convert.ToDateTime(dr["LastUpdated"]);

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
            q += "FROM Teams AS T\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.Teams SET [TeamName] = @TeamName, [Tag] = @Tag, [TimeCreated] = @TimeCreated, [Rating] = @Rating, [Logo] = @Logo, [LogoSponsor] = @LogoSponsor, [CountryCode] = @CountryCode, [URL] = @URL, [GamesPlayed] = @GamesPlayed, [AdminAccount] = @AdminAccount, [LastUpdated] = @LastUpdated\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@TeamName", SqlDbType.VarChar, -1).Value = TeamName;
			
			if (Tag == null)
				cmd.Parameters.Add("@Tag", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Tag", SqlDbType.VarChar, -1).Value = Tag;
			
			
			if (TimeCreated == null)
				cmd.Parameters.Add("@TimeCreated", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@TimeCreated", SqlDbType.VarChar, -1).Value = TimeCreated;
			
			
			if (Rating == null)
				cmd.Parameters.Add("@Rating", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Rating", SqlDbType.VarChar, -1).Value = Rating;
			
			
			if (Logo == null)
				cmd.Parameters.Add("@Logo", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Logo", SqlDbType.VarChar, -1).Value = Logo;
			
			
			if (LogoSponsor == null)
				cmd.Parameters.Add("@LogoSponsor", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LogoSponsor", SqlDbType.VarChar, -1).Value = LogoSponsor;
			
			
			if (CountryCode == null)
				cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar, -1).Value = CountryCode;
			
			
			if (URL == null)
				cmd.Parameters.Add("@URL", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@URL", SqlDbType.VarChar, -1).Value = URL;
			
			
			if (GamesPlayed == null)
				cmd.Parameters.Add("@GamesPlayed", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GamesPlayed", SqlDbType.Int, 4).Value = GamesPlayed;
			
			
			if (AdminAccount == null)
				cmd.Parameters.Add("@AdminAccount", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@AdminAccount", SqlDbType.Int, 4).Value = AdminAccount;
			
			cmd.Parameters.Add("@LastUpdated", SqlDbType.DateTime, 8).Value = LastUpdated;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Teams ( [ID], [TeamName], [Tag], [TimeCreated], [Rating], [Logo], [LogoSponsor], [CountryCode], [URL], [GamesPlayed], [AdminAccount], [LastUpdated] )\n";
            q += "VALUES  ( @ID, @TeamName, @Tag, @TimeCreated, @Rating, @Logo, @LogoSponsor, @CountryCode, @URL, @GamesPlayed, @AdminAccount, @LastUpdated )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@TeamName", SqlDbType.VarChar, -1).Value = TeamName;
			
			if (Tag == null)
				cmd.Parameters.Add("@Tag", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Tag", SqlDbType.VarChar, -1).Value = Tag;
			
			
			if (TimeCreated == null)
				cmd.Parameters.Add("@TimeCreated", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@TimeCreated", SqlDbType.VarChar, -1).Value = TimeCreated;
			
			
			if (Rating == null)
				cmd.Parameters.Add("@Rating", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Rating", SqlDbType.VarChar, -1).Value = Rating;
			
			
			if (Logo == null)
				cmd.Parameters.Add("@Logo", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Logo", SqlDbType.VarChar, -1).Value = Logo;
			
			
			if (LogoSponsor == null)
				cmd.Parameters.Add("@LogoSponsor", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LogoSponsor", SqlDbType.VarChar, -1).Value = LogoSponsor;
			
			
			if (CountryCode == null)
				cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar, -1).Value = CountryCode;
			
			
			if (URL == null)
				cmd.Parameters.Add("@URL", SqlDbType.VarChar, -1).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@URL", SqlDbType.VarChar, -1).Value = URL;
			
			
			if (GamesPlayed == null)
				cmd.Parameters.Add("@GamesPlayed", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GamesPlayed", SqlDbType.Int, 4).Value = GamesPlayed;
			
			
			if (AdminAccount == null)
				cmd.Parameters.Add("@AdminAccount", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@AdminAccount", SqlDbType.Int, 4).Value = AdminAccount;
			
			cmd.Parameters.Add("@LastUpdated", SqlDbType.DateTime, 8).Value = LastUpdated;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            

            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.Teams> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Teams p = new Business.Teams();
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
                throw new Exception(string.Format("Teams record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
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
