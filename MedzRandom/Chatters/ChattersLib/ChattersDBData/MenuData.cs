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
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT * FROM Menu WHERE ID = @ID";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = id;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            if (dt.Rows.Count > 0)
            {
                this.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                this.Title = dt.Rows[0]["Title"].ToString();
                this.Description = dt.Rows[0]["Description"].ToString();

                this.RecordsExists = true;
                this.AnyPropertyChanged = false;
            }
            else
                this.RecordsExists = false;
        }

        internal void GetAll(List<ChattersDBBusiness.Menu> list)
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT * FROM Menu";
            cmd.CommandType = System.Data.CommandType.Text;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            PopulateList(list, dt);
        }

        void PopulateList(List<ChattersDBBusiness.Menu> list, DataTable reader)
        {
            ChattersDBBusiness.Menu m = null;

            foreach (DataRow dr in reader.Rows)
            {
                m = new ChattersDBBusiness.Menu();

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
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "INSERT INTO Menu(Title,Description)\n";
            q += "Values(@Title,@Description)";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Title == null ? "" : this.Title;
            cmd.Parameters.Add("@Description", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Description == null ? "" : this.Description;

            dataHelper.ExecuteNonReader(cmd);

            this.RecordsExists = true;
            this.AnyPropertyChanged = false;
        }

        internal void Update()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "UPDATE Menu SET\n";
            q += "Title = @Title,\n";
            q += "Description = @Description\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Title == null ? "" : this.Title;
            cmd.Parameters.Add("@Description", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Description == null ? "" : this.Description;

            cmd.Parameters.Add("@ID", System.Data.OleDb.OleDbType.Integer).Value = this.ID;

            dataHelper.ExecuteNonReader(cmd);

            this.RecordsExists = true;
            this.AnyPropertyChanged = false;
        }

        public void Delete()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "DELETE FROM Menu\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@ID", System.Data.OleDb.OleDbType.Integer).Value = this.ID;

            dataHelper.ExecuteNonReader(cmd);
        }
    }
}
