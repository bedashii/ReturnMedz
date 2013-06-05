using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Lists
{
    public class PosterList : List<Poster>
    {
        PosterData _data = new PosterData();

        public PosterList()
        {

        }

        public void InsertOrUpdateAll()
        {
            this.ForEach(x =>
            {
                if (x.RecordExists)
                {
                    if (x.AnyPropertiesChanged)
                        x.Update();
                }
                else
                    x.Insert();
            });
        }

        public void GetByMovie(int movie)
        {
            _data.GetByMovie(movie, this);
        }
    }
}
