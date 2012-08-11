using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class InfoMovieProperties : PropertiesBase
    {

        public InfoMovieProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                OnIDChanging();
                _id = value;
                base.HasChanged = true;
                OnIDChanged();
            }
        }

        partial void OnNameChanging();
        partial void OnNameChanged();
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                OnNameChanging();
                _name = value;
                base.HasChanged = true;
                OnNameChanged();
            }
        }

        partial void OnIMDbIDChanging();
        partial void OnIMDbIDChanged();
        private string _iMDbID;
        public string IMDbID
        {
            get { return _iMDbID; }
            set
            {
                OnIMDbIDChanging();
                _iMDbID = value;
                base.HasChanged = true;
                OnIMDbIDChanged();
            }
        }

        partial void OnGenre1Changing();
        partial void OnGenre1Changed();
        private short? _genre1;
        public short? Genre1
        {
            get { return _genre1; }
            set
            {
                OnGenre1Changing();
                _genre1 = value;
                base.HasChanged = true;
                OnGenre1Changed();
            }
        }

        partial void OnGenre2Changing();
        partial void OnGenre2Changed();
        private short? _genre2;
        public short? Genre2
        {
            get { return _genre2; }
            set
            {
                OnGenre2Changing();
                _genre2 = value;
                base.HasChanged = true;
                OnGenre2Changed();
            }
        }

        partial void OnGenre3Changing();
        partial void OnGenre3Changed();
        private short? _genre3;
        public short? Genre3
        {
            get { return _genre3; }
            set
            {
                OnGenre3Changing();
                _genre3 = value;
                base.HasChanged = true;
                OnGenre3Changed();
            }
        }

        partial void OnRuntimeChanging();
        partial void OnRuntimeChanged();
        private string _runtime;
        public string Runtime
        {
            get { return _runtime; }
            set
            {
                OnRuntimeChanging();
                _runtime = value;
                base.HasChanged = true;
                OnRuntimeChanged();
            }
        }

        partial void OnRatingChanging();
        partial void OnRatingChanged();
        private decimal? _rating;
        public decimal? Rating
        {
            get { return _rating; }
            set
            {
                OnRatingChanging();
                _rating = value;
                base.HasChanged = true;
                OnRatingChanged();
            }
        }

        partial void OnReleaseYearChanging();
        partial void OnReleaseYearChanged();
        private int? _releaseYear;
        public int? ReleaseYear
        {
            get { return _releaseYear; }
            set
            {
                OnReleaseYearChanging();
                _releaseYear = value;
                base.HasChanged = true;
                OnReleaseYearChanged();
            }
        }

        partial void OnAgeRatingChanging();
        partial void OnAgeRatingChanged();
        private byte? _ageRating;
        public byte? AgeRating
        {
            get { return _ageRating; }
            set
            {
                OnAgeRatingChanging();
                _ageRating = value;
                base.HasChanged = true;
                OnAgeRatingChanged();
            }
        }

        partial void OnPlotChanging();
        partial void OnPlotChanged();
        private string _plot;
        public string Plot
        {
            get { return _plot; }
            set
            {
                OnPlotChanging();
                _plot = value;
                base.HasChanged = true;
                OnPlotChanged();
            }
        }

        partial void OnStorylineChanging();
        partial void OnStorylineChanged();
        private string _storyline;
        public string Storyline
        {
            get { return _storyline; }
            set
            {
                OnStorylineChanging();
                _storyline = value;
                base.HasChanged = true;
                OnStorylineChanged();
            }
        }

        partial void OnPosterChanging();
        partial void OnPosterChanged();
        private string _poster;
        public string Poster
        {
            get { return _poster; }
            set
            {
                OnPosterChanging();
                _poster = value;
                base.HasChanged = true;
                OnPosterChanged();
            }
        }
    }
}