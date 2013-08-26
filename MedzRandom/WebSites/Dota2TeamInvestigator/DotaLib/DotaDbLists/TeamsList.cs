using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Lists
{
    public partial class TeamsList : List<Business.Teams>
    {
        public TeamsList()
        {

        }

        public int? GetMaxTeamID()
        {
            return _data.GetMaxTeamID();
        }
    }
}