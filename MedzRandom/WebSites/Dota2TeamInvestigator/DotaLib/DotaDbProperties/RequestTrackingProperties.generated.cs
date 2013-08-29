using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class RequestTrackingProperties : PropertiesBase
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

		partial void OnRequestChanging();
		partial void OnRequestChanged();
		protected string _request;
		public virtual string Request
		{
			get { return _request; }
			set
			{
				OnRequestChanging();
				_request = value;
				base.AnyPropertyChanged = true;
				OnRequestChanged();
			}
		}

		partial void OnDateChanging();
		partial void OnDateChanged();
		protected DateTime _date = new DateTime(1900, 01, 01);
		public virtual DateTime Date
		{
			get { return _date; }
			set
			{
				if (value == DateTime.MinValue)
					_date = new DateTime(1900, 01, 01);
				else
					OnDateChanging();
				_date = value;
				base.AnyPropertyChanged = true;
				OnDateChanged();
			}
		}

    }
}