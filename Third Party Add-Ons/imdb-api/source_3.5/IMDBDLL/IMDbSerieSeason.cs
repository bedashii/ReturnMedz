using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBDLL
{
    /// <summary>
    /// Class that represents a season from a serie
    /// </summary>
    public class IMDbSerieSeason
    {
        private int number;
        private List<IMDbSerieEpisode> episodes;

        /// <summary>
        /// Season number
        /// </summary>
        public int Number { get { return number; } set { number = value; } }
        /// <summary>
        /// List of the episodes of this season
        /// </summary>
        public List<IMDbSerieEpisode> Episodes { get { return episodes; } set { episodes = value; } }
    }
}
