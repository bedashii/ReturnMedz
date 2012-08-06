using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBDLL
{
    /// <summary>
    /// Class that represents a result from a search
    /// </summary>
    public class IMDbLink
    {
        private string title;
        private string year;
        private string titLink;
        private string titCov;
        private string category;
        private int media;

        /// <summary>
        /// URL to the main page of the title
        /// </summary>
        public string URL { get { return titLink; } set { titLink = value; } }
        /// <summary>
        /// Cover of the title
        /// </summary>
        public string Cover { get { return titCov; } set { titCov = value; } }
        /// <summary>
        /// Section on wich this result was
        /// </summary>
        public string Category { get { return category; } set { category = value; } }
        /// <summary>
        /// Title of the title that this result represents
        /// </summary>
        public string Title { get { return title; } set { title = value; } }
        /// <summary>
        /// Year of release of the title
        /// </summary>
        public string Year { get { return year; } set { year = value; } }
        /// <summary>
        /// If it's a serie or a movie
        /// </summary>
        public int Media { get { return media; } set { media = value; } }

    }
}
