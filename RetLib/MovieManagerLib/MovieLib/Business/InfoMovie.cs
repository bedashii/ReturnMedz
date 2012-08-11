using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class InfoMovie : Data.InfoMovieData
    {

        public InfoMovie()
        {
        }

        public InfoMovie(int id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public void LoadItem(int id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        public void Refresh(int id)
        {
            base.LoadItemData(id);
        }

        public void SetProperties(MovieLib.Business.InfoMovie properties)
        {
            this.ID = properties.ID;
            this.Name = properties.Name;
            this.IMDbID = properties.IMDbID;
            this.Genre1 = properties.Genre1;
            this.Genre2 = properties.Genre2;
            this.Genre3 = properties.Genre3;
            this.Runtime = properties.Runtime;
            this.Rating = properties.Rating;
            this.ReleaseYear = properties.ReleaseYear;
            this.AgeRating = properties.AgeRating;
            this.Plot = properties.Plot;
            this.Storyline = properties.Storyline;
            this.Poster = properties.Poster;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }
    }
}