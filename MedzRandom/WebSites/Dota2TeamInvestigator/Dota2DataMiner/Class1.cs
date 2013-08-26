using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using DotaDbGenLib.Business;
using DotaDbGenLib.Lists;

namespace Dota2DataMiner
{
    public class Class1
    {
        public Class1()
        {
            steamAPIKey = "4C539F404B4DE827341AE78E9E5B35C9";
        }

        public static bool LocalRead = false;
        public static int LocalReads = 0;

        private int? previousTeamID = 0;

        public void GetNewTeamsRecoverLocalData(int? teamID)
        {
            if (teamID != null)
            {
                if (
                    File.Exists("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                                DateTime.Now.ToString("ddMMyyyy") + ").xml"))
                {
                    XmlDocument response = new XmlDocument();
                    response.Load("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                                  DateTime.Now.ToString("ddMMyyyy") + ").xml");
                    GetTeams(response, teamID);
                }
            }
        }

        public bool GetNewTeams(int? teamID, int count)
        {
            XmlDocument response = new XmlDocument();

            string request = @"https://api.steampowered.com/IDOTA2Match_570/GetTeamInfoByTeamID/v001/?key=" + steamAPIKey;

            request += "&format=xml";

            if (teamID != null)
                request += @"&start_at_team_id=" + teamID;

            request += "&teams_requested=" + count;

            response = MakeRequest(request);
            response.Save("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" + DateTime.Now.ToString("ddMMyyyy") + ").xml");

            return GetTeams(response, teamID);
        }

        public void UpdateTeam(int teamID)
        {

        }

        public void GetPlayerSummary(List<long> SteamIDs)
        {
            string request = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + steamAPIKey;

            request += "&format=xml";

            if (SteamIDs.Count != 0)
            {
                request += "&SteamIDs=";
                for (int i = 0; i < SteamIDs.Count; i++)
                {
                    if (i > 0)
                        request += ',';
                    request += SteamIDs[i];
                }
            }
            else
            {
                throw new Exception("Cannot get Player summaries, no steam ID's supplied.");
            }
        }

        public string steamAPIKey { get; set; }

        public static XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Read();
                return null;
            }
        }

        private bool GetTeams(XmlDocument response, int? teamID)
        {
            bool newTeamsAdded = false;
            PlayersList players = new PlayersList();

            foreach (XmlNode subRootNode in response.DocumentElement.ChildNodes)
            {
                if (subRootNode.Name == "teams")
                {
                    foreach (XmlNode teamNode in subRootNode)
                    {
                        Teams team = new Teams();
                        if (teamNode["team_id"] != null)
                        {
                            team.LoadItem(Convert.ToInt32(teamNode["team_id"].InnerText));
                            if (!team.RecordExists)
                            {
                                team = new Teams();
                            }
                        }
                        else
                        {
                            team = new Teams();
                        }

                        if (teamNode["team_id"] != null)
                            team.ID = Convert.ToInt32(teamNode["team_id"].InnerText);
                        if (teamNode["name"] != null)
                            team.TeamName = teamNode["name"].InnerText;
                        if (teamNode["tag"] != null)
                            team.Tag = teamNode["tag"].InnerText;
                        if (teamNode["time_created"] != null)
                            team.TimeCreated = teamNode["time_created"].InnerText;
                        if (teamNode["rating"] != null)
                            team.Rating = teamNode["rating"].InnerText;
                        if (teamNode["logo"] != null)
                            team.Logo = teamNode["logo"].InnerText;
                        if (teamNode["logo_sponsor"] != null)
                            team.LogoSponsor = teamNode["logo_sponsor"].InnerText;
                        if (teamNode["country_code"] != null)
                            team.CountryCode = teamNode["country_code"].InnerText;
                        if (teamNode["url"] != null)
                            team.URL = teamNode["url"].InnerText;
                        if (teamNode["games_played_with_current_roster"] != null)
                            team.GamesPlayed = Convert.ToInt32(teamNode["games_played_with_current_roster"].InnerText);
                        if (teamNode["admin_account_id"] != null)
                            team.AdminAccount = Convert.ToInt32(teamNode["admin_account_id"].InnerText);

                        Console.WriteLine("Team ID: " + team.ID + " Name: " + team.TeamName);

                        if (!team.RecordExists)
                        {
                            newTeamsAdded = true;
                        }

                        team.InsertOrUpdate();

                        //Players
                        addPlayer(players, team.ID, teamNode, "player_0_account_id");
                        addPlayer(players, team.ID, teamNode, "player_1_account_id");
                        addPlayer(players, team.ID, teamNode, "player_2_account_id");
                        addPlayer(players, team.ID, teamNode, "player_3_account_id");
                        addPlayer(players, team.ID, teamNode, "player_4_account_id");

                        // Reserves
                        addPlayer(players, team.ID, teamNode, "player_5_account_id");
                        addPlayer(players, team.ID, teamNode, "player_6_account_id");
                        addPlayer(players, team.ID, teamNode, "player_7_account_id");

                        players.UpdateAll();
                        //leagues;

                        team = null;
                        players.Clear();
                    }
                }
            }
            if (File.Exists("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                                                DateTime.Now.ToString("ddMMyyyy") + ").xml"))
            {
                File.Delete("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                            DateTime.Now.ToString("ddMMyyyy") + ").xml");
            }

            return newTeamsAdded;
        }

        private void addPlayer(PlayersList players, int teamID, XmlNode teamNode, string playerAccountId)
        {
            Players player = new Players();
            if (teamNode[playerAccountId] != null)
            {
                int steamID = Convert.ToInt32(teamNode[playerAccountId].InnerText);

                if (players.Find(x => x.SteamID == steamID) == null)
                {
                    player.LoadItem(steamID);

                    player.SteamID = steamID;
                    player.TeamID = teamID;

                    players.Add(player);

                    Console.WriteLine("Player ID:" + player.SteamID);
                }
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public void GetNewPlayerSummariesRecoverLocalData(PlayersList players)
        {
            if (players != null && players.Count > 0)
            {
                if (
                    File.Exists("PlayerSummaryInfo" + players[0].SteamID + "(" +
                                DateTime.Now.ToString("ddMMyyyy") + ").xml"))
                {
                    XmlDocument response = new XmlDocument();
                    response.Load("PlayerSummaryInfo" + players[0].SteamID + "(" +
                                DateTime.Now.ToString("ddMMyyyy") + ").xml");
                    GetPlayers(response, players);
                }
            }
        }

        private bool GetPlayers(XmlDocument response, PlayersList players)
        {
            bool newPlayersAdded = false;

            foreach (XmlNode subRootNode in response.DocumentElement.ChildNodes)
            {
                if (subRootNode.Name == "players")
                {
                    foreach (XmlNode playerNode in subRootNode)
                    {
                        Players player = new Players();
                        if (playerNode["steamid"] != null)
                        {
                            player =
                                players.Find(
                                    x =>
                                    x.SteamID ==
                                    Convert.ToInt32(Convert.ToInt64(playerNode["steamid"].InnerText) - 76561197960265728));
                            if (!player.RecordExists)
                            {
                                player = new Players();
                                players.Add(player);
                            }
                        }
                        else
                        {
                            player = new Players();
                            players.Add(player);
                        }

                        if (playerNode["steamid"] != null)
                            player.SteamID64 = Convert.ToInt64(playerNode["steamid"].InnerText);
                        if (playerNode["communityvisibilitystate"] != null)
                            player.CommunityVisibilityState = Convert.ToInt32(playerNode["communityvisibilitystate"].InnerText);
                        if (playerNode["profilestate"] != null)
                            player.ProfileState = Convert.ToInt32(playerNode["profilestate"].InnerText);
                        if (playerNode["personaname"] != null)
                            player.PersonaName = playerNode["personaname"].InnerText;
                        if (playerNode["lastlogoff"] != null)
                            player.LastLogOff = UnixTimeStampToDateTime(Convert.ToDouble(playerNode["lastlogoff"].InnerText));
                        if (playerNode["profileurl"] != null)
                            player.ProfileURL = playerNode["profileurl"].InnerText;
                        if (playerNode["avatar"] != null)
                            player.Avatar = playerNode["avatar"].InnerText;
                        if (playerNode["avatarmedium"] != null)
                            player.AvatarMedium = playerNode["avatarmedium"].InnerText;
                        if (playerNode["avatarfull"] != null)
                            player.AvatarFull = playerNode["avatarfull"].InnerText;
                        if (playerNode["personastate"] != null)
                            player.PersonaState = Convert.ToInt32(playerNode["personastate"].InnerText);
                        if (playerNode["realname"] != null)
                            player.RealName = playerNode["realname"].InnerText;

                        if (playerNode["primaryclanid"] != null)
                            player.PrimaryClanID = Convert.ToInt64(playerNode["primaryclanid"].InnerText);
                        if (playerNode["timecreated"] != null)
                            player.TimeCreated = UnixTimeStampToDateTime(Convert.ToDouble(playerNode["timecreated"].InnerText));
                        if (playerNode["loccountrycode"] != null)
                            player.LocCountyCode = playerNode["loccountrycode"].InnerText;
                        if (playerNode["locstatecode"] != null)
                            player.LocStateCode = playerNode["locstatecode"].InnerText;
                        if (playerNode["loccityid"] != null)
                            player.LocCityID = playerNode["loccityid"].InnerText;

                        Console.WriteLine("Steam ID: " + player.SteamID + " Name: " + player.PersonaName + " Real Name: " + (player.RealName ?? ""));

                        newPlayersAdded = true;
                    }
                }
            }

            players.ForEach(x => x.LastUpdated = DateTime.Now);
            players.UpdateAll();

            if (File.Exists("PlayerSummaryInfo" + players[0].SteamID + "(" +
                                                DateTime.Now.ToString("ddMMyyyy") + ").xml"))
            {
                File.Delete("PlayerSummaryInfo" + players[0].SteamID + "(" +
                            DateTime.Now.ToString("ddMMyyyy") + ").xml");
            }

            return newPlayersAdded;
        }

        public bool GetNewPlayerSummaries(PlayersList players)
        {
            if (players == null || players.Count == 0)
                return false;

            XmlDocument response = new XmlDocument();

            string request = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + steamAPIKey;

            request += "&format=xml";

            request += @"&SteamIDs=";

            for (int i = 0; i < players.Count; i++)
            {
                if (i != 0)
                    request += ",";
                request += (players[i].SteamID + 76561197960265728).ToString();
            }

            response = MakeRequest(request);
            response.Save("PlayerSummaryInfo" + players[0].SteamID + "(" + DateTime.Now.ToString("ddMMyyyy") + ").xml");

            return GetPlayers(response, players);
        }
    }
}