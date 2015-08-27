using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace TempDataGenLib.Properties
{
    public partial class HeroesProperties : PropertiesBase
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

		partial void OnClassChanging();
		partial void OnClassChanged();
		protected string _class;
		public virtual string Class
		{
			get { return _class; }
			set
			{
				OnClassChanging();
				_class = value;
				base.AnyPropertyChanged = true;
				OnClassChanged();
			}
		}

    }
}