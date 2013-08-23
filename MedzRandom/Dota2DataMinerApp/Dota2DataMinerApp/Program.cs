using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Dota2DataMiner.Class1 d2dm = new Dota2DataMiner.Class1();

            int? teamID = DotaLib.DotaDBLists.TeamList.GetMaxTeamID();

            bool newTeamsAdded;
            do
            {
                newTeamsAdded = d2dm.GetNewTeams(teamID, 25);
            } while (newTeamsAdded);
        }
    }
}
