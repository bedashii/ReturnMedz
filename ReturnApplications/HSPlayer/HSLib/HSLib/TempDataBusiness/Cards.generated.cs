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
    public partial class Cards : Data.CardsData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public Cards(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Cards(Properties.CardsProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Cards(string name, short cost, short attack, short duration, short minAdditionalDamage, short maxExtraDamage, short additionalCost)
        {
            PrepareBeforeConstruction();
            
			this.Name = name;
			this.Cost = cost;
			this.Attack = attack;
			this.Duration = duration;
			this.MinAdditionalDamage = minAdditionalDamage;
			this.MaxExtraDamage = maxExtraDamage;
			this.AdditionalCost = additionalCost;
			
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
        
        private void SetProperties(Properties.CardsProperties properties)
        {
            this.ID = properties.ID;
			this.Name = properties.Name;
			this.Cost = properties.Cost;
			this.Attack = properties.Attack;
			this.Duration = properties.Duration;
			this.MinAdditionalDamage = properties.MinAdditionalDamage;
			this.MaxExtraDamage = properties.MaxExtraDamage;
			this.AdditionalCost = properties.AdditionalCost;
			this.RecordExists = properties.RecordExists;

        }
    }
}
