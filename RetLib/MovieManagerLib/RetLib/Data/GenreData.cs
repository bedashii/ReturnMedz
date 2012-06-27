using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Data
{
    public partial class GenreData: Properties.GenreProperties
    {
        private string _selectColumnNames = "G.[ID], G.[GenreName]";
        private DataHelper dataHelper;

        public GenreData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.GenreProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.GenreName = Convert.ToString(dr["GenreName"]);
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.Genres AS G\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.Genres SET [GenreName] = @GenreName\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@GenreName", SqlDbType.VarChar, 30).Value = GenreName;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Genres ([GenreName])\n";
            q += "VALUES (@GenreName)\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@GenreName", SqlDbType.VarChar, 30).Value = GenreName;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true;
            base.HasChanged = false;

            return up;
        }

        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.Genres \n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int id)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Genres m\n";
            q += "WHERE m.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.Genre> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Genre p = new Business.Genre();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.Genre> list)
        {
            PopulateList(list, GetData(""));
        }
    }
}
