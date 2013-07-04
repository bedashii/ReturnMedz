using ChattersLib.ChattersDBData;

namespace ChattersLib.ChattersDBBusiness
{
    public class MenuItem : MenuItemData
    {
        private Menu menuMember = null;
        public Menu MenuMember
        {
            get
            {
                if (Menu != 0)
                {
                    menuMember = new Menu();
                    menuMember.LoadItemData(Menu);
                }
                return menuMember;
            }
        }

        public string MenuTitle
        {
            get
            {
                if (MenuMember != null)
                    return MenuMember.Title;
                else
                    return "";
            }
        }
    }
}
