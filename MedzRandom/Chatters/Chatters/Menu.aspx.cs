using System;
using System.Collections.Generic;
using Chatters.Controls;

namespace Chatters
{
    public partial class Menu : System.Web.UI.Page
    {
        private List<subMenuControl> subMenues;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChattersLib.ChattersDBLists.MenuList menuList = new ChattersLib.ChattersDBLists.MenuList();
            menuList.GetAll();

            if (subMenues == null)
                subMenues = new List<subMenuControl>();

            menuList.ForEach(x =>
                {
                    x.GetMenuItems();

                    subMenuControl subMenu = Page.LoadControl("~/Controls/subMenuControl.ascx") as subMenuControl;
                    if (subMenu != null)
                    {
                        subMenu.ID = "subMenu" + x.ID;
                        subMenu.Title = x.Title;
                        subMenu.MenuItems = x.MenuItems;
                        subMenu.Collapsed = false;

                        subMenues.Add(subMenu);
                        placeHolderSubMenus.Controls.Add(subMenu);
                    }
                });

            if (Request.QueryString["Sub"] != null)
            {
                //int indexOf = placeHolderSubMenus.Controls.IndexOf(subMenues.Find(x => x.ID == "subMenu" + x.ID));
                foreach (subMenuControl subMenu in placeHolderSubMenus.Controls)
                {
                    subMenu.Collapsed = subMenu.ID != "subMenu" + Request.QueryString["Sub"];
                }
            }
        }
    }
}