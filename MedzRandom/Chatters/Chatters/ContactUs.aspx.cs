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


            labelAddress.Visible = labelAddressHeader.Visible = siAddress.RecordsExists;
            if (siAddress.RecordsExists)
                labelAddress.Text = siAddress.SIValue;

            labelContactNumber.Visible = labelContactNumberHeader.Visible = siContactNumber.RecordsExists;
            if (siContactNumber.RecordsExists)
                labelContactNumber.Text = siContactNumber.SIValue;

            labelEmail.Visible = labelEmailHeader.Visible = siEmail.RecordsExists;
            if (siEmail.RecordsExists)
                labelEmail.Text = siEmail.SIValue;
        }
    }
}