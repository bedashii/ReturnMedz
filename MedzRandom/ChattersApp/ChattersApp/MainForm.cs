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

        MenusControl menusControl = null;
        MenuItemsControl menuItemControl = null;
        SystemInfoControl systemInfoControl = null;

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (menusControl == null)
            {
                menusControl = new MenusControl();
                menusControl.Dock = DockStyle.Fill;
            }

            if (activeControl != null)
                splitContainer1.Panel2.Controls.Remove(activeControl);

            activeControl = menusControl;

            splitContainer1.Panel2.Controls.Add(menusControl);
        }

        private void buttonMenuItems_Click(object sender, EventArgs e)
        {
            if (menuItemControl == null)
            {
                menuItemControl = new MenuItemsControl();
                menuItemControl.Dock = DockStyle.Fill;
            }
            else
            {
                menuItemControl.ResetMenus();
            }

            if (activeControl != null)
                splitContainer1.Panel2.Controls.Remove(activeControl);

            activeControl = menuItemControl;

            splitContainer1.Panel2.Controls.Add(menuItemControl);
        }

        private void buttonSystemInfo_Click(object sender, EventArgs e)
        {
            if (systemInfoControl == null)
            {
                systemInfoControl = new SystemInfoControl();
                systemInfoControl.Dock = DockStyle.Fill;
            }

            if (activeControl != null)
                splitContainer1.Panel2.Controls.Remove(activeControl);

            activeControl = systemInfoControl;

            splitContainer1.Panel2.Controls.Add(systemInfoControl);
        }
    }
}
