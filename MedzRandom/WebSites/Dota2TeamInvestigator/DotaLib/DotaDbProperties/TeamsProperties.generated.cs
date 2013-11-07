using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class TeamsProperties : PropertiesBase
    {
		partial void OnIDChanging();
		partial void OnIDChanged();
		protected int _iD;
		public virtual int ID
		{
			get { return _iD; }
			set
			{
				OnIDChanging();
				_iD = value;
				base.AnyPropertyChanged = true;
				OnIDChanged();
			}
		}

		partial void OnTeamNameChanging();
		partial void OnTeamNameChanged();
		protected string _teamName;
		public virtual string TeamName
		{
			get { return _teamName; }
			set
			{
				OnTeamNameChanging();
				_teamName = value;
				base.AnyPropertyChanged = true;
				OnTeamNameChanged();
			}
		}

		partial void OnTagChanging();
		partial void OnTagChanged();
		protected string _tag;
		public virtual string Tag
		{
			get { return _tag; }
			set
			{
				OnTagChanging();
				_tag = value;
				base.AnyPropertyChanged = true;
				OnTagChanged();
			}
		}

		partial void OnTimeCreatedChanging();
		partial void OnTimeCreatedChanged();
		protected string _timeCreated;
		public virtual string TimeCreated
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

		partial void OnRatingChanging();
		partial void OnRatingChanged();
		protected string _rating;
		public virtual string Rating
		{
			get { return _rating; }
			set
			{
				OnRatingChanging();
				_rating = value;
				base.AnyPropertyChanged = true;
				OnRatingChanged();
			}
		}

		partial void OnLogoChanging();
		partial void OnLogoChanged();
		protected string _logo;
		public virtual string Logo
		{
			get { return _logo; }
			set
			{
				OnLogoChanging();
				_logo = value;
				base.AnyPropertyChanged = true;
				OnLogoChanged();
			}
		}

		partial void OnLogoSponsorChanging();
		partial void OnLogoSponsorChanged();
		protected string _logoSponsor;
		public virtual string LogoSponsor
		{
			get { return _logoSponsor; }
			set
			{
				OnLogoSponsorChanging();
				_logoSponsor = value;
				base.AnyPropertyChanged = true;
				OnLogoSponsorChanged();
			}
		}

		partial void OnCountryCodeChanging();
		partial void OnCountryCodeChanged();
		protected string _countryCode;
		public virtual string CountryCode
		{
			get { return _countryCode; }
			set
			{
				OnCountryCodeChanging();
				_countryCode = value;
				base.AnyPropertyChanged = true;
				OnCountryCodeChanged();
			}
		}

		partial void OnURLChanging();
		partial void OnURLChanged();
		protected string _uRL;
		public virtual string URL
		{
			get { return _uRL; }
			set
			{
				OnURLChanging();
				_uRL = value;
				base.AnyPropertyChanged = true;
				OnURLChanged();
			}
		}

		partial void OnGamesPlayedChanging();
		partial void OnGamesPlayedChanged();
		protected int? _gamesPlayed;
		public virtual int? GamesPlayed
		{
			get { return _gamesPlayed; }
			set
			{
				OnGamesPlayedChanging();
				_gamesPlayed = value;
				base.AnyPropertyChanged = true;
				OnGamesPlayedChanged();
			}
		}

		partial void OnAdminAccountChanging();
		partial void OnAdminAccountChanged();
		protected int? _adminAccount;
		public virtual int? AdminAccount
		{
			get { return _adminAccount; }
			set
			{
				OnAdminAccountChanging();
				_adminAccount = value;
				base.AnyPropertyChanged = true;
				OnAdminAccountChanged();
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

		partial void OnDateRequestedChanging();
		partial void OnDateRequestedChanged();
		protected DateTime? _dateRequested;
		public virtual DateTime? DateRequested
		{
			get { return _dateRequested; }
			set
			{
				OnDateRequestedChanging();
				_dateRequested = value;
				base.AnyPropertyChanged = true;
				OnDateRequestedChanged();
			}
		}

    }
}