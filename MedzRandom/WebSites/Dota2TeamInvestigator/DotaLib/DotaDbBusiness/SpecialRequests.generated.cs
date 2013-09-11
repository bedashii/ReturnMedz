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
    public partial class SpecialRequests : Data.SpecialRequestsData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public SpecialRequests(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public SpecialRequests(Properties.SpecialRequestsProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public SpecialRequests(int team, long player64, DateTime dateRequested, DateTime? dateResponded)
        {
            PrepareBeforeConstruction();
            
			this.Team = team;
			this.Player64 = player64;
			this.DateRequested = dateRequested;
			this.DateResponded = dateResponded;
			
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
        
        private void SetProperties(Properties.SpecialRequestsProperties properties)
        {
            this.ID = properties.ID;
			this.Team = properties.Team;
			this.Player64 = properties.Player64;
			this.DateRequested = properties.DateRequested;
			this.DateResponded = properties.DateResponded;
			this.RecordExists = properties.RecordExists;

        }
    }
}
