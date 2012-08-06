using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDBDLL
{
    /// <summary>
    /// Class that represents an actor.
    /// </summary>
    public class IMDbActor
    {
        private string name;
        private string url;
        private string photoURL;
        private string character;

        /// <summary>
        /// Name of the actor
        /// </summary>
        public string Name { get { return name; } set { name = value; } }
        /// <summary>
        /// URL of the IMDb page of the actor
        /// </summary>
        public string URL { get { return url; } set { url = value; } }
        /// <summary>
        /// URL of the main photo of the actor
        /// </summary>
        public string PhotoURL { get { return photoURL; } set { photoURL = value; } }
        /// <summary>
        /// Name of the character played by this actor in the title
        /// </summary>
        public string Character { get { return character; } set { character = value; } }
    }
}
