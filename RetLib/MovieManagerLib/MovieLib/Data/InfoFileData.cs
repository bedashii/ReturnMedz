using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class InfoFileData : Properties.InfoFileProperties
    {
        private string _selectColumnNames = "I.[ID], I.[FileName], I.[FullFileName], I.[Extension], I.[AudioLanguage1], I.[AudioLanguage2], I.[AudioLanguage3], I.[FileSize], I.[Duration]";
        private DataHelper dataHelper;

        public InfoFileData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.InfoFileProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.FileName = Convert.ToString(dr["FileName"]);
            row.FullFileName = Convert.ToString(dr["FullFileName"]);
            row.Extension = Convert.ToByte(dr["Extension"]);
            if ((dr["AudioLanguage1"]) == DBNull.Value)
                row.AudioLanguage1 = null;
            else
                row.AudioLanguage1 = Convert.ToInt16(dr["AudioLanguage1"]);

            if ((dr["AudioLanguage2"]) == DBNull.Value)
                row.AudioLanguage2 = null;
            else
                row.AudioLanguage2 = Convert.ToInt16(dr["AudioLanguage2"]);

            if ((dr["AudioLanguage3"]) == DBNull.Value)
                row.AudioLanguage3 = null;
            else
                row.AudioLanguage3 = Convert.ToInt16(dr["AudioLanguage3"]);

            row.FileSize = Convert.ToDecimal(dr["FileSize"]);
            row.Duration = Convert.ToInt32(dr["Duration"]);
            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.InfoFile AS I\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.InfoFile SET [ID] = @ID, [FileName] = @FileName, [FullFileName] = @FullFileName, [Extension] = @Extension, [AudioLanguage1] = @AudioLanguage1, [AudioLanguage2] = @AudioLanguage2, [AudioLanguage3] = @AudioLanguage3, [FileSize] = @FileSize, [Duration] = @Duration\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@FileName", SqlDbType.VarChar, 150).Value = FileName;

            cmd.Parameters.Add("@FullFileName", SqlDbType.VarChar, 400).Value = FullFileName;

            cmd.Parameters.Add("@Extension", SqlDbType.TinyInt).Value = Extension;

            if (AudioLanguage1 == null)
                cmd.Parameters.Add("@AudioLanguage1", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AudioLanguage1", SqlDbType.SmallInt).Value = AudioLanguage1;


            if (AudioLanguage2 == null)
                cmd.Parameters.Add("@AudioLanguage2", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AudioLanguage2", SqlDbType.SmallInt).Value = AudioLanguage2;


            if (AudioLanguage3 == null)
                cmd.Parameters.Add("@AudioLanguage3", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AudioLanguage3", SqlDbType.SmallInt).Value = AudioLanguage3;

            cmd.Parameters.Add("@FileSize", SqlDbType.Decimal).Value = FileSize;
            cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = Duration;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.InfoFile ( [ID], [FileName], [FullFileName], [Extension], [AudioLanguage1], [AudioLanguage2], [AudioLanguage3], [FileSize], [Duration] )\n";
            q += "VALUES ( @ID, @FileName, @FullFileName, @Extension, @AudioLanguage1, @AudioLanguage2, @AudioLanguage3, @FileSize, @Duration )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@FileName", SqlDbType.VarChar, 150).Value = FileName;

            cmd.Parameters.Add("@FullFileName", SqlDbType.VarChar, 400).Value = FullFileName;

            cmd.Parameters.Add("@Extension", SqlDbType.TinyInt).Value = Extension;

            if (AudioLanguage1 == null)
                cmd.Parameters.Add("@AudioLanguage1", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AudioLanguage1", SqlDbType.SmallInt).Value = AudioLanguage1;


            if (AudioLanguage2 == null)
                cmd.Parameters.Add("@AudioLanguage2", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AudioLanguage2", SqlDbType.SmallInt).Value = AudioLanguage2;


            if (AudioLanguage3 == null)
                cmd.Parameters.Add("@AudioLanguage3", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AudioLanguage3", SqlDbType.SmallInt).Value = AudioLanguage3;

            cmd.Parameters.Add("@FileSize", SqlDbType.Decimal).Value = FileSize;
            cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = Duration;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.InfoFile\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.InfoFile I\n";
            q += "WHERE I.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.InfoFile> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.InfoFile p = new Business.InfoFile();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.InfoFile> list)
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