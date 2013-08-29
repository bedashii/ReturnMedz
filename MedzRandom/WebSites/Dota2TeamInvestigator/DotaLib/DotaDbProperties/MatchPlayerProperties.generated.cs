using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class MatchPlayerProperties : PropertiesBase
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

		partial void OnMatchChanging();
		partial void OnMatchChanged();
		protected int _match;
		public virtual int Match
		{
			get { return _match; }
			set
			{
				OnMatchChanging();
				_match = value;
				base.AnyPropertyChanged = true;
				OnMatchChanged();
			}
		}

		partial void OnPlayerChanging();
		partial void OnPlayerChanged();
		protected int? _player;
		public virtual int? Player
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

		partial void OnPlayer64Changing();
		partial void OnPlayer64Changed();
		protected long? _player64;
		public virtual long? Player64
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

		partial void OnSlotChanging();
		partial void OnSlotChanged();
		protected int _slot;
		public virtual int Slot
		{
			get { return _slot; }
			set
			{
				OnSlotChanging();
				_slot = value;
				base.AnyPropertyChanged = true;
				OnSlotChanged();
			}
		}

		partial void OnHeroChanging();
		partial void OnHeroChanged();
		protected int _hero;
		public virtual int Hero
		{
			get { return _hero; }
			set
			{
				OnHeroChanging();
				_hero = value;
				base.AnyPropertyChanged = true;
				OnHeroChanged();
			}
		}

    }
}