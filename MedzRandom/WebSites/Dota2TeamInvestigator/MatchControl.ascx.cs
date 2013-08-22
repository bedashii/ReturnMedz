using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MatchControl : System.Web.UI.UserControl
{
    private string _matchID;
    private int _heroID;

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

    public string MatchID
    {
        get { return _matchID; }
        set
        {
            _matchID = value;

            // TODO
            // Find Match Details based on Match ID.
            // Get Player Hero details in match.
            // Win/Lose;KDA;Items
        }
    }

    public int HeroID
    {
        get { return _heroID; }
        set
        {
            if (_heroID != value)
            {
                _heroID = value;

                // TODO
                // Set Hero Image
                //ImageButtonHero.ImageUrl = "";
            }
        }
    }
}