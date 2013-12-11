using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FTP_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string URL
        {
            get
            {
                return TextBoxURL.Text.EndsWith("/") ? TextBoxURL.Text : TextBoxURL.Text + "/";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ftp://ftp.domain.com/doesntexist.txt
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + TextBoxFilename.Text);
            request.Credentials = new NetworkCredential(TextBoxUserName.Text, TextBoxPassword.Text);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                TextBoxOutput.Text = ((decimal)((decimal)response.ContentLength / 1024)).ToString() + "kB";
            }
            catch (WebException ex)
            {
                TextBoxOutput.Text = ex.ToString();
                
                FtpWebResponse response = null;
                if (ex.Response != null)
                {
                    response = (FtpWebResponse)ex.Response;
                    TextBoxOutput.Text += Environment.NewLine + response.ToString();
                }

                if (response != null && response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    //Does not exist
                }
            }

        }
    }
}
