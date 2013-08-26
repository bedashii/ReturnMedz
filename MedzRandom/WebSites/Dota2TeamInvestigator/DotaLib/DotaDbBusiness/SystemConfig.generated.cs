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

        public SystemConfig(int sCKey)
        {
            PrepareBeforeConstruction();
            this.LoadItem(sCKey);
            FinishAfterConstruction();
        }

        public SystemConfig(Properties.SystemConfigProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        
        public void LoadItem(int sCKey)
        {
            this.SCKey = sCKey;
			
            base.LoadItemData(sCKey);
        }
        
        
        public void Refresh()
        {
            base.LoadItemData(this.SCKey);
        }
        
        private void SetProperties(Properties.SystemConfigProperties properties)
        {
            this.SCKey = properties.SCKey;
			this.SCValue = properties.SCValue;
			this.RecordExists = properties.RecordExists;

        }
    }
}
