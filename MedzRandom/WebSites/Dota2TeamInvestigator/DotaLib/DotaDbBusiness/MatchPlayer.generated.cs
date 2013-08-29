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
    public partial class MatchPlayer : Data.MatchPlayerData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public MatchPlayer(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public MatchPlayer(Properties.MatchPlayerProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public MatchPlayer(int match, int? player, long? player64, int slot, int hero)
        {
            PrepareBeforeConstruction();
            
			this.Match = match;
			this.Player = player;
			this.Player64 = player64;
			this.Slot = slot;
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
        
        private void SetProperties(Properties.MatchPlayerProperties properties)
        {
            this.ID = properties.ID;
			this.Match = properties.Match;
			this.Player = properties.Player;
			this.Player64 = properties.Player64;
			this.Slot = properties.Slot;
			this.Hero = properties.Hero;
			this.RecordExists = properties.RecordExists;

        }
    }
}
