using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class SteamRequestsProperties : PropertiesBase
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

		partial void OnRequestNumberChanging();
		partial void OnRequestNumberChanged();
		protected int _requestNumber;
		public virtual int RequestNumber
		{
			get { return _requestNumber; }
			set
			{
				OnRequestNumberChanging();
				_requestNumber = value;
				base.AnyPropertyChanged = true;
				OnRequestNumberChanged();
			}
		}

		partial void OnDateChanging();
		partial void OnDateChanged();
		protected DateTime? _date;
		public virtual DateTime? Date
		{
			get { return _date; }
			set
			{
				OnDateChanging();
				_date = value;
				base.AnyPropertyChanged = true;
				OnDateChanged();
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

    }
}