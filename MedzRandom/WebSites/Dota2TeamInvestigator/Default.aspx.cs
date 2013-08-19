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
}