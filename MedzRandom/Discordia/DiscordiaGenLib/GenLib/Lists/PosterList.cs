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
            bool inserts = false;
            string insertQuery = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].RecordExists)
                {
                    if (this[i].AnyPropertiesChanged)
                        this[i].Update();
                }
                else
                {
                    insertQuery += this[i].AppendInsert(inserts);
                    inserts = true;
                }
            }

            if (inserts)
            {
                _data.MassInsert(insertQuery);
                this.ForEach(x =>
                    {
                        if (!x.RecordExists)
                            x.RecordExists = true;
                    });
            }


            //this.ForEach(x =>
            //{
            //    if (x.RecordExists)
            //    {
            //        if (x.AnyPropertiesChanged)
            //            x.Update();
            //    }
            //    else
            //        x.Insert();
            //});
        }

        public void GetByMovie(int movie)
        {
            _data.GetByMovie(movie, this);
        }
    }
}
