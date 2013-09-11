using System;
using System.Collections.Generic;
using System.Threading;
using DotaDbGenLib.Business;
using DotaDbGenLib.Lists;

namespace Dota2DataMinerApp
{
    class Program
    {
        private static bool QuiteMode=false;
        static void Main(string[] args)
        {
            Dota2DataMiner.Class1.PlayerSummariesLimiter = 100;

            QuiteMode = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("QuiteMode"));

            do
            {
                // If their are special requests do one and restart the loop else do normal routine.
                if (GetSpecialRequest())
                    continue;

                GetTeams();
                GetPlayerSummaries();

                UpdateTeams();

                GetMatchesPerUndocumentedPlayer();
            } while (true);
        }

        private static bool GetSpecialRequest()
        {
            SpecialRequestsList specialRequestsList = new SpecialRequestsList();
            specialRequestsList.GetSpecialRequest();

            if (specialRequestsList.Count > 0)
            {
                bool olderMatchesToFind = true;
                do
                {
                    olderMatchesToFind = GetOlderMatchesPerPlayer(specialRequestsList[0].Player64);
                } while (olderMatchesToFind);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool GetOlderMatchesPerPlayer(long steamID64)
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            PlayersList playersList = new PlayersList();
            int matchID = 0;
            // Make sure there is older matches to find.
            if (playersList.LastMatchFound(steamID64, out matchID))
                return false;

            // Check for and Recover Local Data.
            d2Dm.GetMatchPerPlayerLocalData(steamID64, matchID);

            // Check if System Config permits this method call.
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.GetByKey("GetOlderMatchesPerPlayer");

            if (systemConfig.RecordExists)
            {
                if (DateTime.Now < Convert.ToDateTime(systemConfig.SCValue).AddSeconds(1))
                    return true;
            }
            else
            {
                systemConfig.SCKey = "GetOlderMatchesPerPlayer";
            }

            // Get or Create SteamRequest
            SteamRequests steamRequests;
            GetSteamRequest(out steamRequests);

            // Check if API can be used else return
            if (DateTime.Now < steamRequests.LastUpdated.AddSeconds(1))
                return true;

            // Increment the Steam Request Counter
            Console.WriteLine("Steam request number : " + steamRequests.RequestNumber + " - Get Older Matches Per Player");
            steamRequests.RequestNumber++;
            steamRequests.LastUpdated = DateTime.Now;
            steamRequests.InsertOrUpdate();

            Players player = new Players();

            // Get Live Data.
            if (!d2Dm.GetMatchPerPlayer(steamID64, matchID, "GetOlderMatchesPerPlayer"))
            {
                if (!QuiteMode)
                Console.WriteLine("Oldest Player match found.");

                player.GetBySteamID64(steamID64);
                player.OldestMatchFound = true;
                player.Update();
            }

            systemConfig.SCValue = DateTime.Now.ToString();
            systemConfig.InsertOrUpdate();

            if (player.RecordExists && player.OldestMatchFound)
                return false;
            else
                return true;
        }

        private static void GetMatchesPerUndocumentedPlayer()
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            PlayersList playersList = new PlayersList();

            // Get latest Team.
            long steamID64 = playersList.GetPlayerWithNoMatchRecords();

            // If nothing new to find, return
            if (steamID64 == -1)
                return;

            // Check for and Recover Local Data.
            d2Dm.GetMatchPerPlayerLocalData(steamID64, 0);

            // Get latest Team.
            steamID64 = playersList.GetPlayerWithNoMatchRecords();

            // If nothing new to find, return
            if (steamID64 == -1)
                return;

            // Check if System Config permits this method call.
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.GetByKey("GetMatchesPerUndocumentedPlayer");

            if (systemConfig.RecordExists)
            {
                if (DateTime.Now < Convert.ToDateTime(systemConfig.SCValue).AddSeconds(1))
                    return;
            }
            else
            {
                systemConfig.SCKey = "GetMatchesPerUndocumentedPlayer";
            }

            // Get or Create SteamRequest
            SteamRequests steamRequests;
            GetSteamRequest(out steamRequests);

            // Check if API can be used else return
            if (DateTime.Now < steamRequests.LastUpdated.AddSeconds(1))
                return;

            // Increment the Steam Request Counter
            Console.WriteLine("Steam request number : " + steamRequests.RequestNumber + " - Get Matches Per Undocumented Player");
            steamRequests.RequestNumber++;
            steamRequests.LastUpdated = DateTime.Now;
            steamRequests.InsertOrUpdate();

            // Get Live Data.
            if (d2Dm.GetMatchPerPlayer(steamID64, 0, "GetMatchesPerUndocumentedPlayer"))
            {
                // New Data Found, sleep for 1 seconds as steam requests before continuing.
                systemConfig.SCValue = DateTime.Now.ToString();
            }
            else
            {
                // No New Data Found, sleep for 60 seconds to save daily requests.
                if (!QuiteMode)
                Console.WriteLine("No Match Per Player Found.");
                systemConfig.SCValue = DateTime.Now.AddMinutes(1).ToString();
            }

            systemConfig.InsertOrUpdate();
        }

        //private static void GetMatchs()
        //{
        //    Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

        //    TeamsList teams = new TeamsList();

        //    // Get latest Team.
        //    int? teamID = teams.GetMaxTeamID();

        //    // Check for and Recover Local Data.
        //    d2Dm.GetNewTeamsRecoverLocalData(teamID);

        //    // Get latest Team.
        //    teamID = teams.GetMaxTeamID();

        //    // Check if System Config permits this method call.
        //    SystemConfig systemConfig = new SystemConfig();
        //    systemConfig.GetByKey("GetMatchDetails");

        //    if (systemConfig.RecordExists)
        //    {
        //        if (DateTime.Now < Convert.ToDateTime(systemConfig.SCValue).AddSeconds(1))
        //            return;
        //    }
        //    else
        //    {
        //        systemConfig.SCKey = "GetMatchDetails";
        //    }

        //    // Get or Create And Increment SteamRequest
        //    SteamRequests steamRequests;
        //    GetSteamRequest(out steamRequests);

        //    // Check if API can be used else return
        //    if (DateTime.Now < steamRequests.LastUpdated.AddSeconds(1))
        //        return;

        //    // Increment the Steam Request Counter
        //    Console.WriteLine("Steam request number : " + steamRequests.RequestNumber);
        //    steamRequests.RequestNumber++;
        //    steamRequests.LastUpdated = DateTime.Now;
        //    steamRequests.InsertOrUpdate();

        //    // Get Live Data.
        //    if (d2Dm.GetNewTeams(teamID, 100))
        //    {
        //        // New Data Found, sleep for 1 seconds as steam requests before continuing.
        //        systemConfig.SCValue = DateTime.Now.ToString();
        //    }
        //    else
        //    {
        //        // No New Data Found, sleep for 60 seconds to save daily requests.
        //        Console.WriteLine("No New Teams Found.");
        //        systemConfig.SCValue = DateTime.Now.AddMinutes(1).ToString();
        //    }

        //    systemConfig.InsertOrUpdate();
        //}

        private static void GetTeams()
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            TeamsList teams = new TeamsList();

            // Get latest Team.
            int? teamID = teams.GetMaxTeamID();

            // Check for and Recover Local Data.
            d2Dm.GetNewTeamsRecoverLocalData(teamID);

            // Get latest Team.
            teamID = teams.GetMaxTeamID();

            // Check if System Config permits this method call.
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.GetByKey("GetNewTeams");

            if (systemConfig.RecordExists)
            {
                if (DateTime.Now < Convert.ToDateTime(systemConfig.SCValue).AddSeconds(1))
                    return;
            }
            else
            {
                systemConfig.SCKey = "GetNewTeams";
            }

            // Get or Create And Increment SteamRequest
            SteamRequests steamRequests;
            GetSteamRequest(out steamRequests);

            // Check if API can be used else return
            if (DateTime.Now < steamRequests.LastUpdated.AddSeconds(1))
                return;

            // Increment the Steam Request Counter
            Console.WriteLine("Steam request number : " + steamRequests.RequestNumber + " - GetTeams");
            steamRequests.RequestNumber++;
            steamRequests.LastUpdated = DateTime.Now;
            steamRequests.InsertOrUpdate();

            // Get Live Data.
            if (d2Dm.GetNewTeams(teamID, 100))
            {
                // New Data Found, sleep for 1 seconds as steam requests before continuing.
                systemConfig.SCValue = DateTime.Now.ToString();
            }
            else
            {
                // No New Data Found, sleep for 60 seconds to save daily requests.
                if (!QuiteMode)
                Console.WriteLine("No New Teams Found.");
                systemConfig.SCValue = DateTime.Now.AddMinutes(30).ToString();
            }

            systemConfig.InsertOrUpdate();
        }

        private static void UpdateTeams()
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            TeamsList teams = new TeamsList();

            // Get latest Team.
            int? teamID = teams.GetMinTeamIDForUpdate();

            // Check for and Recover Local Data.
            d2Dm.GetNewTeamsRecoverLocalData(teamID);

            // Get latest Team.
            teamID = teams.GetMinTeamIDForUpdate();

            // Check if System Config permits this method call.
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.GetByKey("UpdateTeams");

            if (systemConfig.RecordExists)
            {
                if (DateTime.Now < Convert.ToDateTime(systemConfig.SCValue).AddSeconds(1))
                    return;
            }
            else
            {
                systemConfig.SCKey = "UpdateTeams";
            }

            // Get or Create And Increment SteamRequest
            SteamRequests steamRequests;
            GetSteamRequest(out steamRequests);

            // Check if API can be used else return
            if (DateTime.Now < steamRequests.LastUpdated.AddSeconds(1))
                return;

            // Increment the Steam Request Counter
            Console.WriteLine("Steam request number : " + steamRequests.RequestNumber + " - UpdateTeams");
            steamRequests.RequestNumber++;
            steamRequests.LastUpdated = DateTime.Now;
            steamRequests.InsertOrUpdate();

            // Get Live Data.
            if (d2Dm.GetNewTeams(teamID, 100))
            {
                // New Data Found, sleep for 1 seconds as steam requests before continuing.
                systemConfig.SCValue = DateTime.Now.ToString();
            }
            else
            {
                // No New Data Found, sleep for 60 seconds to save daily requests.
                if (!QuiteMode)
                Console.WriteLine("No New Teams Found.");
                systemConfig.SCValue = DateTime.Now.AddMinutes(1).ToString();
            }

            systemConfig.InsertOrUpdate();
        }

        private static void GetPlayerSummaries()
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            PlayersList players = new PlayersList();

            // Get Top 100 Unprocessed Players
            players.GetUnprocessedPlayers(Dota2DataMiner.Class1.PlayerSummariesLimiter);

            // Check for and Recover Local Data.
            d2Dm.GetNewPlayerSummariesRecoverLocalData(players);

            // Get Top 100 Unprocessed Players
            players.GetUnprocessedPlayers(Dota2DataMiner.Class1.PlayerSummariesLimiter);

            // Check if System Config permits this method call.
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.GetByKey("GetPlayerSummaries");

            if (systemConfig.RecordExists)
            {
                if (DateTime.Now < Convert.ToDateTime(systemConfig.SCValue).AddSeconds(1))
                    return;
            }
            else
                systemConfig.SCKey = "GetPlayerSummaries";

            // Get or Create And Increment SteamRequest
            SteamRequests steamRequests;
            GetSteamRequest(out steamRequests);

            // Check if API can be used else return
            if (DateTime.Now < steamRequests.LastUpdated.AddSeconds(1))
                return;

            // Increment the Steam Request Counter
            Console.WriteLine("Steam request number : " + steamRequests.RequestNumber + " - Get Player Summaries");
            steamRequests.RequestNumber++;
            steamRequests.LastUpdated = DateTime.Now;
            steamRequests.InsertOrUpdate();

            // Get Live Data.
            if (d2Dm.GetNewPlayerSummaries(players))
            {
                // New Data Found, sleep for 1 seconds as steam requests before continuing.
                systemConfig.SCValue = DateTime.Now.ToString();
            }
            else
            {
                // No New Data Found, sleep for 60 seconds to save daily requests.
                if (!QuiteMode)
                Console.WriteLine("No New Players Found.");
                systemConfig.SCValue = DateTime.Now.AddMinutes(1).ToString();
            }

            systemConfig.InsertOrUpdate();
        }

        private static void GetSteamRequest(out SteamRequests steamRequests)
        {
            // Get Steam Requests record for today.
            steamRequests = new SteamRequests();
            steamRequests.GetByDate(DateTime.Now);

            // If steamRequest record doesn't exists (new day), create a new one.
            if (!steamRequests.RecordExists)
            {
                steamRequests.RequestNumber = 0;
                steamRequests.Date = DateTime.Now.Date;
            }

            // TODO Steam Reset time is not at midnight, get actual time.
            // Make sure that steam API daily request have not been exceeded.
            if (steamRequests.RequestNumber > 99999)
            {
                Console.Write("Daily Steam Requests Exceeded, Sleeping till Tomorrow: ");
                TimeSpan remainingTime = (DateTime.Now.Date.AddDays(1) - DateTime.Now);
                Console.WriteLine(remainingTime.Hours + "h " + remainingTime.Minutes + "m " + remainingTime.Seconds + "s " +
                                  remainingTime.Milliseconds + "ms");
                Thread.Sleep(1000);
                return;
            }


        }
    }
}