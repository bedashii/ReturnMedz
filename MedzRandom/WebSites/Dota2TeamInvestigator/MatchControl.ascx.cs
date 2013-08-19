using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MatchControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButtonHero.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/heroes/elder_titan_sb.png";

        ImageButtonItem1.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/items/recipe_rapier_lg.png";
        ImageButtonItem2.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/items/recipe_rapier_lg.png";
        ImageButtonItem3.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/items/recipe_rapier_lg.png";
        ImageButtonItem4.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/items/recipe_rapier_lg.png";
        ImageButtonItem5.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/items/recipe_rapier_lg.png";
        ImageButtonItem6.ImageUrl = @"http://media.steampowered.com/apps/dota2/images/items/recipe_rapier_lg.png";
    }

    public string MatchID { get; set; }
}