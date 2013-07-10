using ChattersLib.ChattersDBData;
using ChattersLib.ChattersDBLists;

namespace ChattersLib.ChattersDBBusiness
{
    public class Menu:MenuData
    {
        private MenuItemList menuItems = null;
        public MenuItemList MenuItems
        {
            get
            {
                if (menuItems == null)
                    menuItems = new MenuItemList();
                return menuItems;
            }
            set
            {
                menuItems = value;
            }
        }

        public void GetMenuItems()
        {
            MenuItems.GetAllByMenu(ID);
        }
    }
}
