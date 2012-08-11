using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.List
{
    public partial class InfoFileList : List<Business.InfoFile>
    {
        Data.InfoFileData _data = new Data.InfoFileData();

        public InfoFileList()
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

        public void InsertItem(Business.InfoFile infoFile)
        {
            infoFile.Insert();
        }
    }
}