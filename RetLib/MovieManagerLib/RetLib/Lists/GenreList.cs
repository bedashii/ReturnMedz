using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Lists
{
    public class GenreList: List<Business.Genre>
    {
        Data.GenreData _data = new Data.GenreData();

        public void GetAll()
        {
            _data.LoadAll(this);
        }
    }
}
