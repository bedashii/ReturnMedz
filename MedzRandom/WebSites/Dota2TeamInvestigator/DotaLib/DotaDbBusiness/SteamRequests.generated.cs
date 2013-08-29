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
    public partial class SteamRequests : Data.SteamRequestsData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public SteamRequests(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public SteamRequests(Properties.SteamRequestsProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public SteamRequests(int requestNumber, DateTime? date, DateTime lastUpdated)
        {
            PrepareBeforeConstruction();
            
			this.RequestNumber = requestNumber;
			this.Date = date;
			this.LastUpdated = lastUpdated;
			
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
        
        private void SetProperties(Properties.SteamRequestsProperties properties)
        {
            this.ID = properties.ID;
			this.RequestNumber = properties.RequestNumber;
			this.Date = properties.Date;
			this.LastUpdated = properties.LastUpdated;
			this.RecordExists = properties.RecordExists;

        }
    }
}
