using System;
using System.Threading;
using DotaDbGenLib.Business;
using DotaDbGenLib.Lists;

namespace Dota2DataMinerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetTeams();
        }

        private static void GetTeams()
        {
            Dota2DataMiner.Class1 d2Dm = new Dota2DataMiner.Class1();

            TeamsList teams = new TeamsList();
            int? teamId = null;

            bool newTeamsAdded;

            SteamRequests steamRequests = new SteamRequests();
            steamRequests.GetByDate(DateTime.Now);

            if (!steamRequests.RecordExists)
            {
                steamRequests.RequestNumber = 0;
                steamRequests.Date = DateTime.Now.Date;
            }

            do
            {
                Console.WriteLine(steamRequests.RequestNumber.ToString());
                if (steamRequests.RequestNumber <= 99999)
                {
                    teamId = teams.GetMaxTeamID();
                    newTeamsAdded = d2Dm.GetNewTeams(teamId, 100);

                    if (!Dota2DataMiner.Class1.LocalRead)
                    {
                        if (steamRequests.Date < DateTime.Now.Date)
                        {
                            steamRequests = new SteamRequests();
                            steamRequests.Date = DateTime.Now.Date;
                            steamRequests.RequestNumber = 1;
                        }
                        else
                        {
                            steamRequests.RequestNumber++;
                        }
                        steamRequests.InsertOrUpdate();

                        Thread.Sleep(1000);
                    }

                    if (newTeamsAdded == false)
                    {
                        if (Dota2DataMiner.Class1.LocalRead)
                        {
                            Console.WriteLine("No New Teams Added, Sleeping for 60 Seconds...");
                            Thread.Sleep(60000);
                        }
                        else
                        {
                            Console.WriteLine("Local Data detected, recovering.");
                        }
                        newTeamsAdded = true;
                    }

                    // Reset Local Read Boolean
                    Dota2DataMiner.Class1.LocalRead = false;
                }
                else
                {
                    newTeamsAdded = false;
                }
            } while (newTeamsAdded);
        }
    }
}
