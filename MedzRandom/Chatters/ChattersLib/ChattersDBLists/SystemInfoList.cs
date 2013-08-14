using System.Collections.Generic;
using ChattersLib.ChattersDBBusiness;

namespace ChattersLib.ChattersDBLists
{
    public class SystemInfoList : List<SystemInfo>
    {
        ChattersDBData.SystemInfoData _data = new ChattersDBData.SystemInfoData();

        public SystemInfoList()
        {

        }

        public void GetAll()
        {
            Clear();
            _data.GetAll(this);
        }

        public void UpdateAll()
        {
            ForEach(x =>
                {
                    if (!x.RecordsExists)
                        x.Insert();
                    else if (x.AnyPropertyChanged)
                        x.Update();
                });
        }

        public void GetAll(string likeKey)
        {
            Clear();
            _data.GetAll(likeKey, this);
        }

        public void GetByKey(string key)
        {
            Clear();
            _data.GetByKey(key, this);
        }
    }
}
