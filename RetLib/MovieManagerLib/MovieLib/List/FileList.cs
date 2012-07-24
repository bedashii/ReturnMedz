using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.List
{
    public partial class FileList : List<Business.File>
    {
        Data.FileData _data = new Data.FileData();

        public FileList()
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

        public void InsertItem(Business.File file)
        {
            file.Insert();
        }
    }
}