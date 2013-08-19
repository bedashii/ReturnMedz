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
        if (!IsPostBack)
        {
            divHeros.Controls.Clear();
            divHeros.Controls.Add(new Label() { Text = "Top Heroes" });
            HeroControl hc;
            for (int i = 0; i < 5; i++)
            {
                hc = Page.LoadControl("~/HeroControl.ascx") as HeroControl;
                if (hc != null)
                {
                    hc.HeroImageUrl = @"http://media.steampowered.com/apps/dota2/images/heroes/elder_titan_sb.png";
                    hc.MatchesPlayed = i;

                    hc.MatchesWon = i != 0 ? Convert.ToDecimal(((decimal)1 / (decimal)i * (decimal)100).ToString("N2")) : Convert.ToDecimal(100.ToString("N2"));
                    divHeros.Controls.Add(hc);
                }
                hc = null;
            }

            divLastMatches.Controls.Clear();
            divLastMatches.Controls.Add(new Label() { Text = "Last Matches" });
            MatchControl mc;
            for (int i = 0; i < 5; i++)
            {
                mc = Page.LoadControl("~/MatchControl.ascx") as MatchControl;
                if (mc != null)
                {
                    mc.MatchID = "";
                    divLastMatches.Controls.Add(mc);
                }
                mc = null;
            }
        }
    }
}