using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaLib.DotaDBProperties
{
    public class PlayerProperties : PropertiesBase
    {
        private int _steamId;
        private string _personaName;
        private string _locCityId;
        private string _locStateCode;
        private string _locCountryCode;
        private int _cityId;
        private string _gameExtraInfo;
        private string _profileUrl;
        private string _avatar;
        private string _avatarMedium;
        private string _avatarFull;
        private int _communityVisibilityState;
        private int _personaState;
        private int _profileState;
        private string _lastLogOff;
        private string _gameServerIp;
        private int _gameId;
        private string _timeCreated;
        private int _primaryClanId;
        private string _realName;
        private string _commentPermission;
        private int _teamId;

        public int SteamId
        {
            get { return _steamId; }
            set
            {
                if (_steamId != value)
                {
                    _steamId = value; if (RecordsExists) AnyPropertyChanged = true;
                }
            }
        }

        public string PersonaName
        {
            get { return _personaName; }
            set
            {
                if (_personaName != value)
                {
                    _personaName = value; 
                    if (RecordsExists) AnyPropertyChanged = true;
                }
            }
        }

        public string ProfileUrl
        {
            get { return _profileUrl; }
            set
            {
                if (_profileUrl != value)
                {
                    _profileUrl = value; 
                    if (RecordsExists) AnyPropertyChanged = true;
                }
            }
        }

        public string Avatar
        {
            get { return _avatar; }
            set
            {
                if (_avatar != value)
                {
                    _avatar = value; if (RecordsExists) AnyPropertyChanged = true;
                }
            }
        }

        public string AvatarMedium
        {
            get { return _avatarMedium; }
            set
            {
                if (_avatarMedium != value)
                {
                    _avatarMedium = value; if (RecordsExists) AnyPropertyChanged = true;
                }
            }
        }

        public string AvatarFull
        {
            get { return _avatarFull; }
            set
            {
                if (_avatarFull != value)
                {
                    _avatarFull = value; if (RecordsExists) AnyPropertyChanged = true;
                }
            }
        }

        public int PersonaState
        {
            get { return _personaState; }
            set
            {
                if (_personaState != value) { _personaState = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public int CommunityVisibilityState
        {
            get { return _communityVisibilityState; }
            set
            {
                if (_communityVisibilityState != value) { _communityVisibilityState = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public int ProfileState
        {
            get { return _profileState; }
            set
            {
                if (_profileState != value) { _profileState = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string LastLogOff
        {
            get { return _lastLogOff; }
            set
            {
                if (_lastLogOff != value) { _lastLogOff = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string CommentPermission
        {
            get { return _commentPermission; }
            set
            {
                if (_commentPermission != value) { _commentPermission = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string RealName
        {
            get { return _realName; }
            set
            {
                if (_realName != value) { _realName = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public int PrimaryClanId
        {
            get { return _primaryClanId; }
            set
            {
                if (_primaryClanId != value) { _primaryClanId = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string TimeCreated
        {
            get { return _timeCreated; }
            set
            {
                if (_timeCreated != value) { _timeCreated = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public int GameId
        {
            get { return _gameId; }
            set
            {
                if (_gameId != value) { _gameId = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string GameServerIp
        {
            get { return _gameServerIp; }
            set
            {
                if (_gameServerIp != value) { _gameServerIp = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string GameExtraInfo
        {
            get { return _gameExtraInfo; }
            set
            {
                if (_gameExtraInfo != value) { _gameExtraInfo = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public int CityId
        {
            get { return _cityId; }
            set
            {
                if (_cityId != value) { _cityId = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string LocCountryCode
        {
            get { return _locCountryCode; }
            set
            {
                if (_locCountryCode != value) { _locCountryCode = value; if (RecordsExists) AnyPropertyChanged = true; }
            }
        }

        public string LocStateCode
        {
            get { return _locStateCode; }
            set
            {
                if (_locStateCode != value)
                {
                    _locStateCode = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public string LocCityId
        {
            get { return _locCityId; }
            set
            {
                if (_locCityId != value)
                {
                    _locCityId = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        public int TeamId
        {
            get { return _teamId; }
            set
            {
                if (_teamId != value)
                {
                    _teamId = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }
    }
}
