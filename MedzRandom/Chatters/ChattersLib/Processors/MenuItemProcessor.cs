using ChattersLib.ChattersDBLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattersLib.Processors
{
    public static class MenuItemProcessor
    {
        private static MenuList menuList;
        public static MenuList MenuList
        {
            get
            {
                if (menuList == null)
                    menuList = new MenuList();
                return menuList;
            }
            set
            {
                menuList = value;
            }
        }
    }
}
