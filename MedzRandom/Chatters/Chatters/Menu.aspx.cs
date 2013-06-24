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
            Chatters.Controls.menuItem mi = null;
            for (int i = 0; i < 10; i++)
            {
                mi = Page.LoadControl("~/Controls/menuItem.ascx") as Chatters.Controls.menuItem;
                mi.Title = "THIS IS THE TEST TEXT TITLE " + (i+1);
                this.Controls.Add(mi);
            }
        }
    }
}