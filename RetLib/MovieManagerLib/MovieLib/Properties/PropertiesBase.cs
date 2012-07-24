using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLib.Properties
{
    public partial class PropertiesBase
    {
        private bool _exists;
        public bool Exists
        {
            get { return _exists; }
            set { _exists = value; }
        }

        private bool _hasChanged;
        public bool HasChanged
        {
            get { return _hasChanged; }
            set { _hasChanged = value; }
        }
    }
}
