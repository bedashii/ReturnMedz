using System.Collections.Generic;

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

        internal void GetAllByMenu(int menu)
        {
            _data.GetAllByMenu(this,menu);
        }
    }
}
