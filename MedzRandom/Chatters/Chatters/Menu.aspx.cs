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
            ChattersLib.ChattersDBLists.MenuList menuList = new ChattersLib.ChattersDBLists.MenuList();
            menuList.GetAll();

            Chatters.Controls.subMenuControl subMenu = null;

            menuList.ForEach(x =>
                {
                    x.GetMenuItems();

                    subMenu = Page.LoadControl("~/Controls/subMenuControl.ascx") as Chatters.Controls.subMenuControl;
                    subMenu.Title = x.Title;
                    subMenu.MenuItems = x.MenuItems;

                    this.Controls.Add(subMenu);

                    subMenu = null;
                });
        }
    }
}