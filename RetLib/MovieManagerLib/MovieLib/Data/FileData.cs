using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class FileData : Properties.FileProperties
    {
        private string _selectColumnNames = "F.[ID], F.[Name], F.[Size], F.[ExtensionID], F.[VideoQuality], F.[AudioQuality]";
        private DataHelper dataHelper;

        public FileData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.FileProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.Name = Convert.ToString(dr["Name"]);
            row.Size = Convert.ToDecimal(dr["Size"]);
            row.ExtensionID = Convert.ToInt16(dr["ExtensionID"]);
            if ((dr["VideoQuality"]) == DBNull.Value)
                row.VideoQuality = null;
            else
                row.VideoQuality = Convert.ToByte(dr["VideoQuality"]);

            row.AudioQuality = Convert.ToByte(dr["AudioQuality"]);
            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.File AS F\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.File SET [ID] = @ID, [Name] = @Name, [Size] = @Size, [ExtensionID] = @ExtensionID, [VideoQuality] = @VideoQuality, [AudioQuality] = @AudioQuality\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = Name;

            cmd.Parameters.Add("@Size", SqlDbType.Decimal).Value = Size;
            cmd.Parameters.Add("@ExtensionID", SqlDbType.SmallInt).Value = ExtensionID;

            if (VideoQuality == null)
                cmd.Parameters.Add("@VideoQuality", SqlDbType.TinyInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@VideoQuality", SqlDbType.TinyInt).Value = VideoQuality;

            cmd.Parameters.Add("@AudioQuality", SqlDbType.TinyInt).Value = AudioQuality;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.File ( [ID], [Name], [Size], [ExtensionID], [VideoQuality], [AudioQuality] )\n";
            q += "VALUES ( @ID, @Name, @Size, @ExtensionID, @VideoQuality, @AudioQuality )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = Name;

            cmd.Parameters.Add("@Size", SqlDbType.Decimal).Value = Size;
            cmd.Parameters.Add("@ExtensionID", SqlDbType.SmallInt).Value = ExtensionID;

            if (VideoQuality == null)
                cmd.Parameters.Add("@VideoQuality", SqlDbType.TinyInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@VideoQuality", SqlDbType.TinyInt).Value = VideoQuality;

            cmd.Parameters.Add("@AudioQuality", SqlDbType.TinyInt).Value = AudioQuality;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }
        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.File\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.File F\n";
            q += "WHERE F.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        internal void PopulateList(List<Business.File> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.File p = new Business.File();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }
        internal void LoadAll(List<Business.File> list)
        {
            PopulateList(list, GetData(""));
        }

        public virtual void ValidateFields()
        { }

        public virtual void Update()
        {
            ValidateFields();
            Data.UpdateProperties up = this.UpdateData();
            if (up.RowsAffected == 0)
                throw new Exception(string.Format("Applications record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
        }

        public virtual void Insert()
        {
            ValidateFields();
            this.InsertData();
        }

        public virtual void InsertOrUpdate()
        {
            if (this.Exists)
                this.Update();
            else
                this.Insert();
        }

        public string GetPrimaryKeyValues()
        {
            string pkValues = "PK:[";
            pkValues += "ID=" + ID.ToString();
            return pkValues + "]";
        }
    }
}