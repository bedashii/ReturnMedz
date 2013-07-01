using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Properties
{
    public class PosterProperties : PropertiesBase
    {
        bool idSet = false;
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
                    if (idSet)
                        AnyPropertiesChanged = true;
                    else
                        idSet = true;
                }
            }
        }

        bool movieSet = false;
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
                    if (movieSet)
                        AnyPropertiesChanged = true;
                    else
                        movieSet = true;
                }
            }
        }

        bool urlSet = false;
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
                    if (urlSet)
                        AnyPropertiesChanged = true;
                    else
                        urlSet = true;
                }
            }
        }

        bool pathSet = false;
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
                    if (pathSet)
                        AnyPropertiesChanged = true;
                    else
                        pathSet = true;
                }
            }
        }

        bool widthSet = false;
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
                    if (widthSet)
                        AnyPropertiesChanged = true;
                    else
                        widthSet = true;
                }
            }
        }

        bool heightSet = false;
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
                    if (heightSet)
                        AnyPropertiesChanged = true;
                    else
                        heightSet = true;
                }
            }
        }
    }
}