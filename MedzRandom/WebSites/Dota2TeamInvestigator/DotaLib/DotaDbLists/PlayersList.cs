using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Lists
{
    public partial class PlayersList : List<Business.Players>
    {
        public PlayersList()
        {

        }

        public void GetUnprocessedPlayers(int topCount)
        {
            _data.LoadUnprocessedPlayers(this, topCount);
        }

        public long GetPlayerWithNoMatchRecords()
        {
            return _data.GetPlayerWithNoMatchRecords();
        }
    }
}