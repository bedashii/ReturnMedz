using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotaDbGenLib.Lists;

public partial class Players : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HiddenFieldPageWidth.Value != "0")
            ListViewPlayers.GroupItemCount = Convert.ToInt32(HiddenFieldPageWidth.Value);
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        DotaDbGenLib.Lists.PlayersList playersList = new PlayersList();
        if (TextBoxSearchBox.Text == "")
            playersList.GetAll(20);
        else
            playersList.GetByLikeName(TextBoxSearchBox.Text);

        // If exact match found, move to the top of the list.
        DotaDbGenLib.Business.Players player = playersList.Find(x => x.PersonaName == TextBoxSearchBox.Text);
        if (player != null)
        {
            playersList.Remove(player);
            playersList.Insert(0, player);
        }

        ListViewPlayers.DataSource = playersList;
        ListViewPlayers.DataBind();
    }
}