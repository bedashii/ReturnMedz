using DiscordiaGenLib.GenLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Business
{
    public class Poster:PosterData
    {
        public void GetByMovie(int tmdbID)
        {
            base.LoadItemByMovie(tmdbID);
        }

        public void Update()
        {
            base.Update();
        }
    }
}
