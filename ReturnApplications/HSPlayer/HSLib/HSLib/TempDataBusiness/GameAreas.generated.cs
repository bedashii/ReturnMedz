using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempDataGenLib.Lists;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace TempDataGenLib.Business
{
    public partial class GameAreas : Data.GameAreasData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public GameAreas(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public GameAreas(Properties.GameAreasProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public GameAreas(string name, string description)
        {
            PrepareBeforeConstruction();
            
			this.Name = name;
			this.Description = description;
			
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
        
        private void SetProperties(Properties.GameAreasProperties properties)
        {
            this.ID = properties.ID;
			this.Name = properties.Name;
			this.Description = properties.Description;
			this.RecordExists = properties.RecordExists;

        }
    }
}
