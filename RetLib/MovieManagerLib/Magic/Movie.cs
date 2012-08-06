using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using IMDb_Scraper;

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

        #endregion Properties

        public Movie()
        {
            _trim = new FileNameTrimmer();
            Genres = new List<string>();
        }

        public string GetMovieName(string fileName)
        {
            try
            {
                OriginalName = _trim.GetMovieName(fileName);
                IMDb imdb = new IMDb(OriginalName, true);
                SetMovieInfo(imdb);
                return null;
            }
            catch (Exception x)
            {
                return x.Message;
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
        }
    }

    public class FileNameTrimmer
    {
        private List<string> ExclusionList;

        public FileNameTrimmer()
        {
            ExclusionList = new List<string>();
            LoadExclusionList();
        }

        private void LoadExclusionList()
        {
            try
            {
                ExclusionList = System.IO.File.ReadAllLines(System.Configuration.ConfigurationSettings.AppSettings.Get("ExclusionList")).ToList();
            }
            catch (IOException) { }
            catch (Exception) { }
        }

        public string GetMovieName(string fileName)
        {
            string movie = "";
            string temp = "";
            string[] splitByPeriod = fileName.Split('.');

            foreach (string s in splitByPeriod)
                temp += s + ' ';

            string[] splitBySpace = temp.Split(' ');

            foreach (string s in splitBySpace)
            {
                if (CheckExclusionList(s) == false)
                    if (CheckForYear(s) == false)
                        movie += s + ' ';
                    else
                        break;
            }

            return movie.Trim();
        }

        private bool CheckForYear(string s)
        {
            try
            {
                int year = 0;

                if (s.StartsWith("("))
                    int.TryParse(s.Substring(1, 4), out year);
                else if (s.StartsWith("["))
                    int.TryParse(s.Substring(1, 4), out year);
                else
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
                if (ExclusionList.Exists(x => x == s))
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
