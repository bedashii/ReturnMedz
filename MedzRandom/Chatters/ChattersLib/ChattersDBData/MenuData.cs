using ChattersLib.ChattersDBProperties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ChattersLib.ChattersDBData
{
    public class MenuData : MenuProperties
    {
        internal DataHelper dataHelper = new DataHelper();

        public MenuData()
        {

        }

        internal void LoadItemData(int id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM Menu WHERE ID = @ID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = id;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            if (dt.Rows.Count > 0)
            {
                ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                Title = dt.Rows[0]["Title"].ToString();
                Description = dt.Rows[0]["Description"].ToString();

                RecordsExists = true;
                AnyPropertyChanged = false;
            }
            else
                RecordsExists = false;
        }

        internal void GetAll(List<ChattersDBBusiness.Menu> list)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM Menu";
            cmd.CommandType = CommandType.Text;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            PopulateList(list, dt);
        }

        void PopulateList(List<ChattersDBBusiness.Menu> list, DataTable reader)
        {
            foreach (DataRow dr in reader.Rows)
            {
                ChattersDBBusiness.Menu m = new ChattersDBBusiness.Menu();

                if (dr["ID"] != DBNull.Value)
                    m.ID = Convert.ToInt32(dr["ID"]);
                if (dr["Title"] != DBNull.Value)
                    m.Title = dr["Title"].ToString();
                if (dr["Description"] != DBNull.Value)
                    m.Description = dr["Description"].ToString();

                m.RecordsExists = true;
                m.AnyPropertyChanged = false;

                list.Add(m);
            }
        }

        internal void Insert()
        {
            OleDbCommand cmd = new OleDbCommand();

            string q = "INSERT INTO Menu(Title,Description)\n";
            q += "Values(@Title,@Description)";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", OleDbType.WChar, 255).Value = Title ?? "";
            cmd.Parameters.Add("@Description", OleDbType.WChar, 255).Value = Description ?? "";

            dataHelper.ExecuteNonReader(cmd);

            RecordsExists = true;
            AnyPropertyChanged = false;
        }

        internal void Update()
        {
            OleDbCommand cmd = new OleDbCommand();

            string q = "UPDATE Menu SET\n";
            q += "Title = @Title,\n";
            q += "Description = @Description\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", OleDbType.WChar, 255).Value = Title ?? "";
            cmd.Parameters.Add("@Description", OleDbType.WChar, 255).Value = Description ?? "";

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

            dataHelper.ExecuteNonReader(cmd);

            RecordsExists = true;
            AnyPropertyChanged = false;
        }

        public void Delete()
        {
            OleDbCommand cmd = new OleDbCommand();

            string q = "DELETE FROM Menu\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

            dataHelper.ExecuteNonReader(cmd);
        }
    }
}
