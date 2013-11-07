using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class SystemConfigProperties : PropertiesBase
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

		partial void OnSCKeyChanging();
		partial void OnSCKeyChanged();
		protected string _sCKey;
		public virtual string SCKey
		{
			get { return _sCKey; }
			set
			{
				OnSCKeyChanging();
				_sCKey = value;
				base.AnyPropertyChanged = true;
				OnSCKeyChanged();
			}
		}

		partial void OnSCValueChanging();
		partial void OnSCValueChanged();
		protected string _sCValue;
		public virtual string SCValue
		{
			get { return _sCValue; }
			set
			{
				OnSCValueChanging();
				_sCValue = value;
				base.AnyPropertyChanged = true;
				OnSCValueChanged();
			}
		}

		partial void OnIsActiveChanging();
		partial void OnIsActiveChanged();
		protected bool _isActive;
		public virtual bool IsActive
		{
			get { return _isActive; }
			set
			{
				OnIsActiveChanging();
				_isActive = value;
				base.AnyPropertyChanged = true;
				OnIsActiveChanged();
			}
		}

    }
}