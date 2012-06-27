using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImportDB
{
    public partial class ConnectionDetails : Form
    {
        public ConnectionDetails()
        {
            InitializeComponent();
        }

        public DataHelper.DataHelper Connect { get; set; }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString = "";
            connectionString += "user id=" + textBoxLogin.Text + ";";
            connectionString += "password=" + textBoxPassword.Text + ";";
            connectionString += "server=" + textBoxServerName.Text + ";";
            connectionString += "database=" + textBoxDatabaseName.Text;

            Connect = new DataHelper.DataHelper(connectionString);
            if (Connect.CanConnect)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                MessageBox.Show("Connection failed\nPlease make sure that your connection details are correct.");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
