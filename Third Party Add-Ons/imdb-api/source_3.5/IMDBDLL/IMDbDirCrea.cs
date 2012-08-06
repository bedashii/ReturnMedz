using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBDLL
{
    /// <summary>
    /// Class that represents a director or creator
    /// </summary>
    public class IMDbDirCrea
    {
        private int type;
        private string name;
        private string url;

        /// <summary>
        /// The name of this person
        /// </summary>
        public string Name { get { return name; } set { name = value; } }
        /// <summary>
        /// URL of the IMDb page of this person
        /// </summary>
        public string URL { get { return url; } set { url = value; } }
        /// <summary>
        /// Type of this person (director or creator)
        /// </summary>
        public int Type { get { return type; } set { type = value; } }
    }
}
