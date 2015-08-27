using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TempDataGenLib.Business;


/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace TempDataGenLib.Data
{
    public partial class DecksData : Properties.DecksProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "D.[ID], D.[Name], D.[Hero]";

        public DecksData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Decks D\n";
            q += "WHERE D.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<Decks> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<Decks> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.Decks \n";
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
        internal void SetRowProperties(DataRow dr, Properties.DecksProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.Name = Convert.ToString(dr["Name"]);
				row.Hero = Convert.ToByte(dr["Hero"]);

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
            q += "FROM dbo.Decks AS D\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.Decks SET [Name] = @Name, [Hero] = @Hero\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = Name;
			cmd.Parameters.Add("@Hero", SqlDbType.TinyInt, 1).Value = Hero;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Decks ( [Name], [Hero] )\n";
            q += "VALUES  ( @Name, @Hero )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = Name;
			cmd.Parameters.Add("@Hero", SqlDbType.TinyInt, 1).Value = Hero;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = Convert.ToInt32(up.Identity);


            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.Decks> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Decks p = new Business.Decks();
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
                throw new Exception(string.Format("Decks record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
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
