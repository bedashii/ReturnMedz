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

        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            string fromAddress = "WJAMostert@Gmail.com";
            //Password of your gmail address
            const string fromPassword = "masterCh1ef";

            // any address where the email will be sending
            string toAddress = fromAddress;

            // Passing the values and make a email formate to display
            string subject = "Chatters - Leave Us A Message";
            string body = "From: " + textboxName.Text + "\n";
            body += "Contact Info: " + textboxTelEmail.Text + "\n";
            body += "Message: \n" + textboxMessage.Text + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
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
                    SendMail();
                    DisplayMessage.Text = "Message sent!";
                }

                DisplayMessage.Visible = true;
            }
            catch (Exception) { }
        }
    }
}