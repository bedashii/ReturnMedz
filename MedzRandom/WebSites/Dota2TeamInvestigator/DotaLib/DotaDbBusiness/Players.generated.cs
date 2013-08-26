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
    public partial class Players : Data.PlayersData
    {
        #region ALL FOREIGN TABLE MEMBERS
                
        #endregion

        public Players(int steamID)
        {
            PrepareBeforeConstruction();
            this.LoadItem(steamID);
            FinishAfterConstruction();
        }

        public Players(Properties.PlayersProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Players(int steamID, int? teamID, string personaName, string profileURL, string avatar, string avatarMedium, string avatarFull, int? personaState, int? communityVisibilityState, int? profileState, DateTime? lastLogOff, string commentPermission, string realName, int? primaryClanID, DateTime? timeCreated, int? gameID, string gameServerID, string gameExtraInfo, int? cityID, string locCountyCode, string locStateCode, string locCityID)
        {
            PrepareBeforeConstruction();
            
			this.SteamID = steamID;
			this.TeamID = teamID;
			this.PersonaName = personaName;
			this.ProfileURL = profileURL;
			this.Avatar = avatar;
			this.AvatarMedium = avatarMedium;
			this.AvatarFull = avatarFull;
			this.PersonaState = personaState;
			this.CommunityVisibilityState = communityVisibilityState;
			this.ProfileState = profileState;
			this.LastLogOff = lastLogOff;
			this.CommentPermission = commentPermission;
			this.RealName = realName;
			this.PrimaryClanID = primaryClanID;
			this.TimeCreated = timeCreated;
			this.GameID = gameID;
			this.GameServerID = gameServerID;
			this.GameExtraInfo = gameExtraInfo;
			this.CityID = cityID;
			this.LocCountyCode = locCountyCode;
			this.LocStateCode = locStateCode;
			this.LocCityID = locCityID;
			
            FinishAfterConstruction();
        }
        
        public void LoadItem(int steamID)
        {
            this.SteamID = steamID;
			
            base.LoadItemData(steamID);
        }
        
        
        public void Refresh()
        {
            base.LoadItemData(this.SteamID);
        }
        
        private void SetProperties(Properties.PlayersProperties properties)
        {
            this.SteamID = properties.SteamID;
			this.TeamID = properties.TeamID;
			this.PersonaName = properties.PersonaName;
			this.ProfileURL = properties.ProfileURL;
			this.Avatar = properties.Avatar;
			this.AvatarMedium = properties.AvatarMedium;
			this.AvatarFull = properties.AvatarFull;
			this.PersonaState = properties.PersonaState;
			this.CommunityVisibilityState = properties.CommunityVisibilityState;
			this.ProfileState = properties.ProfileState;
			this.LastLogOff = properties.LastLogOff;
			this.CommentPermission = properties.CommentPermission;
			this.RealName = properties.RealName;
			this.PrimaryClanID = properties.PrimaryClanID;
			this.TimeCreated = properties.TimeCreated;
			this.GameID = properties.GameID;
			this.GameServerID = properties.GameServerID;
			this.GameExtraInfo = properties.GameExtraInfo;
			this.CityID = properties.CityID;
			this.LocCountyCode = properties.LocCountyCode;
			this.LocStateCode = properties.LocStateCode;
			this.LocCityID = properties.LocCityID;
			this.RecordExists = properties.RecordExists;

        }
    }
}
