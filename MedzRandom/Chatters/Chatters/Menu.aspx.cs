using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatters
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(AccessDataSource1.ConnectionString))
            {
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                cmd.CommandText="";
                cmd.CommandType= System.Data.CommandType.Text;

                try
                {
                    conn.Open();
                    System.Data.OleDb.OleDbDataReader reader = cmd.ExecuteReader();
                    while(reader)
                    {
                    }
                }
                catch(Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }

            Chatters.Controls.menuItem mi = null;
            for (int i = 0; i < 25; i++)
            {
                mi = Page.LoadControl("~/Controls/menuItem.ascx") as Chatters.Controls.menuItem;
                mi.Title = "Menu Item " + (i+1);
                this.Controls.Add(mi);
            }
        }
    }
}