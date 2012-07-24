using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class Movie : Data.MovieData
    {

        public Movie()
        {
        }

        public Movie(int id)
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

        public void SetProperties(MovieLib.Business.Movie properties)
        {
            this.ID = properties.ID;
            this.Name = properties.Name;
            this.GenreMain = properties.GenreMain;
            this.GenreSub = properties.GenreSub;
            this.Runtime = properties.Runtime;
            this.IMDBRating = properties.IMDBRating;
            this.YearOfRelease = properties.YearOfRelease;
            this.AgeRating = properties.AgeRating;
            this.PlotSummary = properties.PlotSummary;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }
    }
}