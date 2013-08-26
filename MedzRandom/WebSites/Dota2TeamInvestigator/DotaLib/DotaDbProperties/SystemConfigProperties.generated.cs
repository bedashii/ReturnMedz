using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class SystemConfigProperties : PropertiesBase
    {
		partial void OnSCKeyChanging();
		partial void OnSCKeyChanged();
		protected int _sCKey;
		public virtual int SCKey
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

    }
}