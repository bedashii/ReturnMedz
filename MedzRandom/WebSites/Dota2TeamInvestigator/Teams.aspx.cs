using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotaDbGenLib.Lists;

public partial class Teams : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HiddenFieldPageWidth.Value != "0")
            ListViewPlayers.GroupItemCount = Convert.ToInt32(HiddenFieldPageWidth.Value);
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        if (TextBoxSearchBox.Text == "")
            Search(null);
        else
            Search(TextBoxSearchBox.Text);
    }

    private int itemsPerPage = 16;

    private void Search(string searchText)
    {
        int current = Convert.ToInt32(HiddenFieldCurrentPage.Value) - 1;
        int total = Convert.ToInt32(HiddenFieldTotalPages.Value);

        TeamsList teamsList = new TeamsList();
        if (TextBoxSearchBox.Text == "")
            teamsList.GetAll(current == 0 ? 0 : ((current * itemsPerPage) + 1), current == 0 ? itemsPerPage : itemsPerPage - 1);
        else
            teamsList.GetByLikeName(TextBoxSearchBox.Text, current == 0 ? 0 : ((current * itemsPerPage) + 1), current == 0 ? itemsPerPage : itemsPerPage - 1);

        // If exact match found, move to the top of the list.
        DotaDbGenLib.Business.Teams team = teamsList.Find(x => x.TeamName == TextBoxSearchBox.Text);
        if (team != null)
        {
            teamsList.Remove(team);
            teamsList.Insert(0, team);
        }

        ListViewPlayers.DataSource = teamsList;
        ListViewPlayers.DataBind();
    }

    protected void ButtonPrevious_OnClick(object sender, EventArgs e)
    {
        HiddenFieldCurrentPage.Value = (Convert.ToInt32(HiddenFieldCurrentPage.Value) - 1).ToString();

        Search();

        SetEditModeNextPrevious();
    }

    protected void ButtonNext_OnClick(object sender, EventArgs e)
    {
        HiddenFieldCurrentPage.Value = (Convert.ToInt32(HiddenFieldCurrentPage.Value) + 1).ToString();

        Search();

        SetEditModeNextPrevious();
    }

    private void SetEditModeNextPrevious()
    {
        int current = Convert.ToInt32(HiddenFieldCurrentPage.Value);
        int total = Convert.ToInt32(HiddenFieldTotalPages.Value);

        if (current == 1)
        {
            ButtonPrevious.Enabled = false;
        }
        else
        {
            ButtonPrevious.Enabled = true;
        }

        if (current < total)
        {
            ButtonNext.Enabled = true;
        }
        else
        {
            ButtonNext.Enabled = false;
        }
    }
}