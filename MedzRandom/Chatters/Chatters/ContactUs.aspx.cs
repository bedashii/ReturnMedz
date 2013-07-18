using System;
using ChattersLib.ChattersDBBusiness;
using ChattersLib.ChattersDBLists;

namespace Chatters
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SystemInfo siAddress = new SystemInfo();
            SystemInfo siContactNumber = new SystemInfo();
            SystemInfo siEmail = new SystemInfo();

            siAddress.LoadItem("Address");
            siContactNumber.LoadItem("Contact Number");
            siEmail.LoadItem("Email Address");

            if (siAddress.RecordsExists)
                labelAddress.Text = siAddress.SIValue;
            if (siContactNumber.RecordsExists)
                labelContactNumber.Text = siContactNumber.SIValue;
            if (siEmail.RecordsExists)
                labelEmail.Text = siEmail.SIValue;
        }
    }
}