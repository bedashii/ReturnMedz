using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.List
{
    public partial class ExtensionTypeList : List<Business.ExtensionType>
    {
        Data.ExtensionTypeData _data = new Data.ExtensionTypeData();

        public ExtensionTypeList()
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

        public void InsertItem(Business.ExtensionType extensionType)
        {
            extensionType.Insert();
        }

        public void DeleteItem(int id)
        {
            _data.DeleteItem(id);
        }
    }
}