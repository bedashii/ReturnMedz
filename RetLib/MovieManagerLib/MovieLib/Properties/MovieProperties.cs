using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class MovieProperties : PropertiesBase
    {

        public MovieProperties()
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

        partial void OnGenreMainChanging();
        partial void OnGenreMainChanged();
        private short _genreMain;
        public short GenreMain
        {
            get { return _genreMain; }
            set
            {
                OnGenreMainChanging();
                _genreMain = value;
                base.HasChanged = true;
                OnGenreMainChanged();
            }
        }

        partial void OnGenreSubChanging();
        partial void OnGenreSubChanged();
        private short? _genreSub;
        public short? GenreSub
        {
            get { return _genreSub; }
            set
            {
                OnGenreSubChanging();
                _genreSub = value;
                base.HasChanged = true;
                OnGenreSubChanged();
            }
        }

        partial void OnRuntimeChanging();
        partial void OnRuntimeChanged();
        private byte _runtime;
        public byte Runtime
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

        partial void OnIMDBRatingChanging();
        partial void OnIMDBRatingChanged();
        private decimal? _iMDBRating;
        public decimal? IMDBRating
        {
            get { return _iMDBRating; }
            set
            {
                OnIMDBRatingChanging();
                _iMDBRating = value;
                base.HasChanged = true;
                OnIMDBRatingChanged();
            }
        }

        partial void OnYearOfReleaseChanging();
        partial void OnYearOfReleaseChanged();
        private int? _yearOfRelease;
        public int? YearOfRelease
        {
            get { return _yearOfRelease; }
            set
            {
                OnYearOfReleaseChanging();
                _yearOfRelease = value;
                base.HasChanged = true;
                OnYearOfReleaseChanged();
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

        partial void OnPlotSummaryChanging();
        partial void OnPlotSummaryChanged();
        private string _plotSummary;
        public string PlotSummary
        {
            get { return _plotSummary; }
            set
            {
                OnPlotSummaryChanging();
                _plotSummary = value;
                base.HasChanged = true;
                OnPlotSummaryChanged();
            }
        }
    }
}