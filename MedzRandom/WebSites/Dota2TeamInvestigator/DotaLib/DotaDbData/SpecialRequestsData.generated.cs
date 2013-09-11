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
    public partial class SpecialRequestsData : Properties.SpecialRequestsProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "S.[ID], S.[Team], S.[Player64], S.[DateRequested], S.[DateResponded]";

        public SpecialRequestsData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.SpecialRequests S\n";
            q += "WHERE S.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        internal void LoadItemDataByDateResponded(List<SpecialRequests> list,DateTime dateResponded)
		{
			string q = "SELECT " + _selectColumnNames + " FROM dbo.SpecialRequests S\n";
			q += "WHERE S.DateResponded = @DateResponded"; 

			SqlCommand cmd = dataHelper.CreateCommand(q);

			cmd.Parameters.Add("@DateResponded", SqlDbType.DateTime, 8).Value = dateResponded;

			PopulateList(list, dataHelper.ExecuteQuery(cmd));
		}

		

        internal void LoadAll(List<SpecialRequests> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<SpecialRequests> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.SpecialRequests \n";
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
        internal void SetRowProperties(DataRow dr, Properties.SpecialRequestsProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.Team = Convert.ToInt32(dr["Team"]);
				row.Player64 = Convert.ToInt64(dr["Player64"]);
				row.DateRequested = Convert.ToDateTime(dr["DateRequested"]);

				if ((dr["DateResponded"]) == DBNull.Value)
					row.DateResponded = null;
				else
					row.DateResponded = Convert.ToDateTime(dr["DateResponded"]);

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
            q += "FROM SpecialRequests AS S\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.SpecialRequests SET [Team] = @Team, [Player64] = @Player64, [DateRequested] = @DateRequested, [DateResponded] = @DateResponded\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@Team", SqlDbType.Int, 4).Value = Team;
			cmd.Parameters.Add("@Player64", SqlDbType.BigInt, 8).Value = Player64;
			cmd.Parameters.Add("@DateRequested", SqlDbType.DateTime, 8).Value = DateRequested;
			
			if (DateResponded == null)
				cmd.Parameters.Add("@DateResponded", SqlDbType.DateTime, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@DateResponded", SqlDbType.DateTime, 8).Value = DateResponded;
			
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.SpecialRequests ( [Team], [Player64], [DateRequested], [DateResponded] )\n";
            q += "VALUES  ( @Team, @Player64, @DateRequested, @DateResponded )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@Team", SqlDbType.Int, 4).Value = Team;
			cmd.Parameters.Add("@Player64", SqlDbType.BigInt, 8).Value = Player64;
			cmd.Parameters.Add("@DateRequested", SqlDbType.DateTime, 8).Value = DateRequested;
			
			if (DateResponded == null)
				cmd.Parameters.Add("@DateResponded", SqlDbType.DateTime, 8).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@DateResponded", SqlDbType.DateTime, 8).Value = DateResponded;
			
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;


            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.SpecialRequests> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.SpecialRequests p = new Business.SpecialRequests();
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
                throw new Exception(string.Format("SpecialRequests record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
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
