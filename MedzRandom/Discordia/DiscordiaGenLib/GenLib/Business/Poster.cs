using DiscordiaGenLib.GenLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Business
{
    public class Poster : PosterData
    {
        public void GetByMovie(int tmdbID)
        {
            base.LoadItemByMovie(tmdbID);
        }

        public void Update()
        {
            base.Update();
        }

        internal string AppendInsert(bool append)
        {
            string query = "";
            if (append)
            {
                query += ",(" + Movie + ",'" + URL + "','" + Path + "'," + Width + "," + Height + ")";
            }
            else
            {
                query += "Insert INTO Posters(Movie,URL,Path, Width,Height)\n";
                query += "VALUES(" + Movie + ",'" + URL + "','" + Path + "'," + Width + "," + Height + ")";
            }
            return query;
        }
    }
}
