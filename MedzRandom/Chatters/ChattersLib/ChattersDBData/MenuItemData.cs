using ChattersLib.ChattersDBProperties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattersLib.ChattersDBData
{
    public class MenuItemData : MenuItemProperties
    {
        internal DataHelper dataHelper = new DataHelper();

        public MenuItemData()
        {

        }

        internal void LoadItemData(int id)
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT * FROM MenuItem WHERE ID = @ID";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = id;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            if (dt.Rows.Count > 0)
            {
                this.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                this.Title = dt.Rows[0]["Title"].ToString();
                this.Description = dt.Rows[0]["Description"].ToString();
                this.Price = Convert.ToDecimal(dt.Rows[0]["Price"]);
                this.RecordsExists = true;
            }
        }

        internal void GetAll(List<ChattersDBBusiness.MenuItem> list)
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandText = "SELECT * FROM MenuItem";
            cmd.CommandType = System.Data.CommandType.Text;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            PopulateList(list, dt);
        }

        void PopulateList(List<ChattersDBBusiness.MenuItem> list, DataTable reader)
        {
            ChattersDBBusiness.MenuItem mi = null;

            foreach (DataRow dr in reader.Rows)
            {
                mi = new ChattersDBBusiness.MenuItem();

                if (dr["ID"] != DBNull.Value)
                    mi.ID = Convert.ToInt32(dr["ID"]);
                if (dr["Title"] != DBNull.Value)
                    mi.Title = dr["Title"].ToString();
                if (dr["Description"] != DBNull.Value)
                    mi.Description = dr["Description"].ToString();
                if (dr["Price"] != DBNull.Value)
                    mi.Price = Convert.ToDecimal(dr["Price"]);

                mi.RecordsExists = true;

                list.Add(mi);
            }
        }

        internal void Insert()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "INSERT INTO MenuItem(Title,Description,Price)\n";
            q += "Values(@Title,@Description,@Price)";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Title;
            cmd.Parameters.Add("@Description", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Description;
            cmd.Parameters.Add("@Price", System.Data.OleDb.OleDbType.Currency).Value = this.Price;

            dataHelper.ExecuteNonReader(cmd);

            this.AnyPropertyChanged = false;
            this.RecordsExists = true;
        }

        internal void Update()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "UPDATE MenuItem SET\n";
            q += "Title = @Title,\n";
            q += "Description = @Description,\n";
            q += "Price = @Price\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Title;
            cmd.Parameters.Add("@Description", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Description;
            cmd.Parameters.Add("@Price", System.Data.OleDb.OleDbType.Currency).Value = this.Price;

            cmd.Parameters.Add("@ID", System.Data.OleDb.OleDbType.Integer).Value = this.ID;

            dataHelper.ExecuteNonReader(cmd);

            this.AnyPropertyChanged = false;
            this.RecordsExists = true;
        }

        public void Delete()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "DELETE FROM MenuItem\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@ID", System.Data.OleDb.OleDbType.Integer).Value = this.ID;

            dataHelper.ExecuteNonReader(cmd);
        }
    }
}