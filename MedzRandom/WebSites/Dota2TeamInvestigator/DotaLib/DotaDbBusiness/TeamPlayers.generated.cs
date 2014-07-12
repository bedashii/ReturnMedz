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
    public partial class TeamPlayers : Data.TeamPlayersData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public TeamPlayers(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public TeamPlayers(Properties.TeamPlayersProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public TeamPlayers(int team, int player)
        {
            PrepareBeforeConstruction();
            
			this.Team = team;
			this.Player = player;
			
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
        
        private void SetProperties(Properties.TeamPlayersProperties properties)
        {
            this.ID = properties.ID;
			this.Team = properties.Team;
			this.Player = properties.Player;
			this.RecordExists = properties.RecordExists;

        }
    }
}
