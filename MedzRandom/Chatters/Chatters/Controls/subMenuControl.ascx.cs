using ChattersLib.ChattersDBLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatters.Controls
{
    public partial class subMenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Title
        {
            get
            {
                return labelSubMenu.Text;
            }
            set
            {
                labelSubMenu.Text = value;
            }
        }

        private MenuItemList menuItems;
        public MenuItemList MenuItems
        {
            get
            {
                if (menuItems == null)
                {
                    menuItems = new MenuItemList();
                }
                return menuItems;
            }
            set
            {
                menuItems = value;
                updateMenuItems();
            }
        }

        private void updateMenuItems()
        {
            menuItemPanel.Controls.Clear();

            Chatters.Controls.menuItem mi = null;

            MenuItems.ForEach(menuItem =>
                {
                    mi = Page.LoadControl("~/Controls/menuItem.ascx") as Chatters.Controls.menuItem;
                    mi.Title = menuItem.Title;
                    mi.Description = menuItem.Description;
                    mi.Price = menuItem.Price.ToString("C");

                    menuItemPanel.Controls.Add(mi);

                    mi = null;
                });
        }
    }
}