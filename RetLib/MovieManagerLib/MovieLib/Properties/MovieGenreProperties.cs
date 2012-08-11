using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class MovieGenreProperties: PropertiesBase
    {
        public MovieGenreProperties()
        {
        }

        partial void OnMovieChanging();
        partial void OnMovieChanged();
        private int _movie;
        public int Movie
        {
            get { return _movie; }
            set
            {
                OnMovieChanging();
                _movie = value;
                base.HasChanged = true;
                OnMovieChanged();
            }
        }

        partial void OnGenreChanging();
        partial void OnGenreChanged();
        private short _genre;
        public short Genre
        {
            get { return _genre; }
            set
            {
                OnGenreChanging();
                _genre = value;
                base.HasChanged = true;
                OnGenreChanged();
            }
        }
    }
}
