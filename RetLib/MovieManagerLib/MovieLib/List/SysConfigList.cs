using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.List
{
    public partial class SysConfigList : List<Business.SysConfig>
    {
        Data.SysConfigData _data = new Data.SysConfigData();

        public SysConfigList()
        {
        }

        public void GetAll()
        {
            _data.LoadAll(this);
        }

        public void Refresh()
        {
            _data.PopulateList(this, _data.GetData(""));
        }

        public void ValidateAll()
        {
            foreach (var item in this)
            {
                if (item.HasChanged)
                {
                    item.ValidateFields();
                }
            }
        }

        public void UpdateAll()
        {
            this.ValidateAll();

            foreach (var item in this)
            {
                if (item.HasChanged)
                {
                    item.InsertOrUpdate();
                }
            }
        }

        public void InsertItem(Business.SysConfig sysConfig)
        {
            sysConfig.Insert();
        }
    }
}