using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Data
{
    public partial class FormatData:Properties.FormatProperties
    {
        private string _selectColumnNames = "F.[ID], F.[FormatName], F.[FormatExtension]";
        private DataHelper dataHelper;

        public FormatData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.FormatProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.FormatName = Convert.ToString(dr["FormatName"]);
            row.FormatExtension = Convert.ToString(dr["FormatExtension"]);
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.Formats AS G\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.Formats SET [FormatName] = @FormatName\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@FormatName", SqlDbType.VarChar, 30).Value = FormatName;
            cmd.Parameters.Add("@FormatExtension", SqlDbType.VarChar, 10).Value = FormatExtension;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Formats ([FormatName], [FormatExtension])\n";
            q += "VALUES (@FormatName, @FormatExtension)\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@FormatName", SqlDbType.VarChar, 30).Value = FormatName;
            cmd.Parameters.Add("@FormatExtension", SqlDbType.VarChar, 30).Value = FormatExtension;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true;
            base.HasChanged = false;

            return up;
        }

        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.Formats \n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int id)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Formats m\n";
            q += "WHERE m.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.Format> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Format p = new Business.Format();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.Format> list)
        {
            PopulateList(list, GetData(""));
        }
    }
}
