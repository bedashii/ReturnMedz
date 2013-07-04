using ChattersLib.ChattersDBBusiness;
using System.Collections.Generic;

namespace ChattersLib.ChattersDBLists
{
    public class MenuList : List<Menu>
    {
        ChattersDBData.MenuData _data = new ChattersDBData.MenuData();

        public MenuList()
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