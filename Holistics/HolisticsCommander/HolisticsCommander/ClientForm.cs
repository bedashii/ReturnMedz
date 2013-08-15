using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolisticsCommander
{
    public partial class ClientForm : Form
    {
        ClientProcessor _processor;
        Lib.Business.CommApplication _selectedItem;
        bool _newItem = false;

        public ClientForm()
        {
            InitializeComponent();
        }

        void ClientProcessor_MessageReceived(string Message)
        {
            if (Message != null)
            {
                bool succesful = Convert.ToBoolean(Message);
                TSMTextBoxApplication.BackColor = succesful ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            else
            {
                TSMTextBoxApplication.BackColor = System.Drawing.Color.OrangeRed;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _processor = new ClientProcessor();
            _processor.MessageReceived += ClientProcessor_MessageReceived;

            BindingSourceCommApplicationList.DataSource = _processor.CommApplicationsList;
            BindingSourceCommApplicationList.ResetBindings(false);
        }

        void EnterEditMode(object sender)
        {
            var item = (ToolStripMenuItem)sender;

            SetControlsAccessibility(false);

            if (item == this.newToolStripMenuItem)
            {
                BindingSourceSelectedItem.DataSource = _processor.CreateNewCommApp();
                BindingSourceSelectedItem.ResetBindings(false);

                TextBoxName.Clear();
                TextBoxPath.Clear();
                DataGridViewMain.Enabled = false;

                _newItem = true;
            }
            else
                _newItem = false;
        }

        void ExitEditMode(object sender)
        {
            var item = (ToolStripMenuItem)sender;

            SetControlsAccessibility(true);

            if (item == this.saveToolStripMenuItem)
            {
                if (_newItem)
                    _processor.SaveNewCommApp(TextBoxName.Text, TextBoxPath.Text);
                else
                    _processor.SaveCommApp();
            }
            else
                _processor.RefreshDataSource();

            DataGridViewMain.Enabled = true;
            BindingSourceCommApplicationList.DataSource = _processor.CommApplicationsList;
            BindingSourceCommApplicationList.ResetBindings(false);
        }

        void SetControlsAccessibility(bool accessible)
        {
            editToolStripMenuItem.Enabled =
            newToolStripMenuItem.Enabled =
            deleteToolStripMenuItem.Enabled =
            exitToolStripMenuItem.Enabled =
            PanelSplitMain.Panel1Collapsed = accessible;

            saveToolStripMenuItem.Enabled =
            cancelToolStripMenuItem.Enabled = accessible ? false : true;

            TextBoxName.ReadOnly = accessible;
            TextBoxPath.ReadOnly = accessible;
        }

        void SetSelectedItemData(Lib.Business.CommApplication selectedItem)
        {
            if (selectedItem != null)
                _selectedItem = selectedItem;
            else
                _selectedItem = new Lib.Business.CommApplication();

            BindingSourceSelectedItem.DataSource = _selectedItem;
            BindingSourceSelectedItem.ResetBindings(false);
        }

        private void DataGridViewMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SetSelectedItemData((Lib.Business.CommApplication)DataGridViewMain.Rows[e.RowIndex].DataBoundItem);
                TSMTextBoxApplication.Text = _selectedItem.Name;
            }
        }

        private void TSMI_EnterEditMode_Click(object sender, EventArgs e)
        { // TSMI = ToolStripMenuItem
            EnterEditMode(sender);
        }

        private void TSMI_ExitEditMode_Click(object sender, EventArgs e)
        { // TSMI = ToolStripMenuItem
            ExitEditMode(sender);
        }

        private void TSMI_Delete_Click(object sender, EventArgs e)
        {// TSMI = ToolStripMenuItem
            if (MessageBox.Show("Delete Item?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                _processor.DeleteItem(_selectedItem);
                BindingSourceCommApplicationList.DataSource = _processor.CommApplicationsList;
                BindingSourceCommApplicationList.ResetBindings(false);
            }
        }

        private void TSMI_ExitProgram_Click(object sender, EventArgs e)
        {// TSMI = ToolStripMenuItem
            this.Close();
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processor.Command_Kill(_selectedItem.Name);
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processor.Command_Execute(_selectedItem.Path);
        }
    }
}
