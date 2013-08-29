using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotaDbGenLib.Lists;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace DotaDbGenLib.Business
{
    public partial class Matches : Data.MatchesData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public Matches(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Matches(Properties.MatchesProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Matches(int iD, int sequenceNumber, DateTime startTime, int lobbyType)
        {
            PrepareBeforeConstruction();
            
			this.ID = iD;
			this.SequenceNumber = sequenceNumber;
			this.StartTime = startTime;
			this.LobbyType = lobbyType;
			
            FinishAfterConstruction();
        }
        
        public void LoadItem(int iD)
        {
            this.ID = iD;
			
            base.LoadItemData(iD);
        }
        
        
        public void Refresh()
        {
            base.LoadItemData(this.ID);
        }
        
        private void SetProperties(Properties.MatchesProperties properties)
        {
            this.ID = properties.ID;
			this.SequenceNumber = properties.SequenceNumber;
			this.StartTime = properties.StartTime;
			this.LobbyType = properties.LobbyType;
			this.RecordExists = properties.RecordExists;

        }
    }
}
