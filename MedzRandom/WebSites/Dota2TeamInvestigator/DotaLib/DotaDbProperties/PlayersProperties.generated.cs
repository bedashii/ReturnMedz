using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class PlayersProperties : PropertiesBase
    {
		partial void OnSteamIDChanging();
		partial void OnSteamIDChanged();
		protected int _steamID;
		public virtual int SteamID
		{
			get { return _steamID; }
			set
			{
				OnSteamIDChanging();
				_steamID = value;
				base.AnyPropertyChanged = true;
				OnSteamIDChanged();
			}
		}

		partial void OnSteamID64Changing();
		partial void OnSteamID64Changed();
		protected long? _steamID64;
		public virtual long? SteamID64
		{
			get { return _steamID64; }
			set
			{
				OnSteamID64Changing();
				_steamID64 = value;
				base.AnyPropertyChanged = true;
				OnSteamID64Changed();
			}
		}

		partial void OnPersonaNameChanging();
		partial void OnPersonaNameChanged();
		protected string _personaName;
		public virtual string PersonaName
		{
			get { return _personaName; }
			set
			{
				OnPersonaNameChanging();
				_personaName = value;
				base.AnyPropertyChanged = true;
				OnPersonaNameChanged();
			}
		}

		partial void OnProfileURLChanging();
		partial void OnProfileURLChanged();
		protected string _profileURL;
		public virtual string ProfileURL
		{
			get { return _profileURL; }
			set
			{
				OnProfileURLChanging();
				_profileURL = value;
				base.AnyPropertyChanged = true;
				OnProfileURLChanged();
			}
		}

		partial void OnAvatarChanging();
		partial void OnAvatarChanged();
		protected string _avatar;
		public virtual string Avatar
		{
			get { return _avatar; }
			set
			{
				OnAvatarChanging();
				_avatar = value;
				base.AnyPropertyChanged = true;
				OnAvatarChanged();
			}
		}

		partial void OnAvatarMediumChanging();
		partial void OnAvatarMediumChanged();
		protected string _avatarMedium;
		public virtual string AvatarMedium
		{
			get { return _avatarMedium; }
			set
			{
				OnAvatarMediumChanging();
				_avatarMedium = value;
				base.AnyPropertyChanged = true;
				OnAvatarMediumChanged();
			}
		}

		partial void OnAvatarFullChanging();
		partial void OnAvatarFullChanged();
		protected string _avatarFull;
		public virtual string AvatarFull
		{
			get { return _avatarFull; }
			set
			{
				OnAvatarFullChanging();
				_avatarFull = value;
				base.AnyPropertyChanged = true;
				OnAvatarFullChanged();
			}
		}

		partial void OnPersonaStateChanging();
		partial void OnPersonaStateChanged();
		protected int? _personaState;
		public virtual int? PersonaState
		{
			get { return _personaState; }
			set
			{
				OnPersonaStateChanging();
				_personaState = value;
				base.AnyPropertyChanged = true;
				OnPersonaStateChanged();
			}
		}

		partial void OnCommunityVisibilityStateChanging();
		partial void OnCommunityVisibilityStateChanged();
		protected int? _communityVisibilityState;
		public virtual int? CommunityVisibilityState
		{
			get { return _communityVisibilityState; }
			set
			{
				OnCommunityVisibilityStateChanging();
				_communityVisibilityState = value;
				base.AnyPropertyChanged = true;
				OnCommunityVisibilityStateChanged();
			}
		}

		partial void OnProfileStateChanging();
		partial void OnProfileStateChanged();
		protected int? _profileState;
		public virtual int? ProfileState
		{
			get { return _profileState; }
			set
			{
				OnProfileStateChanging();
				_profileState = value;
				base.AnyPropertyChanged = true;
				OnProfileStateChanged();
			}
		}

		partial void OnLastLogOffChanging();
		partial void OnLastLogOffChanged();
		protected DateTime? _lastLogOff;
		public virtual DateTime? LastLogOff
		{
			get { return _lastLogOff; }
			set
			{
				OnLastLogOffChanging();
				_lastLogOff = value;
				base.AnyPropertyChanged = true;
				OnLastLogOffChanged();
			}
		}

		partial void OnCommentPermissionChanging();
		partial void OnCommentPermissionChanged();
		protected string _commentPermission;
		public virtual string CommentPermission
		{
			get { return _commentPermission; }
			set
			{
				OnCommentPermissionChanging();
				_commentPermission = value;
				base.AnyPropertyChanged = true;
				OnCommentPermissionChanged();
			}
		}

		partial void OnRealNameChanging();
		partial void OnRealNameChanged();
		protected string _realName;
		public virtual string RealName
		{
			get { return _realName; }
			set
			{
				OnRealNameChanging();
				_realName = value;
				base.AnyPropertyChanged = true;
				OnRealNameChanged();
			}
		}

		partial void OnPrimaryClanIDChanging();
		partial void OnPrimaryClanIDChanged();
		protected long? _primaryClanID;
		public virtual long? PrimaryClanID
		{
			get { return _primaryClanID; }
			set
			{
				OnPrimaryClanIDChanging();
				_primaryClanID = value;
				base.AnyPropertyChanged = true;
				OnPrimaryClanIDChanged();
			}
		}

		partial void OnTimeCreatedChanging();
		partial void OnTimeCreatedChanged();
		protected DateTime? _timeCreated;
		public virtual DateTime? TimeCreated
		{
			get { return _timeCreated; }
			set
			{
				OnTimeCreatedChanging();
				_timeCreated = value;
				base.AnyPropertyChanged = true;
				OnTimeCreatedChanged();
			}
		}

		partial void OnGameIDChanging();
		partial void OnGameIDChanged();
		protected int? _gameID;
		public virtual int? GameID
		{
			get { return _gameID; }
			set
			{
				OnGameIDChanging();
				_gameID = value;
				base.AnyPropertyChanged = true;
				OnGameIDChanged();
			}
		}

		partial void OnGameServerIDChanging();
		partial void OnGameServerIDChanged();
		protected string _gameServerID;
		public virtual string GameServerID
		{
			get { return _gameServerID; }
			set
			{
				OnGameServerIDChanging();
				_gameServerID = value;
				base.AnyPropertyChanged = true;
				OnGameServerIDChanged();
			}
		}

		partial void OnGameExtraInfoChanging();
		partial void OnGameExtraInfoChanged();
		protected string _gameExtraInfo;
		public virtual string GameExtraInfo
		{
			get { return _gameExtraInfo; }
			set
			{
				OnGameExtraInfoChanging();
				_gameExtraInfo = value;
				base.AnyPropertyChanged = true;
				OnGameExtraInfoChanged();
			}
		}

		partial void OnCityIDChanging();
		partial void OnCityIDChanged();
		protected int? _cityID;
		public virtual int? CityID
		{
			get { return _cityID; }
			set
			{
				OnCityIDChanging();
				_cityID = value;
				base.AnyPropertyChanged = true;
				OnCityIDChanged();
			}
		}

		partial void OnLocCountyCodeChanging();
		partial void OnLocCountyCodeChanged();
		protected string _locCountyCode;
		public virtual string LocCountyCode
		{
			get { return _locCountyCode; }
			set
			{
				OnLocCountyCodeChanging();
				_locCountyCode = value;
				base.AnyPropertyChanged = true;
				OnLocCountyCodeChanged();
			}
		}

		partial void OnLocStateCodeChanging();
		partial void OnLocStateCodeChanged();
		protected string _locStateCode;
		public virtual string LocStateCode
		{
			get { return _locStateCode; }
			set
			{
				OnLocStateCodeChanging();
				_locStateCode = value;
				base.AnyPropertyChanged = true;
				OnLocStateCodeChanged();
			}
		}

		partial void OnLocCityIDChanging();
		partial void OnLocCityIDChanged();
		protected string _locCityID;
		public virtual string LocCityID
		{
			get { return _locCityID; }
			set
			{
				OnLocCityIDChanging();
				_locCityID = value;
				base.AnyPropertyChanged = true;
				OnLocCityIDChanged();
			}
		}

		partial void OnLastUpdatedChanging();
		partial void OnLastUpdatedChanged();
		protected DateTime _lastUpdated = new DateTime(1900, 01, 01);
		public virtual DateTime LastUpdated
		{
			get { return _lastUpdated; }
			set
			{
				if (value == DateTime.MinValue)
					_lastUpdated = new DateTime(1900, 01, 01);
				else
					OnLastUpdatedChanging();
				_lastUpdated = value;
				base.AnyPropertyChanged = true;
				OnLastUpdatedChanged();
			}
		}

		partial void OnOldestMatchFoundChanging();
		partial void OnOldestMatchFoundChanged();
		protected bool _oldestMatchFound;
		public virtual bool OldestMatchFound
		{
			get { return _oldestMatchFound; }
			set
			{
				OnOldestMatchFoundChanging();
				_oldestMatchFound = value;
				base.AnyPropertyChanged = true;
				OnOldestMatchFoundChanged();
			}
		}

		partial void OnIsPrivateChanging();
		partial void OnIsPrivateChanged();
		protected bool? _isPrivate;
		public virtual bool? IsPrivate
		{
			get { return _isPrivate; }
			set
			{
				OnIsPrivateChanging();
				_isPrivate = value;
				base.AnyPropertyChanged = true;
				OnIsPrivateChanged();
			}
		}

    }
}