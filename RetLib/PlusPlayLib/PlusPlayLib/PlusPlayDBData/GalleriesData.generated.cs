using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PlusPlayDBGenLib.Business;


/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace PlusPlayDBGenLib.Data
{
    public partial class GalleriesData : Properties.GalleriesProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "G.[ID], G.[Model], G.[GalleryName], G.[GalleryDirectory], G.[CoverPhoto]";

        public GalleriesData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Galleries G\n";
            q += "WHERE G.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<Galleries> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<Galleries> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.Galleries \n";
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
        internal void SetRowProperties(DataRow dr, Properties.GalleriesProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.Model = Convert.ToInt32(dr["Model"]);
				row.GalleryName = Convert.ToString(dr["GalleryName"]);
				row.GalleryDirectory = Convert.ToString(dr["GalleryDirectory"]);

				if ((dr["CoverPhoto"]) == DBNull.Value)
					row.CoverPhoto = null;
				else
					row.CoverPhoto = Convert.ToString(dr["CoverPhoto"]);

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
            q += "FROM Galleries AS G\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.Galleries SET [Model] = @Model, [GalleryName] = @GalleryName, [GalleryDirectory] = @GalleryDirectory, [CoverPhoto] = @CoverPhoto\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@Model", SqlDbType.Int, 4).Value = Model;
			cmd.Parameters.Add("@GalleryName", SqlDbType.VarChar, 100).Value = GalleryName;
			cmd.Parameters.Add("@GalleryDirectory", SqlDbType.VarChar, 256).Value = GalleryDirectory;
			
			if (CoverPhoto == null)
				cmd.Parameters.Add("@CoverPhoto", SqlDbType.VarChar, 256).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CoverPhoto", SqlDbType.VarChar, 256).Value = CoverPhoto;
			
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Galleries ( [Model], [GalleryName], [GalleryDirectory], [CoverPhoto] )\n";
            q += "VALUES  ( @Model, @GalleryName, @GalleryDirectory, @CoverPhoto )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@Model", SqlDbType.Int, 4).Value = Model;
			cmd.Parameters.Add("@GalleryName", SqlDbType.VarChar, 100).Value = GalleryName;
			cmd.Parameters.Add("@GalleryDirectory", SqlDbType.VarChar, 256).Value = GalleryDirectory;
			
			if (CoverPhoto == null)
				cmd.Parameters.Add("@CoverPhoto", SqlDbType.VarChar, 256).Value = DBNull.Value;
			else
				cmd.Parameters.Add("@CoverPhoto", SqlDbType.VarChar, 256).Value = CoverPhoto;
			
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;


            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.Galleries> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Galleries p = new Business.Galleries();
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
                throw new Exception(string.Format("Galleries record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
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
