using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBDLL
{
    /// <summary>
    /// Class that represents an episode of a serie
    /// </summary>
    public class IMDbSerieEpisode
    {
        private int number;
        private string title;
        private string airDate;
        private string plot;

        /// <summary>
        /// Episode number
        /// </summary>
        public int Number { get { return number; } set { number = value; } }
        /// <summary>
        /// Title of the episode
        /// </summary>
        public string Title { get { return title; } set { title = value; } }
        /// <summary>
        /// Original air date of the episode
        /// </summary>
        public string AirDate { get { return airDate; } set { airDate = value; } }
        /// <summary>
        /// Plot of this episode
        /// </summary>
        public string Plot { get { return plot; } set { plot = value; } }
    }
}
