using System;
using System.Windows.Forms;

namespace ProofClient
{
    public partial class Form1 : Form
    {
        private ClientProcessor _clientProcessor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _clientProcessor = new ClientProcessor();
            _clientProcessor.MessageReceived += _clientProcessor_MessageReceived;
        }

        void _clientProcessor_MessageReceived(string message)
        {
            textBox2.Text += message + Environment.NewLine;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (string.IsNullOrEmpty(textBoxServerIP.Text))
                {
                    _clientProcessor.SendMessage(textBox1.Text);
                }
                else
                {
                    _clientProcessor.SendMessage(textBoxServerIP.Text, textBox1.Text);
                }

            }
        }
    }
}
