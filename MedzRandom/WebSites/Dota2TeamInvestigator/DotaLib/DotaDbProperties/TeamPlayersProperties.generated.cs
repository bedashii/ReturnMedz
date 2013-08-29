using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class TeamPlayersProperties : PropertiesBase
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

		partial void OnPlayerChanging();
		partial void OnPlayerChanged();
		protected int _player;
		public virtual int Player
		{
			get { return _player; }
			set
			{
				OnPlayerChanging();
				_player = value;
				base.AnyPropertyChanged = true;
				OnPlayerChanged();
			}
		}

    }
}