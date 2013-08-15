using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolisticsCommander.Lib.Properties
{
    public partial class CommApplicationProperties
    {
        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                _hasChanged = true;
            }
        }

        private string _name;
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _hasChanged = true;
            }
        }

        private string _path;
        public virtual string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                _hasChanged = true;
            }
        }

        protected bool _recordExists = false;
        public bool RecordExists
        {
            get { return _recordExists; }
        }

        protected bool _hasChanged = false;
        public bool HasChanged
        {
            get { return _hasChanged; }
        }
    }
}
