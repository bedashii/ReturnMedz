using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolisticsCommander
{
    public partial class ServerForm : Form
    {
        private bool _initialMinimize = false;
        private string _notifyIconDisplayBaloonTitle
        {
            get { return "Holistics Commander"; }
        }
        private string _notifyIconDisplayBaloonText
        {
            get { return "Holistics Commander Server has started on " + _processor.ServerDetails; }
        }
        private string _notifyIconDisplayMessage
        {
            get { return "Holisitcs Commander Server running on " + _processor.ServerDetails; }
        }

        ServerProcessor _processor;
        BackgroundWorker _bg;

        public ServerForm()
        {
            InitializeComponent();
            _processor = new ServerProcessor();
            _processor.MessageReceived += ServerProcessor_MessageReceived;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            _bg = new BackgroundWorker();
            _bg.DoWork += delegate { _processor.Initialize(); };
            _bg.RunWorkerCompleted += delegate { _bg.RunWorkerAsync(); };
            _bg.RunWorkerAsync();

            this.Text += " " + _processor.ServerDetails;
            NotifyIconServer.Text = _processor.ServerDetails;
            WindowState = FormWindowState.Minimized;
        }

        void ServerProcessor_MessageReceived(string message)
        {
            message = message + Environment.NewLine;

            if (TextBoxRServerForm.InvokeRequired)
            {
                TextBoxRServerForm.Invoke((MethodInvoker)delegate { TextBoxRServerForm.AppendText(message); });
            }
            else
            {
                TextBoxRServerForm.AppendText(message);
            }
        }

        private void ServerForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                NotifyIconServer.Text = _notifyIconDisplayMessage;
                NotifyIconServer.Visible = true;

                if (_initialMinimize == false)
                {
                    NotifyIconServer.BalloonTipTitle = _notifyIconDisplayBaloonTitle;
                    NotifyIconServer.BalloonTipText = _notifyIconDisplayBaloonText;
                    NotifyIconServer.BalloonTipIcon = ToolTipIcon.Info;
                    NotifyIconServer.ShowBalloonTip(500);
                    _initialMinimize = true;
                }
                else
                {
                    NotifyIconServer.BalloonTipTitle = _notifyIconDisplayBaloonTitle;
                    NotifyIconServer.BalloonTipText = _notifyIconDisplayMessage;
                    NotifyIconServer.BalloonTipIcon = ToolTipIcon.Info;
                    NotifyIconServer.ShowBalloonTip(500);
                }
                        
            }
            else
            {
                ShowInTaskbar = true;
                NotifyIconServer.Visible = false;
            }
        }
    }
}
