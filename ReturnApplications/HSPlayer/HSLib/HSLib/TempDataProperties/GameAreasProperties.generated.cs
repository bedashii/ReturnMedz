using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace TempDataGenLib.Properties
{
    public partial class GameAreasProperties : PropertiesBase
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

		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		protected string _description = "";
		public virtual string Description
		{
			get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				base.AnyPropertyChanged = true;
				OnDescriptionChanged();
			}
		}

    }
}