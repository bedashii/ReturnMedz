using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotaDbGenLib.Business;

public partial class PlayerControl : System.Web.UI.UserControl
{
    private string _avatarUrl;
    private string _personaName;
    private string _wins;
    private Players _player;

    public DotaDbGenLib.Business.Players Player
    {
        get { return _player; }
        set
        {
            if (_player != value)
            {
                _player = value;

                AvatarUrl = _player.AvatarFull;
                PersonaName = _player.PersonaName;
                Wins = "0";
            }
        }
    }

    public string AvatarUrl
    {
        get
        {
            return ImageButtonAvatar.ImageUrl;
        }
        set
        {
            if (ImageButtonAvatar.ImageUrl != value)
                ImageButtonAvatar.ImageUrl = value;
        }
    }

    public string PersonaName
    {
        get
        {
            return LabelPersonaName.Text;
        }
        set
        {
            if (LabelPersonaName.Text != value)
                LabelPersonaName.Text = value;
        }
    }

    public string Wins
    {
        get
        {
            return LabelWins.Text;
        }
        set
        {
            if (LabelWins.Text != value)
                LabelWins.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButtonAvatar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(AvatarUrl);
    }
}