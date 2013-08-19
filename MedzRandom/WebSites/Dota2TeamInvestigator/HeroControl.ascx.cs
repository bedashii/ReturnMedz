using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HeroControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string HeroImageUrl
    {
        get
        {
            return ImageButtonHero.ImageUrl;
        }
        set
        {
            ImageButtonHero.ImageUrl = value;
        }
    }

    public string HeroUrl
    {
        get
        {
            return ImageButtonHero.PostBackUrl;
        }
        set
        {
            ImageButtonHero.PostBackUrl = value;
        }
    }

    public int MatchesPlayed
    {
        get
        {
            return Convert.ToInt32(LabelMatchesPlayed.Text);
        }
        set
        {
            LabelMatchesPlayed.Text = value.ToString();
        }
    }

    public decimal MatchesWon
    {
        get
        {
            return Convert.ToDecimal(LabelMatchesWon.Text);
        }
        set
        {
            LabelMatchesWon.Text = value.ToString() + "%";
        }
    }
}