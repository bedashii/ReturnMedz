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
            }
        }

        void PopulateList(List<ChattersDBBusiness.MenuItem> list, DataTable reader)
        {
            foreach (DataRow dr in reader.Rows)
            {
                list.Add(new ChattersDBBusiness.MenuItem()
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Title = dr["Title"].ToString(),
                    Description = dr["Description"].ToString()
                });
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
    }
}