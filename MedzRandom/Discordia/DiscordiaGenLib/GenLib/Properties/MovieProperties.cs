using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Properties
{
    public class MovieProperties:PropertiesBase
    {
        //int _iD;
        //public int ID
        //{
        //    get
        //    {
        //        return _iD;
        //    }
        //    set
        //    {
        //        if (_iD != value)
        //        {
        //            _iD = value;
        //            AnyPropertiesChanged = true;
        //        }
        //    }
        //}

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        string _synopsis;
        public string Synopsis
        {
            get
            {
                return _synopsis;
            }
            set
            {
                if (_synopsis != value)
                {
                    _synopsis = value;
                    AnyPropertiesChanged = true;
                }
            }
        }
        
        int _year;
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (_year != value)
                {
                    _year = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        double _rating;
        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        string _ageRestriction;
        public string AgeRestriction
        {
            get
            {
                return _ageRestriction;
            }
            set
            {
                if (_ageRestriction != value)
                {
                    _ageRestriction = value;
                    AnyPropertiesChanged = true;
                }
            }
        }

        int _tMDBID;
        public int TMDBID
        {
            get
            {
                return _tMDBID;
            }
            set
            {
                if (_tMDBID != value)
                {
                    _tMDBID = value;
                    AnyPropertiesChanged = true;
                }
            }
        }
    }
}