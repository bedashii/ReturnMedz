using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Properties
{
    public partial class GenreProperties : PropertiesBase
    {
        public GenreProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                OnIDChanging();
                _id = value;
                base.HasChanged = true;
                OnIDChanged();
            }
        }

        partial void OnGenreNameChanging();
        partial void OnGenreNameChanged();
        private string _genreName;
        public string GenreName
        {
            get { return _genreName; }
            set
            {
                OnGenreNameChanging();
                _genreName = value;
                base.HasChanged = true;
                OnGenreNameChanged();
            }
        }
    }
}
