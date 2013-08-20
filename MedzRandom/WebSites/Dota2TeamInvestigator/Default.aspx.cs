using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelPlayers.Controls.Clear();
            PlayerControl pc;
            for (int i = 0; i < 5; i++)
            {
                pc = Page.LoadControl("~/PlayerControl.ascx") as PlayerControl;
                if (pc != null)
                    PanelPlayers.Controls.Add(pc);
                pc = null;
            }
        }
    }
    protected void ButtonTeamSearch_Click(object sender, EventArgs e)
    {
        // TODO
        // Search Team Name

        // If one team found display players

        // If zero or more than one team found, go to advances search page.
    }
}