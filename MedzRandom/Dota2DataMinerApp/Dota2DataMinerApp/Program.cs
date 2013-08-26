using System;
using System.Collections.Generic;
using System.Threading;
using DotaDbGenLib.Business;
using DotaDbGenLib.Lists;

namespace Dota2DataMinerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                //GetTeams();
                GetPlayerSummaries();
            } while (true);

        }

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

            // Get or Create And Increment SteamRequest
            SteamRequests steamRequests;
            GetAndIncrementSteamRequest(out steamRequests);

            // Get Live Data.
            if (d2Dm.GetNewTeams(teamID, 100))
            {
                // New Data Found, sleep for 1 seconds as steam requests before continuing.
                Thread.Sleep(1000);
            }
            else
            {
                // No New Data Found, sleep for 60 seconds to save daily requests.
                Console.WriteLine("No New Teams Found, Sleeping for 60 Seconds.");
                Thread.Sleep(60000);
            }
        }

        private static void GetPlayerSummaries()
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            PlayersList players = new PlayersList();

            // Get Top 100 Unprocessed Players
            players.GetUnprocessedPlayers(100);

            // Check for and Recover Local Data.
            d2Dm.GetNewPlayerSummariesRecoverLocalData(players);

            // Get Top 100 Unprocessed Players
            players.GetUnprocessedPlayers(100);

            // Get or Create And Increment SteamRequest
            SteamRequests steamRequests;
            GetAndIncrementSteamRequest(out steamRequests);

            // Get Live Data.
            if (d2Dm.GetNewPlayerSummaries(players))
            {
                // New Data Found, sleep for 1 seconds as steam requests before continuing.
                Thread.Sleep(1000);
            }
            else
            {
                // No New Data Found, sleep for 60 seconds to save daily requests.
                Console.WriteLine("No New Teams Found, Sleeping for 60 Seconds.");
                Thread.Sleep(60000);
            }
        }

        private static void GetAndIncrementSteamRequest(out SteamRequests steamRequests)
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

            // Increment the Steam Request Counter
            Console.WriteLine("Steam request number : " + steamRequests.RequestNumber);
            steamRequests.RequestNumber++;
            steamRequests.InsertOrUpdate();
        }
    }
}