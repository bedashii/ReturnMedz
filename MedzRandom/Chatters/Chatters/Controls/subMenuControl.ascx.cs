using System.Web.UI;
using ChattersLib.ChattersDBLists;
using System;

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

        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }

        private MenuItemList menuItems;
        public MenuItemList MenuItems
        {
            get { return menuItems ?? (menuItems = new MenuItemList()); }
            set
            {
                menuItems = value;
                updateMenuItems();
            }
        }

        public bool Collapsed
        {
            get { return CollapsiblePanelExtenderItemLinksPanel.Collapsed; }
            set { CollapsiblePanelExtenderItemLinksPanel.Collapsed = value; }
        }

        private void updateMenuItems()
        {
            foreach (Control control in menuItemPanel.Controls)
            {
                if (control.GetType() == typeof(subMenuControl))
                    menuItemPanel.Controls.Remove(control);
            }

            //menuItemPanel.Controls.Clear();

            MenuItems.ForEach(menuItem =>
                {
                    menuItem mi = Page.LoadControl("~/Controls/menuItem.ascx") as menuItem;
                    if (mi != null)
                    {
                        mi.Title = menuItem.Title;
                        mi.Description = menuItem.Description;
                        mi.Price = menuItem.Price.ToString("C");

                        menuItemPanel.Controls.Add(mi);
                    }
                });
        }
    }
}