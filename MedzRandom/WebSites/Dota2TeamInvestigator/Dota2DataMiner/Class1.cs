using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DotaLib.DotaDBBusiness;
using DotaLib.DotaDBLists;

namespace Dota2DataMiner
{
    public class Class1
    {
        public Class1()
        {
            steamAPIKey = "4C539F404B4DE827341AE78E9E5B35C9";
        }

        public bool GetNewTeams(int? teamID, int count)
        {
            string request = @"https://api.steampowered.com/IDOTA2Match_570/GetTeamInfoByTeamID/v001/?key=" + steamAPIKey;

            if (teamID != null)
                request += @"&start_at_team_id=" + teamID;

            request += "&teams_requested=" + count;

            XmlDocument response = MakeRequest(request);

            return GetTeams(response);
        }

        public void UpdateTeam(int teamID)
        {

        }

        public void GetPlayerSummary(List<long> steamIDs)
        {
            string request = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + steamAPIKey;

            if (steamIDs.Count != 0)
            {
                request += "&steamids=";
                for (int i = 0; i < steamIDs.Count; i++)
                {
                    if (i > 0)
                        request += ',';
                    request += steamIDs[i];
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

        private bool GetTeams(XmlDocument response)
        {
            bool newTeamsAdded = false;
            PlayerList players = new PlayerList();

            foreach (XmlNode subRootNode in response.DocumentElement.ChildNodes)
            {
                if (subRootNode.Name == "teams")
                {
                    foreach (XmlNode teamNode in subRootNode)
                    {
                        newTeamsAdded = true;
                        TeamBusiness team = null;
                        if (teamNode["team_id"] != null)
                        {
                            team.LoadTeamByID(Convert.ToInt32(teamNode["team_id"].Value));
                            if (!team.RecordsExists)
                            {
                                team = new TeamBusiness();
                            }
                        }
                        else
                        {
                            team = new TeamBusiness();
                        }

                        if (teamNode["team_id"] != null)
                            team.ID = Convert.ToInt32(teamNode["team_id"].Value);
                        if (teamNode["name"] != null)
                            team.TeamName = teamNode["name"].Value;
                        if (teamNode["tag"] != null)
                            team.Tag = teamNode["tag"].Value;
                        if (teamNode["time_created"] != null)
                            team.TimeCreated = teamNode["time_created"].Value;
                        if (teamNode["rating"] != null)
                            team.Rating = teamNode["rating"].Value;
                        if (teamNode["logo"] != null)
                            team.Logo = teamNode["logo"].Value;
                        if (teamNode["logo_sponsor"] != null)
                            team.LogoSponsor = teamNode["logo_sponsor"].Value;
                        if (teamNode["country_code"] != null)
                            team.CountryCode = teamNode["country_code"].Value;
                        if (teamNode["url"] != null)
                            team.Url = teamNode["url"].Value;
                        if (teamNode["games_played_with_current_roster"] != null)
                            team.GamesPlayed = Convert.ToInt32(teamNode["games_played_with_current_roster"].Value);
                        if (teamNode["admin_account_id"] != null)
                            team.AdminAccount = Convert.ToInt32(teamNode["admin_account_id"].Value);

                        team.InsertOrUpdate();

                        //Players
                        if (teamNode["player_0_account_id"] != null)
                            players.Add(new PlayerBusiness() { SteamId = Convert.ToInt32(teamNode["player_0_account_id"].Value), TeamId = team.ID });
                        if (teamNode["player_1_account_id"] != null)
                            players.Add(new PlayerBusiness() { SteamId = Convert.ToInt32(teamNode["player_1_account_id"].Value), TeamId = team.ID });
                        if (teamNode["player_2_account_id"] != null)
                            players.Add(new PlayerBusiness() { SteamId = Convert.ToInt32(teamNode["player_2_account_id"].Value), TeamId = team.ID });
                        if (teamNode["player_3_account_id"] != null)
                            players.Add(new PlayerBusiness() { SteamId = Convert.ToInt32(teamNode["player_3_account_id"].Value), TeamId = team.ID });
                        if (teamNode["player_4_account_id"] != null)
                            players.Add(new PlayerBusiness() { SteamId = Convert.ToInt32(teamNode["player_4_account_id"].Value), TeamId = team.ID });

                        players.UpdateAll();
                        //leagues;

                        team = null;
                        players.Clear();
                    }
                }
            }
            return newTeamsAdded;
        }
    }
}