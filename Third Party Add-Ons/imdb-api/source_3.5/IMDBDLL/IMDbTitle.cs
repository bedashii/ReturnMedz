using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBDLL
{
    /// <summary>
    /// Class that represents a movie or tv serie
    /// </summary>
    public class IMDbTitle
    {
        private int media;
        private string title;
        private string year;
        private string id;
        private string url;
        private string coverURL;
        private string rating;
        private string tagline;
        private string plot;
        private string runtime;
        private List<string> genres;
        private List<IMDbDirCrea> directors;
        private List<IMDbSerieSeason> seasons;
        private List<IMDbActor> actors;

        /// <summary>
        /// If it's a movie or a tv serie
        /// </summary>
        public int Media { get { return media; } set { media = value; } }
        /// <summary>
        /// URL of the page of this title
        /// </summary>
        public string URL { get { return url; } set { url = value; } }
        /// <summary>
        /// Title of the title
        /// </summary>
        public string Title { get { return title; } set { title = value; } }
        /// <summary>
        /// Year of release of this title
        /// </summary>
        public string Year { get { return year; } set { year = value; } }
        /// <summary>
        /// IMDb ID of this title
        /// </summary>
        public string ID { get { return id; } set { id = value; } }
        /// <summary>
        /// URL to the main cover of this title
        /// </summary>
        public string CoverURL { get { return coverURL; } set { coverURL = value; } }
        /// <summary>
        /// IMDb User's rating
        /// </summary>
        public string Rating { get { return rating; } set { rating = value; } }
        /// <summary>
        /// The tagline of the title
        /// </summary>
        public string Tagline { get { return tagline; } set { tagline = value; } }
        /// <summary>
        /// Plot of the title
        /// </summary>
        public string Plot { get { return plot; } set { plot = value; } }
        /// <summary>
        /// Runtime in minutes of the title
        /// </summary>
        public string Runtime { get { return runtime; } set { runtime = value; } }
        /// <summary>
        /// List of genres of this title
        /// </summary>
        public List<string> Genres { get { return genres; } set { genres = value; } }
        /// <summary>
        /// List of directors/creators of this title
        /// </summary>
        public List<IMDbDirCrea> Directors { get { return directors; } set { directors = value; } }
        /// <summary>
        /// List of seasons of the serie
        /// </summary>
        public List<IMDbSerieSeason> Seasons { get { return seasons; } set { seasons = value; } }
        /// <summary>
        /// List of actors of this title
        /// </summary>
        public List<IMDbActor> Actors { get { return actors; } set { actors = value; } }
    }
}
