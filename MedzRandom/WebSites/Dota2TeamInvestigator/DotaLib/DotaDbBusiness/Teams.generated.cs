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
    public partial class Teams : Data.TeamsData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public Teams(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Teams(Properties.TeamsProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Teams(int iD, string teamName, string tag, string timeCreated, string rating, string logo, string logoSponsor, string countryCode, string uRL, int? gamesPlayed, int? adminAccount, DateTime lastUpdated)
        {
            PrepareBeforeConstruction();
            
			this.ID = iD;
			this.TeamName = teamName;
			this.Tag = tag;
			this.TimeCreated = timeCreated;
			this.Rating = rating;
			this.Logo = logo;
			this.LogoSponsor = logoSponsor;
			this.CountryCode = countryCode;
			this.URL = uRL;
			this.GamesPlayed = gamesPlayed;
			this.AdminAccount = adminAccount;
			this.LastUpdated = lastUpdated;
			
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
        
        private void SetProperties(Properties.TeamsProperties properties)
        {
            this.ID = properties.ID;
			this.TeamName = properties.TeamName;
			this.Tag = properties.Tag;
			this.TimeCreated = properties.TimeCreated;
			this.Rating = properties.Rating;
			this.Logo = properties.Logo;
			this.LogoSponsor = properties.LogoSponsor;
			this.CountryCode = properties.CountryCode;
			this.URL = properties.URL;
			this.GamesPlayed = properties.GamesPlayed;
			this.AdminAccount = properties.AdminAccount;
			this.LastUpdated = properties.LastUpdated;
			this.RecordExists = properties.RecordExists;

        }
    }
}
