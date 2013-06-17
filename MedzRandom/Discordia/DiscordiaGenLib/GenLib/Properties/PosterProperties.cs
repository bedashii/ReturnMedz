using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Properties
{
    public class PosterProperties : PropertiesBase
    {
        int _iD;
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                if (_iD != value)
                {
                    _iD = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        int _movie;
        public int Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                if (_movie != value)
                {
                    _movie = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        string _uRL;
        public string URL
        {
            get
            {
                return _uRL;
            }
            set
            {
                if (_uRL != value)
                {
                    _uRL = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        string _path;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    AnyPropertiesChanged = true;
                }
            }
        }
    }
}