using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class SpecialRequestsProperties : PropertiesBase
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

		partial void OnTeamChanging();
		partial void OnTeamChanged();
		protected int _team;
		public virtual int Team
		{
			get { return _team; }
			set
			{
				OnTeamChanging();
				_team = value;
				base.AnyPropertyChanged = true;
				OnTeamChanged();
			}
		}

		partial void OnPlayer64Changing();
		partial void OnPlayer64Changed();
		protected long _player64;
		public virtual long Player64
		{
			get { return _player64; }
			set
			{
				OnPlayer64Changing();
				_player64 = value;
				base.AnyPropertyChanged = true;
				OnPlayer64Changed();
			}
		}

		partial void OnDateRequestedChanging();
		partial void OnDateRequestedChanged();
		protected DateTime _dateRequested = new DateTime(1900, 01, 01);
		public virtual DateTime DateRequested
		{
			get { return _dateRequested; }
			set
			{
				if (value == DateTime.MinValue)
					_dateRequested = new DateTime(1900, 01, 01);
				else
					OnDateRequestedChanging();
				_dateRequested = value;
				base.AnyPropertyChanged = true;
				OnDateRequestedChanged();
			}
		}

		partial void OnDateRespondedChanging();
		partial void OnDateRespondedChanged();
		protected DateTime? _dateResponded;
		public virtual DateTime? DateResponded
		{
			get { return _dateResponded; }
			set
			{
				OnDateRespondedChanging();
				_dateResponded = value;
				base.AnyPropertyChanged = true;
				OnDateRespondedChanged();
			}
		}

    }
}