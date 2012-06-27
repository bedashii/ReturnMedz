using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Lists
{
    public partial class MovieList : List<Business.Movie>
    {
        Data.MovieData _data = new Data.MovieData();
        
        public void GetAll()
        {
            _data.LoadAll(this);
        }

        public void GetByGenre(int genre)
        {
            _data.LoadByGenre(this, genre);
        }
    }
}
