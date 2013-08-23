using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaLib.DotaDBProperties
{
    public class TeamProperties : PropertiesBase
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private string _teamName;
        private string _tag;
        private string _timeCreated;
        private string _logo;
        private int _adminAccount;
        private int _gamesPlayed;
        private string _url;
        private string _countryCode;
        private string _logoSponsor;
        private string _rating;

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                if (_teamName != value)
                {
                    _teamName = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string Tag
        {
            get { return _tag; }
            set
            {
                if (_tag != value)
                {
                    _tag = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if (_timeCreated != value)
                {
                    _timeCreated = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string Rating
        {
            get { return _rating; }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo != value)
                {
                    _logo = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string LogoSponsor
        {
            get { return _logoSponsor; }
            set
            {
                if (_logoSponsor != value)
                {
                    _logoSponsor = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string CountryCode
        {
            get { return _countryCode; }
            set
            {
                if (_countryCode != value)
                {
                    _countryCode = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set
            {
                if (_gamesPlayed != value)
                {
                    _gamesPlayed = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public int AdminAccount
        {
            get { return _adminAccount; }
            set
            {
                if (_adminAccount != value)
                {
                    _adminAccount = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }
    }
}
