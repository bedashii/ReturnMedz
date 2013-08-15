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
    }
}
