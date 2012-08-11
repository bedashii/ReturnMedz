using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLib.List
{
    public partial class MovieGenreList :List<Business.MovieGenre>
    {
        Data.MovieGenreData _data = new Data.MovieGenreData();

        public MovieGenreList()
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

        public void InsertItem(Business.MovieGenre movieGenre)
        {
            movieGenre.Insert();
        }

        public void DeleteItem(int movie, short genre)
        {
            _data.DeleteItem(movie, genre);
        }
    }
}
