using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatters
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelAboutUs.Text = "When were we established my dear?<BR>No Idea, like yesterday?<BR>Naw can't be!<BR>Says here it's been like years.";
        }
    }
}