using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class MovieGenre : Data.MovieGenreData
    {
        public MovieGenre()
        {
        }

        public MovieGenre(int movie, short genre)
        {
            PreConstructionTasks();
            this.LoadItemData(movie, genre);
            PostConstructionTasks();
        }

        public void LoadItem(int movie, short genre)
        {
            this.Movie = movie;
            this.Genre = genre;
            base.LoadItemData(movie, genre);
        }

        public void Refresh(int movie, short genre)
        {
            base.LoadItemData(movie, genre);
        }

        public void SetProperties(MovieLib.Business.MovieGenre properties)
        {
            this.Movie = properties.Movie;
            this.Genre = properties.Genre;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }

    }
}
