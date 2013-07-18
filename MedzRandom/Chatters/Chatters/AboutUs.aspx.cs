using System;
using ChattersLib.ChattersDBBusiness;

namespace Chatters
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SystemInfo siAboutUsIntro = new SystemInfo();
            siAboutUsIntro.LoadItem("About Us Introduction");

            if (siAboutUsIntro.RecordsExists)
                labelAboutUs.Text = siAboutUsIntro.SIValue;
            else
                labelAboutUs.Text = "When were we established my dear?<BR>No Idea, like yesterday?<BR>Naw can't be!<BR>Says here it's been like years.";
        }
    }
}