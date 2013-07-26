using System;
using ChattersLib.ChattersDBBusiness;
using ChattersLib.ChattersDBLists;
using System.Net;

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

        private string Address;
        private string Password;
        private string Host;
        private string Port;

        protected void SendMail()
        {
            if (string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Host) ||
                string.IsNullOrEmpty(Port))
            {
                SystemInfoList systemInfo = new SystemInfoList();
                systemInfo.GetAll("Contact Us Email");

                systemInfo.ForEach(x =>
                    {
                        if (x.SIKey == "Contact Us Email Address")
                        {
                            Address = x.SIValue;
                        }
                        else if (x.SIKey == "Contact Us Email Password")
                        {
                            Password = x.SIValue;
                        }
                        else if (x.SIKey == "Contact Us Email Host")
                        {
                            Host = x.SIValue;
                        }
                        else if (x.SIKey == "Contact Us Email Port")
                        {
                            Port = x.SIValue;
                        }
                    });
            }

            // Passing the values and make a email formate to display
            string subject = "Chatters - Leave Us A Message";
            string body = "From: " + textboxName.Text + "\n";
            body += "Contact Info: " + textboxTelEmail.Text + "\n";
            body += "Message: \n" + textboxMessage.Text + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = Host;
                smtp.Port = Convert.ToInt32(Port);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(Address, Password);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(Address, Address, subject, body);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textboxName.Text.Trim() == "")
                {
                    DisplayMessage.Text = "Please fill in your name.";
                }
                else if (textboxTelEmail.Text.Trim() == "")
                {
                    DisplayMessage.Text = "Please fill in your contact details.";
                }
                else if (textboxMessage.Text.Trim() == "")
                {
                    DisplayMessage.Text = "Please fill in a message for us.";
                }
                else
                {
                    DisplayMessage.Visible = true;
                    DisplayMessage.Text = "Sending Message...";
                    SendMail();
                    DisplayMessage.Text = "Message sent!";
                }

                DisplayMessage.Visible = true;
            }
            catch (Exception)
            {
                DisplayMessage.Text = "Message failed to send. Please contact the system administrator.";
                DisplayMessage.Visible = true;
            }
        }
    }
}