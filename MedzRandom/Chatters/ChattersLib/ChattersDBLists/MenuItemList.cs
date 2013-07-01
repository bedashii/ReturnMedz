using ChattersLib.ChattersDBBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattersLib.ChattersDBLists
{
    public class MenuItemList:List<ChattersLib.ChattersDBBusiness.MenuItem>
    {
        ChattersDBData.MenuItemData _data = new ChattersDBData.MenuItemData();

        public MenuItemList()
        {

        }

        public void GetAll()
        {
            this.Clear();
            _data.GetAll(this);
        }

        public void UpdateAll()
        {
            this.ForEach(x =>
                {
                    if (!x.RecordsExists)
                        x.Insert();
                    else if (x.AnyPropertyChanged)
                        x.Update();
                });
        }
    }
}
