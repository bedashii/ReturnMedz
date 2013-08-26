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
    public partial class PlayersData : Properties.PlayersProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "P.[SteamID], P.[TeamID], P.[PersonaName], P.[ProfileURL], P.[Avatar], P.[AvatarMedium], P.[AvatarFull], P.[PersonaState], P.[CommunityVisibilityState], P.[ProfileState], P.[LastLogOff], P.[CommentPermission], P.[RealName], P.[PrimaryClanID], P.[TimeCreated], P.[GameID], P.[GameServerID], P.[GameExtraInfo], P.[CityID], P.[LocCountyCode], P.[LocStateCode], P.[LocCityID]";

        public PlayersData()
        {
        }
        
        internal void LoadItemData(int steamID)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Players P\n";
            q += "WHERE P.SteamID = @SteamID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@SteamID", SqlDbType.Int, 4).Value = steamID;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<Players> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<Players> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int steamID)
        {
            string q = "DELETE FROM dbo.Players \n";
            q += "WHERE SteamID = @SteamID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@SteamID", SqlDbType.Int, 4).Value = steamID;
            
            dataHelper.ExecuteNonQuery(cmd);
        }        
/* FOR LATER REFACTORING:
        private void AddPrimaryKeyParameters(SqlCommand cmd, int iD)
        {
            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
        }
*/        
        internal void SetRowProperties(DataRow dr, Properties.PlayersProperties row)
        {
            try
            {
				row.SteamID = Convert.ToInt32(dr["SteamID"]);

				if ((dr["TeamID"]) == DBNull.Value)
					row.TeamID = null;
				else
					row.TeamID = Convert.ToInt32(dr["TeamID"]);

				if ((dr["PersonaName"]) == DBNull.Value)
					row.PersonaName = null;
				else
					row.PersonaName = Convert.ToString(dr["PersonaName"]);

				if ((dr["ProfileURL"]) == DBNull.Value)
					row.ProfileURL = null;
				else
					row.ProfileURL = Convert.ToString(dr["ProfileURL"]);

				if ((dr["Avatar"]) == DBNull.Value)
					row.Avatar = null;
				else
					row.Avatar = Convert.ToString(dr["Avatar"]);

				if ((dr["AvatarMedium"]) == DBNull.Value)
					row.AvatarMedium = null;
				else
					row.AvatarMedium = Convert.ToString(dr["AvatarMedium"]);

				if ((dr["AvatarFull"]) == DBNull.Value)
					row.AvatarFull = null;
				else
					row.AvatarFull = Convert.ToString(dr["AvatarFull"]);

				if ((dr["PersonaState"]) == DBNull.Value)
					row.PersonaState = null;
				else
					row.PersonaState = Convert.ToInt32(dr["PersonaState"]);

				if ((dr["CommunityVisibilityState"]) == DBNull.Value)
					row.CommunityVisibilityState = null;
				else
					row.CommunityVisibilityState = Convert.ToInt32(dr["CommunityVisibilityState"]);

				if ((dr["ProfileState"]) == DBNull.Value)
					row.ProfileState = null;
				else
					row.ProfileState = Convert.ToInt32(dr["ProfileState"]);

				if ((dr["LastLogOff"]) == DBNull.Value)
					row.LastLogOff = null;
				else
					row.LastLogOff = Convert.ToDateTime(dr["LastLogOff"]);

				if ((dr["CommentPermission"]) == DBNull.Value)
					row.CommentPermission = null;
				else
					row.CommentPermission = Convert.ToString(dr["CommentPermission"]);

				if ((dr["RealName"]) == DBNull.Value)
					row.RealName = null;
				else
					row.RealName = Convert.ToString(dr["RealName"]);

				if ((dr["PrimaryClanID"]) == DBNull.Value)
					row.PrimaryClanID = null;
				else
					row.PrimaryClanID = Convert.ToInt32(dr["PrimaryClanID"]);

				if ((dr["TimeCreated"]) == DBNull.Value)
					row.TimeCreated = null;
				else
					row.TimeCreated = Convert.ToDateTime(dr["TimeCreated"]);

				if ((dr["GameID"]) == DBNull.Value)
					row.GameID = null;
				else
					row.GameID = Convert.ToInt32(dr["GameID"]);

				if ((dr["GameServerID"]) == DBNull.Value)
					row.GameServerID = null;
				else
					row.GameServerID = Convert.ToString(dr["GameServerID"]);

				if ((dr["GameExtraInfo"]) == DBNull.Value)
					row.GameExtraInfo = null;
				else
					row.GameExtraInfo = Convert.ToString(dr["GameExtraInfo"]);

				if ((dr["CityID"]) == DBNull.Value)
					row.CityID = null;
				else
					row.CityID = Convert.ToInt32(dr["CityID"]);

				if ((dr["LocCountyCode"]) == DBNull.Value)
					row.LocCountyCode = null;
				else
					row.LocCountyCode = Convert.ToString(dr["LocCountyCode"]);

				if ((dr["LocStateCode"]) == DBNull.Value)
					row.LocStateCode = null;
				else
					row.LocStateCode = Convert.ToString(dr["LocStateCode"]);

				if ((dr["LocCityID"]) == DBNull.Value)
					row.LocCityID = null;
				else
					row.LocCityID = Convert.ToString(dr["LocCityID"]);

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
            q += "FROM Players AS P\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.Players SET [TeamID] = @TeamID, [PersonaName] = @PersonaName, [ProfileURL] = @ProfileURL, [Avatar] = @Avatar, [AvatarMedium] = @AvatarMedium, [AvatarFull] = @AvatarFull, [PersonaState] = @PersonaState, [CommunityVisibilityState] = @CommunityVisibilityState, [ProfileState] = @ProfileState, [LastLogOff] = @LastLogOff, [CommentPermission] = @CommentPermission, [RealName] = @RealName, [PrimaryClanID] = @PrimaryClanID, [TimeCreated] = @TimeCreated, [GameID] = @GameID, [GameServerID] = @GameServerID, [GameExtraInfo] = @GameExtraInfo, [CityID] = @CityID, [LocCountyCode] = @LocCountyCode, [LocStateCode] = @LocStateCode, [LocCityID] = @LocCityID\n";
            q += "WHERE SteamID = @SteamID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@SteamID", SqlDbType.Int, 4).Value = SteamID;
			
			if (TeamID == null)
				cmd.Parameters.Add("@TeamID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@TeamID", SqlDbType.Int, 4).Value = TeamID;
			
			
			if (PersonaName == null)
				cmd.Parameters.Add("@PersonaName", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@PersonaName", SqlDbType.VarChar, 100).Value = PersonaName;
			
			
			if (ProfileURL == null)
				cmd.Parameters.Add("@ProfileURL", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@ProfileURL", SqlDbType.VarChar, 100).Value = ProfileURL;
			
			
			if (Avatar == null)
				cmd.Parameters.Add("@Avatar", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Avatar", SqlDbType.VarChar, 100).Value = Avatar;
			
			
			if (AvatarMedium == null)
				cmd.Parameters.Add("@AvatarMedium", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@AvatarMedium", SqlDbType.VarChar, 100).Value = AvatarMedium;
			
			
			if (AvatarFull == null)
				cmd.Parameters.Add("@AvatarFull", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@AvatarFull", SqlDbType.VarChar, 100).Value = AvatarFull;
			
			
			if (PersonaState == null)
				cmd.Parameters.Add("@PersonaState", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@PersonaState", SqlDbType.Int, 4).Value = PersonaState;
			
			
			if (CommunityVisibilityState == null)
				cmd.Parameters.Add("@CommunityVisibilityState", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CommunityVisibilityState", SqlDbType.Int, 4).Value = CommunityVisibilityState;
			
			
			if (ProfileState == null)
				cmd.Parameters.Add("@ProfileState", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@ProfileState", SqlDbType.Int, 4).Value = ProfileState;
			
			
			if (LastLogOff == null)
				cmd.Parameters.Add("@LastLogOff", SqlDbType.DateTime, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LastLogOff", SqlDbType.DateTime, 8).Value = LastLogOff;
			
			
			if (CommentPermission == null)
				cmd.Parameters.Add("@CommentPermission", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CommentPermission", SqlDbType.VarChar, 100).Value = CommentPermission;
			
			
			if (RealName == null)
				cmd.Parameters.Add("@RealName", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@RealName", SqlDbType.VarChar, 100).Value = RealName;
			
			
			if (PrimaryClanID == null)
				cmd.Parameters.Add("@PrimaryClanID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@PrimaryClanID", SqlDbType.Int, 4).Value = PrimaryClanID;
			
			
			if (TimeCreated == null)
				cmd.Parameters.Add("@TimeCreated", SqlDbType.DateTime, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@TimeCreated", SqlDbType.DateTime, 8).Value = TimeCreated;
			
			
			if (GameID == null)
				cmd.Parameters.Add("@GameID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GameID", SqlDbType.Int, 4).Value = GameID;
			
			
			if (GameServerID == null)
				cmd.Parameters.Add("@GameServerID", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GameServerID", SqlDbType.VarChar, 100).Value = GameServerID;
			
			
			if (GameExtraInfo == null)
				cmd.Parameters.Add("@GameExtraInfo", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GameExtraInfo", SqlDbType.VarChar, 100).Value = GameExtraInfo;
			
			
			if (CityID == null)
				cmd.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = CityID;
			
			
			if (LocCountyCode == null)
				cmd.Parameters.Add("@LocCountyCode", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LocCountyCode", SqlDbType.VarChar, 100).Value = LocCountyCode;
			
			
			if (LocStateCode == null)
				cmd.Parameters.Add("@LocStateCode", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LocStateCode", SqlDbType.VarChar, 100).Value = LocStateCode;
			
			
			if (LocCityID == null)
				cmd.Parameters.Add("@LocCityID", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LocCityID", SqlDbType.VarChar, 100).Value = LocCityID;
			
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Players ( [SteamID], [TeamID], [PersonaName], [ProfileURL], [Avatar], [AvatarMedium], [AvatarFull], [PersonaState], [CommunityVisibilityState], [ProfileState], [LastLogOff], [CommentPermission], [RealName], [PrimaryClanID], [TimeCreated], [GameID], [GameServerID], [GameExtraInfo], [CityID], [LocCountyCode], [LocStateCode], [LocCityID] )\n";
            q += "VALUES  ( @SteamID, @TeamID, @PersonaName, @ProfileURL, @Avatar, @AvatarMedium, @AvatarFull, @PersonaState, @CommunityVisibilityState, @ProfileState, @LastLogOff, @CommentPermission, @RealName, @PrimaryClanID, @TimeCreated, @GameID, @GameServerID, @GameExtraInfo, @CityID, @LocCountyCode, @LocStateCode, @LocCityID )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@SteamID", SqlDbType.Int, 4).Value = SteamID;
			
			if (TeamID == null)
				cmd.Parameters.Add("@TeamID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@TeamID", SqlDbType.Int, 4).Value = TeamID;
			
			
			if (PersonaName == null)
				cmd.Parameters.Add("@PersonaName", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@PersonaName", SqlDbType.VarChar, 100).Value = PersonaName;
			
			
			if (ProfileURL == null)
				cmd.Parameters.Add("@ProfileURL", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@ProfileURL", SqlDbType.VarChar, 100).Value = ProfileURL;
			
			
			if (Avatar == null)
				cmd.Parameters.Add("@Avatar", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@Avatar", SqlDbType.VarChar, 100).Value = Avatar;
			
			
			if (AvatarMedium == null)
				cmd.Parameters.Add("@AvatarMedium", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@AvatarMedium", SqlDbType.VarChar, 100).Value = AvatarMedium;
			
			
			if (AvatarFull == null)
				cmd.Parameters.Add("@AvatarFull", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@AvatarFull", SqlDbType.VarChar, 100).Value = AvatarFull;
			
			
			if (PersonaState == null)
				cmd.Parameters.Add("@PersonaState", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@PersonaState", SqlDbType.Int, 4).Value = PersonaState;
			
			
			if (CommunityVisibilityState == null)
				cmd.Parameters.Add("@CommunityVisibilityState", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CommunityVisibilityState", SqlDbType.Int, 4).Value = CommunityVisibilityState;
			
			
			if (ProfileState == null)
				cmd.Parameters.Add("@ProfileState", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@ProfileState", SqlDbType.Int, 4).Value = ProfileState;
			
			
			if (LastLogOff == null)
				cmd.Parameters.Add("@LastLogOff", SqlDbType.DateTime, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LastLogOff", SqlDbType.DateTime, 8).Value = LastLogOff;
			
			
			if (CommentPermission == null)
				cmd.Parameters.Add("@CommentPermission", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CommentPermission", SqlDbType.VarChar, 100).Value = CommentPermission;
			
			
			if (RealName == null)
				cmd.Parameters.Add("@RealName", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@RealName", SqlDbType.VarChar, 100).Value = RealName;
			
			
			if (PrimaryClanID == null)
				cmd.Parameters.Add("@PrimaryClanID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@PrimaryClanID", SqlDbType.Int, 4).Value = PrimaryClanID;
			
			
			if (TimeCreated == null)
				cmd.Parameters.Add("@TimeCreated", SqlDbType.DateTime, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@TimeCreated", SqlDbType.DateTime, 8).Value = TimeCreated;
			
			
			if (GameID == null)
				cmd.Parameters.Add("@GameID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GameID", SqlDbType.Int, 4).Value = GameID;
			
			
			if (GameServerID == null)
				cmd.Parameters.Add("@GameServerID", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GameServerID", SqlDbType.VarChar, 100).Value = GameServerID;
			
			
			if (GameExtraInfo == null)
				cmd.Parameters.Add("@GameExtraInfo", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@GameExtraInfo", SqlDbType.VarChar, 100).Value = GameExtraInfo;
			
			
			if (CityID == null)
				cmd.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = CityID;
			
			
			if (LocCountyCode == null)
				cmd.Parameters.Add("@LocCountyCode", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LocCountyCode", SqlDbType.VarChar, 100).Value = LocCountyCode;
			
			
			if (LocStateCode == null)
				cmd.Parameters.Add("@LocStateCode", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LocStateCode", SqlDbType.VarChar, 100).Value = LocStateCode;
			
			
			if (LocCityID == null)
				cmd.Parameters.Add("@LocCityID", SqlDbType.VarChar, 100).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@LocCityID", SqlDbType.VarChar, 100).Value = LocCityID;
			
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            

            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.Players> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Players p = new Business.Players();
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
                throw new Exception(string.Format("Players record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
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
            pkValues += "SteamID=" + SteamID.ToString();
            return pkValues + "]";
        }}
}
