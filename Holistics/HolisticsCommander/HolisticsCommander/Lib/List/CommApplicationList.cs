using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolisticsCommander.Lib.List
{
    public class CommApplicationList : List<Business.CommApplication>
    {
        Data.CommApplicationData _data = new Data.CommApplicationData();

        internal void GetAll()
        {
            _data.LoadCommApps(this);
        }

        internal void UpdateAll()
        {
            _data.UpdateCommApp(this);
        }

        internal void Delete(Business.CommApplication item)
        {
            _data.DeleteItem(item);
            this.Remove(item);
        }
    }
}
