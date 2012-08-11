using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieLib.Business;
using MovieLib.List;

namespace ReturnMovieManagerWF.Processors
{
    public class MovieAddProcessor
    {
        public InfoFile _infoFile;
        public InfoMovie _infoMovie;

        MovieLib.Magic.Magic _magic;
        PreferencesProcessor2 _preferences;

        public MovieAddProcessor()
        {
            _infoFile = new InfoFile();
            _infoMovie = new InfoMovie();
            _preferences = new PreferencesProcessor2();
        }

        public void GetInfo(string fullFileName)
        {
            _magic = new MovieLib.Magic.Magic();
            _magic.OpenFile(fullFileName);

            if (_magic.File.FileName != null && _magic.File.FileName != "")
            {
                _magic.OpenMovie();
                SetFileProperties();
            }

            if (_magic.Movie.MovieName != null && _magic.Movie.MovieName != "")
                SetMovieProperties();
        }

        #region Properties

        #endregion Properties

        #region SetMethods

        private void SetFileProperties()
        {
            _infoFile.FileName = _magic.File.FileName;
            _infoFile.FullFileName = _magic.File.FullFileName;
            _infoFile.Extension = _preferences.GetExtensionID(_magic.File.Extension);
            SetAudioLanguages();
            _infoFile.FileSize = _magic.File.FileSizeMB;
            _infoFile.Duration = _magic.File.DurationM;
        }

        private void SetMovieProperties()
        {
            _infoMovie.Name = _magic.Movie.MovieName;
            _infoMovie.IMDbID = _magic.Movie.IMDbID;
            SetGenres();
            _infoMovie.Runtime = _magic.Movie.Runtime;
            _infoMovie.Rating = _magic.Movie.Rating;
            _infoMovie.ReleaseYear = _magic.Movie.Year;
            _infoMovie.AgeRating = _preferences.GetAgeRatingID(_magic.Movie.MPAARating);
            _infoMovie.Plot = _magic.Movie.Plot;
            _infoMovie.Storyline = _magic.Movie.Storyline;
            _infoMovie.Poster = new SysConfig("DefaultMoviePoster").Config;

            foreach (string poster in _magic.Movie.Posters)
                if (poster != "" && poster != null)
                {
                    _infoMovie.Poster = poster;
                    break;
                }
        }

        #endregion SetMethods

        #region MinorSetMethods

        private void SetAudioLanguages()
        {
            for (int i = 0; i < _magic.File.AudioLanguages.Count; i++)
                if (_magic.File.AudioLanguages[i] != null || _magic.File.AudioLanguages[i] != "")
                    switch (i)
                    {
                        case 0:
                            _infoFile.AudioLanguage1 = _preferences.GetAudioLanguageID(_magic.File.AudioLanguages[i]);
                            break;
                        case 1:
                            _infoFile.AudioLanguage2 = _preferences.GetAudioLanguageID(_magic.File.AudioLanguages[i]);
                            break;
                        case 2:
                            _infoFile.AudioLanguage3 = _preferences.GetAudioLanguageID(_magic.File.AudioLanguages[i]);
                            break;
                    }
        }

        private void SetGenres()
        {
            for (int i = 0; i < _magic.File.AudioLanguages.Count - 1; i++)
                if (_magic.Movie.Genres[i] != null || _magic.Movie.Genres[i] != "")
                    switch (i)
                    {
                        case 0:
                            _infoMovie.Genre1 = _preferences.GetGenreID(_magic.Movie.Genres[i]);
                            break;
                        case 1:
                            _infoMovie.Genre2 = _preferences.GetGenreID(_magic.Movie.Genres[i]);
                            break;
                        case 2:
                            _infoMovie.Genre3 = _preferences.GetGenreID(_magic.Movie.Genres[i]);
                            break;
                    }
        }

        #endregion MinorSetMethods


    }
}
