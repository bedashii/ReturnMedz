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
		private static HeroesList _heroMemberList = new HeroesList();
		private Heroes _heroMember;
		[System.Xml.Serialization.XmlIgnore]
		public Heroes HeroMember
		{
		    get
		    {
		        if (_heroMember == null || _heroMember.ID != this.Hero)
		            _heroMember = _heroMemberList.GetByPrimaryKey(this.Hero);
		        return _heroMember;
		    }
		    set { _heroMember = value; }
		}
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
       
        public Cards(int hero, string name, short cost, short attack, short duration, short minAdditionalDamage, short maxExtraDamage, short additionalCost)
        {
            PrepareBeforeConstruction();
            
			this.Hero = hero;
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
			this.Hero = properties.Hero;
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
