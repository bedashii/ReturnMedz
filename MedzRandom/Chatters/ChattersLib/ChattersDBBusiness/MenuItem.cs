using ChattersLib.ChattersDBData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattersLib.ChattersDBBusiness
{
    public class MenuItem : MenuItemData
    {
        internal void Insert()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "INSERT INTO MenuItems(Title,Description)\n";
            q+="Values(@Title,@Description)";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Title;
            cmd.Parameters.Add("@Description", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Description;

            dataHelper.ExecuteNonReader(cmd);
        }

        internal void Update()
        {
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();

            string q = "UPDATE MenuItems\n";
            q += "Title = @Title,\n";
            q += "Description = @Description\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@Title", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Title;
            cmd.Parameters.Add("@Description", System.Data.OleDb.OleDbType.WChar, 255).Value = this.Description;

            cmd.Parameters.Add("@ID", System.Data.OleDb.OleDbType.Integer).Value = this.ID;

            dataHelper.ExecuteNonReader(cmd);
        }
    }
}
