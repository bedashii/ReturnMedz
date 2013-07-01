using ChattersApp.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattersApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Control activeControl = null;

        MenuItemsControl menuItemControl = null;

        private void buttonMenuItems_Click(object sender, EventArgs e)
        {
            if (menuItemControl == null)
            {
                menuItemControl = new MenuItemsControl();
                menuItemControl.Dock = DockStyle.Fill;
            }

            if (activeControl != null)
                splitContainer1.Panel2.Controls.Remove(activeControl);

            activeControl = menuItemControl;

            splitContainer1.Panel2.Controls.Add(menuItemControl);
        }
    }
}
