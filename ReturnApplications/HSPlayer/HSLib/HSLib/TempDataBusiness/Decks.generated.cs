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
    public partial class Decks : Data.DecksData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public Decks(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Decks(Properties.DecksProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Decks(string name, byte hero)
        {
            PrepareBeforeConstruction();
            
			this.Name = name;
			this.Hero = hero;
			
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
        
        private void SetProperties(Properties.DecksProperties properties)
        {
            this.ID = properties.ID;
			this.Name = properties.Name;
			this.Hero = properties.Hero;
			this.RecordExists = properties.RecordExists;

        }
    }
}
