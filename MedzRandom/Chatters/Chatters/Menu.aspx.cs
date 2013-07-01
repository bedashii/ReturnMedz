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
            ChattersLib.ChattersDBLists.MenuItemList mil = new ChattersLib.ChattersDBLists.MenuItemList();
            

            Chatters.Controls.menuItem mi = null;

            foreach (ChattersLib.ChattersDBBusiness.MenuItem menuItem in mil)
            {
                mi = Page.LoadControl("~/Controls/menuItem.ascx") as Chatters.Controls.menuItem;
                mi.Title = menuItem.Title;
                mi.Description = menuItem.Description;
                //mi.Price = menuItem.Price;
                this.Controls.Add(mi);
            }
        }
    }
}