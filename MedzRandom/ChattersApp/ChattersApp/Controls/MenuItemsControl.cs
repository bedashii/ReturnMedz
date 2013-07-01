using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattersApp.Controls
{
    public partial class MenuItemsControl : UserControl
    {
        ChattersLib.ChattersDBLists.MenuItemList mil = null;

        public MenuItemsControl()
        {
            InitializeComponent();

            mil = new ChattersLib.ChattersDBLists.MenuItemList();
            mil.GetAll();

            menuItemListBindingSource.DataSource = mil;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            mil.UpdateAll();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            menuItemListBindingSource.AddNew();
        }
    }
}