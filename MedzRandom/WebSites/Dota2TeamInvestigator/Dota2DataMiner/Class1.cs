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

            response = MakeRequest("GetNewTeams", request);
            if (response != null)
            {
                response.Save("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml");

                return GetTeams(response, teamID);
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTeam(int? teamID, int count)
        {
            XmlDocument response = new XmlDocument();

            string request = @"https://api.steampowered.com/IDOTA2Match_570/GetTeamInfoByTeamID/v001/?key=" + steamAPIKey;

            request += "&format=xml";

            if (teamID != null)
                request += @"&start_at_team_id=" + teamID;

            request += "&teams_requested=" + count;

            response = MakeRequest("UpdateTeams", request);
            if (response != null)
            {
                response.Save("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml");

                return GetTeams(response, teamID);
            }
            else
            {
                return false;
            }
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

        public static XmlDocument MakeRequest(string requestType, string requestUrl)
        {
            try
            {
                // Track every request made.
                RequestTracking requestTracking = new RequestTracking();
                requestTracking.Request = requestUrl;
                requestTracking.Date = DateTime.Now;
                requestTracking.InsertOrUpdate();

                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                SystemConfig systemConfig = new SystemConfig();
                systemConfig.GetByKey(requestType);

                if (!systemConfig.RecordExists)
                    systemConfig.SCKey = requestType;
                systemConfig.SCValue = DateTime.Now.ToString();
                systemConfig.InsertOrUpdate();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                PlayerSummariesLimiter = 1;

                return null;
            }
        }

        private bool GetTeams(XmlDocument response, int? teamID)
        {
            TeamsList teamsList = new TeamsList();

            if (teamID != null)
            {
                Teams tempTeams = new Teams((int)teamID);
                if (!tempTeams.RecordExists)
                {
                    teamsList.Add(new Teams() { ID = Convert.ToInt32(teamID), TeamName = "UNKNOWN" });
                }
                else
                {
                    teamsList.Add(tempTeams);
                }
            }

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

                        if (team.ID == teamID)
                        {
                            Teams tempTeams = teamsList.Find(x => x.ID == teamID);
                            if (tempTeams != null)
                            {
                                teamsList.Remove(tempTeams);
                            }
                        }

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

                        team.LastUpdated = DateTime.Now;

                        Console.WriteLine("Team ID: " + team.ID + " Name: " + team.TeamName);

                        if (!team.RecordExists)
                        {
                            newTeamsAdded = true;
                        }

                        team.InsertOrUpdate();

                        TeamPlayersList teamPlayers = new TeamPlayersList();
                        teamPlayers.GetByTeam(team.ID);

                        //Players
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_0_account_id");
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_1_account_id");
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_2_account_id");
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_3_account_id");
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_4_account_id");

                        // Reserves
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_5_account_id");
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_6_account_id");
                        addPlayer(players, teamPlayers, team.ID, teamNode, "player_7_account_id");

                        players.UpdateAll();
                        //leagues;

                        team = null;
                        players.Clear();

                        teamPlayers.ForEach(x => x.Delete());
                    }
                }
            }

            if (teamsList.Count > 0)
            {
                teamsList.ForEach(x => x.LastUpdated = DateTime.Now);
                teamsList.UpdateAll();
            }

            if (File.Exists("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                                                DateTime.Now.ToString("ddMMyyyy") + ").xml"))
            {
                File.Delete("GetTeamInfo" + (teamID != null ? teamID.ToString() : "") + "(" +
                            DateTime.Now.ToString("ddMMyyyy") + ").xml");
            }

            return newTeamsAdded;
        }

        private void addPlayer(PlayersList players, TeamPlayersList teamPlayersList, int teamID, XmlNode teamNode, string playerAccountId)
        {
            Players player = new Players();
            if (teamNode[playerAccountId] != null)
            {
                int steamID = Convert.ToInt32(teamNode[playerAccountId].InnerText);

                if (players.Find(x => x.SteamID == steamID) == null)
                {
                    player.LoadItem(steamID);

                    player.SteamID = steamID;
                    //player.TeamID = teamID;

                    players.Add(player);

                    TeamPlayers teamPlayers = new TeamPlayers();
                    teamPlayers.GetByTeamPlayer(teamID, steamID);

                    teamPlayers.Team = teamID;
                    teamPlayers.Player = steamID;
                    teamPlayers.InsertOrUpdate();

                    Console.WriteLine("Player ID:" + player.SteamID);
                }

                TeamPlayers teamPlayer = teamPlayersList.Find(x => x.Player == steamID);
                if (teamPlayer != null)
                    teamPlayersList.Remove(teamPlayer);
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

            response = MakeRequest("GetPlayerSummaries", request);

            if (response == null)
            {
                if (players.Count == 1 && PlayerSummariesLimiter == 1)
                {
                    players[0].PersonaName = "BROKEN";
                    players[0].LastUpdated = new DateTime(2020, 1, 1);

                    PlayerSummariesLimiter = 100;
                    players[0].InsertOrUpdate();
                }
                return true;
            }
            else
            {
                response.Save("PlayerSummaryInfo" + players[0].SteamID + "(" + DateTime.Now.ToString("ddMMyyyy") + ").xml");

                return GetPlayers(response, players);
            }
        }

        public static int PlayerSummariesLimiter { get; set; }

        public bool GetMatchPerPlayer(long steamId64, int matchID)
        {
            XmlDocument response = new XmlDocument();
            //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key=4C539F404B4DE827341AE78E9E5B35C9&format=xml&account_id=76561198082150352&start_at_match_id=0
            string request = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key=" + steamAPIKey;

            request += "&format=xml";

            request += @"&account_id=" + steamId64;

            if (matchID != 0)
                request += "&start_at_match_id=" + matchID;

            response = MakeRequest("GetMatchPerPlayer", request);
            if (response != null)
            {
                response.Save("GetMatchPerPlayer" + steamId64.ToString() + (matchID != 0 ? matchID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml");

                return GetMatchs(response, steamId64, matchID);
            }
            else
            {
                return false;
            }
        }

        private bool GetMatchs(XmlDocument response, long steamId64, int recordMatchID)
        {
            bool lastMatch = false;
            bool newPlayersAdded = false;

            foreach (XmlNode subRootNode in response.DocumentElement.ChildNodes)
            {
                if (subRootNode.Name == "results_remaining" && subRootNode.InnerText == "0")
                    lastMatch = true;

                if (subRootNode.Name == "matches")
                {
                    foreach (XmlNode matchNode in subRootNode)
                    {
                        Matches matches = new Matches();
                        if (matchNode["match_id"] != null)
                        {
                            int matchID = Convert.ToInt32(matchNode["match_id"].InnerText);
                            matches.LoadItem(matchID);
                            if (!matches.RecordExists)
                            {
                                matches = new Matches();
                            }
                        }
                        else
                        {
                            matches = new Matches();
                        }

                        if (matchNode["match_id"] != null)
                            matches.ID = Convert.ToInt32(matchNode["match_id"].InnerText);

                        if (matchNode["match_seq_num"] != null)
                            matches.SequenceNumber = Convert.ToInt32(matchNode["match_seq_num"].InnerText);

                        if (matchNode["start_time"] != null)
                            matches.StartTime = UnixTimeStampToDateTime(Convert.ToDouble(matchNode["start_time"].InnerText));

                        if (matchNode["lobby_type"] != null)
                            matches.LobbyType = Convert.ToInt32(matchNode["lobby_type"].InnerText);

                        matches.InsertOrUpdate();

                        if (matchNode["players"] != null)
                        {
                            MatchPlayerList matchPlayerList = new MatchPlayerList();
                            foreach (XmlNode playerNode in matchNode["players"])
                            {
                                MatchPlayer matchPlayer = new MatchPlayer();
                                matchPlayer.GetByMatchPlayer64(matches.ID, Convert.ToInt64(playerNode["account_id"]));

                                if (!matchPlayer.RecordExists)
                                {
                                    matchPlayer.Match = matches.ID;
                                    matchPlayer.Player64 = Convert.ToInt64(playerNode["account_id"]);
                                    matchPlayer.Slot = Convert.ToInt32(playerNode["player_slot"]);
                                    matchPlayer.Hero = Convert.ToInt32(playerNode["hero_id"]);
                                    matchPlayerList.Add(matchPlayer);

                                    Players player = new Players();
                                    player.GetBySteamID64((long)matchPlayer.Player64);

                                    if (!player.RecordExists)
                                    {
                                        // Shit shit the player doesn't exist and I've already used this seconds request!
                                        // Make a plan!
                                    }
                                }
                            }
                        }

                        Console.WriteLine("");

                        newPlayersAdded = true;
                    }
                }
            }

            if (File.Exists("GetMatchPerPlayer" + steamId64.ToString() + (recordMatchID != 0 ? recordMatchID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml"))
            {
                File.Delete("GetMatchPerPlayer" + steamId64.ToString() + (recordMatchID != 0 ? recordMatchID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml");
            }

            return newPlayersAdded;
        }

        public void GetMatchPerPlayerLocalData(long steamId64, int recordMatchID)
        {
            if (steamId64 != -1)
            {
                if (File.Exists("GetMatchPerPlayer" + steamId64.ToString() + (recordMatchID != 0 ? recordMatchID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml"))
                {
                    XmlDocument response = new XmlDocument();
                    response.Load("GetMatchPerPlayer" + steamId64.ToString() + (recordMatchID != 0 ? recordMatchID.ToString() : "") + "(" +
                              DateTime.Now.ToString("ddMMyyyy") + ").xml");
                    if (response != null)
                        GetMatchs(response, steamId64, recordMatchID);
                }
            }
        }
    }
}