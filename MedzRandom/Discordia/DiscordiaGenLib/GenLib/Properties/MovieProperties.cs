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

        bool titleSet = false;
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
                    if (titleSet)
                        AnyPropertiesChanged = true;
                    else
                        titleSet = true;
                }
            }
        }

        bool synposisSet = false;
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
                    if (synposisSet)
                        AnyPropertiesChanged = true;
                    else
                        synposisSet = true;
                }
            }
        }

        bool yearSet = false;
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
                    if (yearSet)
                        AnyPropertiesChanged = true;
                    else
                        yearSet = true;
                }
            }
        }

        bool durationSet = false;
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
                    if (durationSet)
                        AnyPropertiesChanged = true;
                    else
                        durationSet = true;
                }
            }
        }

        bool ratingSet = false;
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
                    if (ratingSet)
                        AnyPropertiesChanged = true;
                    else
                        ratingSet = true;
                }
            }
        }

        bool ageRestrictionSet = false;
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
                    if (ageRestrictionSet)
                        AnyPropertiesChanged = true;
                    else
                        ageRestrictionSet = true;
                }
            }
        }

        bool tmdbidSet = false;
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
                    if (tmdbidSet)
                        AnyPropertiesChanged = true;
                    else
                        tmdbidSet = true;
                }
            }
        }
    }
}