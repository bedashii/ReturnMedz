using System;
using ChattersLib.ChattersDBBusiness;

namespace Chatters
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SystemInfo systemInfo = new SystemInfo();
            systemInfo.LoadItem("Home Introduction");
            if (systemInfo.RecordsExists)
                labelIntoduction.Text = systemInfo.SIValue;
            else
                labelIntoduction.Text = "This is the Introduction." + "<BR>" + "Someone should write something here." +
                                        "<BR>" + "#JustSayin TEST TEST TEST";
        }
    }
}