using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLib.Magic
{
    public class Magic
    {
        public File File { get; set; }
        public Movie Movie { get; set; }
        
        public Magic()
        {
            File = new File();
            Movie = new Movie();
        }

        public void Open(string fullFileName)
        {
            File.Open(fullFileName);
            Movie.GetMovieName(File.FileName);
        }
    }
}
