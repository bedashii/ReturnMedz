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
    public partial class RequestTracking : Data.RequestTrackingData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public RequestTracking(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public RequestTracking(Properties.RequestTrackingProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public RequestTracking(string request, DateTime date)
        {
            PrepareBeforeConstruction();
            
			this.Request = request;
			this.Date = date;
			
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
        
        private void SetProperties(Properties.RequestTrackingProperties properties)
        {
            this.ID = properties.ID;
			this.Request = properties.Request;
			this.Date = properties.Date;
			this.RecordExists = properties.RecordExists;

        }
    }
}
