using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace TempDataGenLib.Properties
{
    public partial class CardsProperties : PropertiesBase
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

		partial void OnNameChanging();
		partial void OnNameChanged();
		protected string _name = "";
		public virtual string Name
		{
			get { return _name; }
			set
			{
				OnNameChanging();
				_name = value;
				base.AnyPropertyChanged = true;
				OnNameChanged();
			}
		}

		partial void OnCostChanging();
		partial void OnCostChanged();
		protected short _cost;
		public virtual short Cost
		{
			get { return _cost; }
			set
			{
				OnCostChanging();
				_cost = value;
				base.AnyPropertyChanged = true;
				OnCostChanged();
			}
		}

		partial void OnAttackChanging();
		partial void OnAttackChanged();
		protected short _attack;
		public virtual short Attack
		{
			get { return _attack; }
			set
			{
				OnAttackChanging();
				_attack = value;
				base.AnyPropertyChanged = true;
				OnAttackChanged();
			}
		}

		partial void OnDurationChanging();
		partial void OnDurationChanged();
		protected short _duration;
		public virtual short Duration
		{
			get { return _duration; }
			set
			{
				OnDurationChanging();
				_duration = value;
				base.AnyPropertyChanged = true;
				OnDurationChanged();
			}
		}

		partial void OnMinAdditionalDamageChanging();
		partial void OnMinAdditionalDamageChanged();
		protected short _minAdditionalDamage;
		public virtual short MinAdditionalDamage
		{
			get { return _minAdditionalDamage; }
			set
			{
				OnMinAdditionalDamageChanging();
				_minAdditionalDamage = value;
				base.AnyPropertyChanged = true;
				OnMinAdditionalDamageChanged();
			}
		}

		partial void OnMaxExtraDamageChanging();
		partial void OnMaxExtraDamageChanged();
		protected short _maxExtraDamage;
		public virtual short MaxExtraDamage
		{
			get { return _maxExtraDamage; }
			set
			{
				OnMaxExtraDamageChanging();
				_maxExtraDamage = value;
				base.AnyPropertyChanged = true;
				OnMaxExtraDamageChanged();
			}
		}

		partial void OnAdditionalCostChanging();
		partial void OnAdditionalCostChanged();
		protected short _additionalCost;
		public virtual short AdditionalCost
		{
			get { return _additionalCost; }
			set
			{
				OnAdditionalCostChanging();
				_additionalCost = value;
				base.AnyPropertyChanged = true;
				OnAdditionalCostChanged();
			}
		}

    }
}