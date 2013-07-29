using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProofServer
{
    public partial class Form1 : Form
    {
        private ServerProcessor _serverProcessor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _serverProcessor = new ServerProcessor();
            _serverProcessor.MessageReceived += _serverProcessor_MessageReceived;

            BackgroundWorker bg = new BackgroundWorker();

            bg.DoWork += delegate { _serverProcessor.RunServer(); };
            bg.RunWorkerCompleted += delegate { bg.RunWorkerAsync(); };
            bg.RunWorkerAsync();
        }

        void _serverProcessor_MessageReceived(string message)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((MethodInvoker)delegate { textBox1.Text += message + Environment.NewLine; });
            }
            else
            {
                textBox1.Text += message + Environment.NewLine;
            }

        }
    }
}
