using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaLib.DotaDBBusiness;

namespace DotaLib.DotaDBLists
{
    public class TeamList:List<TeamBusiness>
    {
        public static int? GetMaxTeamID()
        {
            throw new NotImplementedException();
            //"SELECT MAX(ID) FROM TEAMS"
        }
    }
}
