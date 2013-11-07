using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotaDbGenLib.Business;

public partial class Controls_TeamControl : System.Web.UI.UserControl
{
    private Teams _team;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public DotaDbGenLib.Business.Teams Team
    {
        get
        {
            return _team;
        }
        set
        {
            if (_team != value)
            {
                _team = value;

                AvatarUrl = "";
                TeamName = _team.TeamName;
                GamesPlayed = "-1";
                Wins = "9999%";
            }
        }
    }

    public string AvatarUrl
    {
        get { return ImageButtonAvatar.ImageUrl; }
        set
        {
            if (ImageButtonAvatar.ImageUrl != value)
            {
                ImageButtonAvatar.ImageUrl = value;
            }
        }
    }

    public string TeamName
    {
        get { return LabelTeamName.Text; }
        set
        {
            if (LabelTeamName.Text != value)
                LabelTeamName.Text = value;
        }
    }

    public string GamesPlayed
    {
        get { return LabelGamesPlayed.Text; }
        set
        {
            if (LabelGamesPlayed.Text != value)
                LabelGamesPlayed.Text = value;
        }
    }

    public string Wins
    {
        get { return LabelWins.Text; }
        set
        {
            if (LabelWins.Text != value)
                LabelWins.Text = value;
        }
    }

    protected void ImageButtonAvatar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(AvatarUrl);
    }
}