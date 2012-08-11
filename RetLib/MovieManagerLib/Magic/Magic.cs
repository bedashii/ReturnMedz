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

        public void OpenFile(string fullFileName)
        {
            File.Open(fullFileName);
        }

        public void OpenMovie(string fileName)
        {
            Movie.GetMovieName(fileName, null);
        }

        public void OpenMovie()
        {
            Movie.GetMovieName(File.FileName, File.ParentFolder);
        }
    }
}
