using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Properties
{
    public partial class MatchesProperties : PropertiesBase
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

		partial void OnSequenceNumberChanging();
		partial void OnSequenceNumberChanged();
		protected int _sequenceNumber;
		public virtual int SequenceNumber
		{
			get { return _sequenceNumber; }
			set
			{
				OnSequenceNumberChanging();
				_sequenceNumber = value;
				base.AnyPropertyChanged = true;
				OnSequenceNumberChanged();
			}
		}

		partial void OnStartTimeChanging();
		partial void OnStartTimeChanged();
		protected DateTime _startTime = new DateTime(1900, 01, 01);
		public virtual DateTime StartTime
		{
			get { return _startTime; }
			set
			{
				if (value == DateTime.MinValue)
					_startTime = new DateTime(1900, 01, 01);
				else
					OnStartTimeChanging();
				_startTime = value;
				base.AnyPropertyChanged = true;
				OnStartTimeChanged();
			}
		}

		partial void OnLobbyTypeChanging();
		partial void OnLobbyTypeChanged();
		protected int _lobbyType;
		public virtual int LobbyType
		{
			get { return _lobbyType; }
			set
			{
				OnLobbyTypeChanging();
				_lobbyType = value;
				base.AnyPropertyChanged = true;
				OnLobbyTypeChanged();
			}
		}

    }
}