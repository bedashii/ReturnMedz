using System;
using System.Web;

namespace Chatters
{
    public partial class ChattersMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChattersLib.ChattersDBLists.SystemInfoList systemInfoList = new ChattersLib.ChattersDBLists.SystemInfoList();
            systemInfoList.GetByKey("VisitorsCount");

            HttpCookie chattersVisitorCookie = Request.Cookies["ChattersVisitor"];

            if (chattersVisitorCookie == null)
            {
                HttpCookie newCookie = new HttpCookie("ChattersVisitor");
                newCookie.Expires = DateTime.Now.AddDays(1);
                newCookie["DateTime"] = DateTime.Now.ToShortDateString();
                Response.Cookies.Add(newCookie);

                if (systemInfoList.Count == 0)
                {
                    ChattersLib.ChattersDBBusiness.SystemInfo visitorsCount = new ChattersLib.ChattersDBBusiness.SystemInfo();
                    visitorsCount.SIKey = "VisitorsCount";
                    visitorsCount.SIValue = "1";
                    systemInfoList.Add(visitorsCount);
                    systemInfoList.UpdateAll();
                }
                else
                {
                    if (systemInfoList[0].SIKey == "VisitorsCount")
                    {
                        systemInfoList[0].SIValue = (Convert.ToInt32(systemInfoList[0].SIValue) + 1).ToString();
                        systemInfoList.UpdateAll();
                    }
                }
            }

            labelVisitors.Text = "Visitors: " + systemInfoList[0].SIValue;
        }
    }
}