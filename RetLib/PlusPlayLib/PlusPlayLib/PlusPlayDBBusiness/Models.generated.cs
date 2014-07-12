using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlusPlayDBGenLib.Lists;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace PlusPlayDBGenLib.Business
{
    public partial class Models : Data.ModelsData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public Models(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Models(Properties.ModelsProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Models(string modelName, string modelDirectory, string coverPhoto)
        {
            PrepareBeforeConstruction();
            
			this.ModelName = modelName;
			this.ModelDirectory = modelDirectory;
			this.CoverPhoto = coverPhoto;
			
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
        
        private void SetProperties(Properties.ModelsProperties properties)
        {
            this.ID = properties.ID;
			this.ModelName = properties.ModelName;
			this.ModelDirectory = properties.ModelDirectory;
			this.CoverPhoto = properties.CoverPhoto;
			this.RecordExists = properties.RecordExists;

        }
    }
}
