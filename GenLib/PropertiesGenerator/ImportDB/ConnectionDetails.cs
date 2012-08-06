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
        public DataHelper.DataHelper Connect { get; set; }
        
        public ConnectionDetails()
        {
            InitializeComponent();

            SetConnectioDetails();
        }

        private void SetConnectioDetails()
        {
            textBoxServerName.Text = System.Configuration.ConfigurationManager.AppSettings["LCDServer"].ToString();
            textBoxDatabaseName.Text = System.Configuration.ConfigurationManager.AppSettings["LCDDatabase"].ToString();
            textBoxLogin.Text = System.Configuration.ConfigurationManager.AppSettings["LCDLogin"].ToString();

            string rp = System.Configuration.ConfigurationManager.AppSettings["LCDStorePassword"].ToString();

            if (rp == "" || rp == "False")
                checkBoxRememberPassword.Checked = false;
            else
            {
                checkBoxRememberPassword.Checked = true;
                textBoxPassword.Text = System.Configuration.ConfigurationManager.AppSettings["LCDPassword"].ToString();
            }
        }

        private void SaveConnectionDetails()
        {
            System.Configuration.Configuration config =
          System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            config.AppSettings.Settings["LCDServer"].Value = textBoxServerName.Text;
            config.AppSettings.Settings["LCDDatabase"].Value = textBoxDatabaseName.Text;
            config.AppSettings.Settings["LCDLogin"].Value = textBoxLogin.Text;
            config.AppSettings.Settings["LCDStorePassword"].Value = checkBoxRememberPassword.Checked.ToString();
            config.AppSettings.Settings["LCDPassword"].Value = checkBoxRememberPassword.Checked ? textBoxPassword.Text : "";

            //config.Save(System.Configuration.ConfigurationSaveMode.Full, true);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString = "";
            connectionString += "user id=" + textBoxLogin.Text + ";";
            connectionString += "password=" + textBoxPassword.Text + ";";
            connectionString += "server=" + textBoxServerName.Text + ";";
            connectionString += "database=" + textBoxDatabaseName.Text;

            Connect = new DataHelper.DataHelper(connectionString);
            if (Connect.CanConnect)
            {
                // This Shit doesn't work.
                SaveConnectionDetails();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                MessageBox.Show("Connection failed\nPlease make sure that your connection details are correct.");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // If you click cancel it removes the LCD app settings... WHY?!?
        }
    }
}
