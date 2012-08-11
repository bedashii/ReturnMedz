using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using IMDb_Scraper;
using System.Net;


namespace MovieLib.Magic
{
    public class Movie
    {
        #region Declarations

        FileNameTrimmer _trim;

        #endregion Declarations

        #region Properties

        public string OriginalName { get; set; }
        public string MovieName { get; set; }
        public string IMDbID { get; set; }
        public List<string> Genres { get; set; }
        public string Runtime { get; set; }
        public decimal Rating { get; set; }
        public int Year { get; set; }
        public string MPAARating { get; set; }
        public string Storyline { get; set; }
        public string Plot { get; set; }
        public List<string> Posters { get; set; }

        #endregion Properties

        public Movie()
        {
            _trim = new FileNameTrimmer();
            Genres = new List<string>();
            Posters = new List<string>();
        }

        public bool GetMovieName(string fileName, string parentFolder)
        {
            try
            {
                OriginalName = _trim.GetMovieName(fileName);
                IMDb imdb = new IMDb(OriginalName, true);

                if (imdb.Title != "")
                {
                    SetMovieInfo(imdb);
                    return true;
                }

                imdb = new IMDb(parentFolder, true);

                if (imdb.Title != "" && parentFolder != null && parentFolder != "")
                {
                    SetMovieInfo(imdb);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetMovieInfo(IMDb imdb)
        {
            MovieName = imdb.Title;
            MovieName += imdb.OriginalTitle != "" ? "(" + imdb.OriginalTitle + ")" : "";
            IMDbID = imdb.Id;

            foreach (string s in imdb.Genres)
                Genres.Insert(Genres.Count, s);

            Runtime = imdb.Runtime;
            Rating = Convert.ToDecimal(imdb.Rating);
            Year = Convert.ToInt16(imdb.Year);
            MPAARating = imdb.MpaaRating;
            Storyline = imdb.Storyline.Replace("&#x27;", "'");

            if (imdb.Plot.Contains(@"<a href=""plotsummary"">"))
                Plot = imdb.Plot.Substring(0, imdb.Plot.IndexOf(@"<a href=""plotsummary"">")).Replace("&#x27;", "'");
            else
                Plot = imdb.Plot.Replace("&#x27;", "'");

            Posters.Add(imdb.Poster);
            Posters.Add(imdb.PosterSmall);
            Posters.Add(imdb.PosterLarge);
            Posters.Add(imdb.PosterFull);
        }
    }

    public class FileNameTrimmer
    {
        private List<string> _exclusionList;
        private List<string> _trimmingsList;
        private MovieLib.List.ExtensionTypeList _extensionsList;

        public FileNameTrimmer()
        {
            _exclusionList = new List<string>();
            _trimmingsList = new List<string>();
            _extensionsList = new List.ExtensionTypeList();
            _extensionsList.GetAll();

            LoadLists();
        }

        private void LoadLists()
        {
            try
            {
                _exclusionList = System.IO.File.ReadAllLines(System.Configuration.ConfigurationSettings.AppSettings.Get("ExclusionList")).ToList();
                _trimmingsList = System.IO.File.ReadAllLines(System.Configuration.ConfigurationSettings.AppSettings.Get("Trimmings")).ToList();
            }
            catch (IOException) { }
            catch (Exception) { }
        }

        public string GetMovieName(string fileName)
        {
            string movie = "";

            RemoveTrimmings(ref fileName);

            List<string> fileNameList = fileName.Split(' ').ToList();

            foreach (string s in fileNameList)
            {
                if (CheckExclusionList(s) == false)
                    if (CheckForYear(s) == false)
                        movie += s + ' ';
                    else
                        break;
            }

            return movie.Trim();
        }

        private void RemoveTrimmings(ref string fileName)
        {
            foreach (string s in _trimmingsList)
                fileName = fileName.Replace(s, " ");
        }

        private bool CheckForYear(string s)
        {
            try
            {
                int year = 0;
                int.TryParse(s.Substring(0, 4), out year);

                if (year >= 1900 && year <= DateTime.Today.Year)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CheckExclusionList(string s)
        {
            try
            {
                if (_exclusionList.Exists(x => x == s))
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
