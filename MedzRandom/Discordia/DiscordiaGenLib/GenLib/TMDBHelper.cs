using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib
{
    public static class TMDBHelper
    {
        public static WatTmdb.V3.Tmdb TMDB;

        // Can only do 30 queries every 10 seconds
        // Need to build a contstraint to wait 10 seconds after 30 queries.
    }
}
