using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RetLib.Data
{
    public partial class FileData : Properties.FileProperties
    {
        private string _selectColumnNames = "F.[ID], F.[Name], F.[Extension], F.[Size]";
        private DataHelper dataHelper;

        public FileData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.FileProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.Name = Convert.ToString(dr["Name"]);

            if ((dr["Extension"]) == DBNull.Value)
                row.Extension = null;
            else 
                row.Extension = Convert.ToString(dr["Extension"]);

            row.Size = Convert.ToDecimal(dr["Size"]);
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
            string q = "UPDATE dbo.File SET [ID] = @ID, [Name] = @Name, [Extension] = @Extension, [Size] = @Size\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = Name;

            if (Extension == null)
                cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 10).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 10).Value = Extension;
            cmd.Parameters.Add("@Size", SqlDbType.Decimal).Value = Size;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.File ( [ID], [Name], [Extension], [Size] )\n";
            q += "VALUES ( @ID, @Name, @Extension, @Size )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = Name;

            if (Extension == null)
                cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 10).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 10).Value = Extension;
            cmd.Parameters.Add("@Size", SqlDbType.Decimal).Value = Size;

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
    }
}