using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.List
{
    public partial class GenreTypesList : List<Business.GenreTypes>
    {
        Data.GenreTypesData _data = new Data.GenreTypesData();

        public GenreTypesList()
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

        public void InsertItem(Business.GenreTypes genreTypes)
        {
            genreTypes.Insert();
        }

        public void DeleteItem(int id)
        {
            _data.DeleteItem(id);
        }
    }
}