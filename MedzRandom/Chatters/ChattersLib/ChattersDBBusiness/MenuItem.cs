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
                if (menuMember == null)
                {
                    if (Menu != 0)
                    {
                        menuMember = Processors.MenuItemProcessor.MenuList.Find(x => x.ID == Menu);
                        if (menuMember == null)
                        {
                            menuMember = new Menu();
                            menuMember.LoadItemData(Menu);

                            Processors.MenuItemProcessor.MenuList.Add(menuMember);
                        }
                    }
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
