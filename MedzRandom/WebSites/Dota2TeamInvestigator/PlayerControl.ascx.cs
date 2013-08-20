using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlayerControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{

        // Receive Steam ID
        // Search for Profile Picture and Name by Steam ID

        // Search for top 5 Heros' sorted by Matches Played.
            divHeros.Controls.Clear();
            divHeros.Controls.Add(new Label() { Text = "Top Heroes" });
            HeroControl hc;
            for (int i = 0; i < 5; i++)
            {
                hc = Page.LoadControl("~/HeroControl.ascx") as HeroControl;
                if (hc != null)
                {
                    // Load Hero By ID
                    hc.HeroImageUrl = @"http://media.steampowered.com/apps/dota2/images/heroes/elder_titan_sb.png";
                    
                    // Provide Player Hero Details.
                    hc.MatchesPlayed = i;
                    hc.MatchesWon = i != 0 ? Convert.ToDecimal(((decimal)1 / (decimal)i * (decimal)100).ToString("N2")) : Convert.ToDecimal(100.ToString("N2"));
                    divHeros.Controls.Add(hc);
                }
                hc = null;
            }
        // Search for top 5 Last Matches
            divLastMatches.Controls.Clear();
            divLastMatches.Controls.Add(new Label() { Text = "Last Matches" });
            MatchControl mc;
            for (int i = 0; i < 5; i++)
            {
                mc = Page.LoadControl("~/MatchControl.ascx") as MatchControl;
                if (mc != null)
                {
                    // Load Hero By ID.
                    mc.HeroID = 0;
                    // Load Match By ID.
                    mc.MatchID = "";
                    
                    divLastMatches.Controls.Add(mc);
                }
                mc = null;
            }
        //}
    }
}