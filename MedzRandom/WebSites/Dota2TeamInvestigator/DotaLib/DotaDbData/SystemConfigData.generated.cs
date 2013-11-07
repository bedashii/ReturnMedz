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
    public partial class SystemConfigData : Properties.SystemConfigProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "S.[ID], S.[SCKey], S.[SCValue], S.[IsActive]";

        public SystemConfigData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.SystemConfig S\n";
            q += "WHERE S.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<SystemConfig> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<SystemConfig> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.SystemConfig \n";
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
        internal void SetRowProperties(DataRow dr, Properties.SystemConfigProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.SCKey = Convert.ToString(dr["SCKey"]);
				row.SCValue = Convert.ToString(dr["SCValue"]);
				row.IsActive = Convert.ToBoolean(dr["IsActive"]);

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
            q += "FROM SystemConfig AS S\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.SystemConfig SET [SCKey] = @SCKey, [SCValue] = @SCValue, [IsActive] = @IsActive\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@SCKey", SqlDbType.VarChar, -1).Value = SCKey;
			cmd.Parameters.Add("@SCValue", SqlDbType.VarChar, 100).Value = SCValue;
			cmd.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = IsActive;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.SystemConfig ( [SCKey], [SCValue], [IsActive] )\n";
            q += "VALUES  ( @SCKey, @SCValue, @IsActive )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@SCKey", SqlDbType.VarChar, -1).Value = SCKey;
			cmd.Parameters.Add("@SCValue", SqlDbType.VarChar, 100).Value = SCValue;
			cmd.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = IsActive;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;


            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.SystemConfig> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.SystemConfig p = new Business.SystemConfig();
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
                throw new Exception(string.Format("SystemConfig record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
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
