using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Lists
{
    public class MovieList:List<Movie>
    {
        MovieData _data = new MovieData();

        public MovieList()
        {

        }

        public void GetAll()
        {
            this.Clear();
            this.AddRange(_data.GetAll());
        }
    }
}
