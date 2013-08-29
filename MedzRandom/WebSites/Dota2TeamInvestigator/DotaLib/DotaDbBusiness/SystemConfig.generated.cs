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
    public partial class SystemConfig : Data.SystemConfigData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public SystemConfig(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public SystemConfig(Properties.SystemConfigProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public SystemConfig(string sCKey, string sCValue)
        {
            PrepareBeforeConstruction();
            
			this.SCKey = sCKey;
			this.SCValue = sCValue;
			
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
        
        private void SetProperties(Properties.SystemConfigProperties properties)
        {
            this.ID = properties.ID;
			this.SCKey = properties.SCKey;
			this.SCValue = properties.SCValue;
			this.RecordExists = properties.RecordExists;

        }
    }
}
