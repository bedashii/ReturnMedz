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
        ChattersLib.ChattersDBLists.MenuItemList menuItemList = null;

        public MenuItemsControl()
        {
            InitializeComponent();

            menuItemList = new ChattersLib.ChattersDBLists.MenuItemList();
            menuItemList.GetAll();

            menuItemListBindingSource.DataSource = menuItemList;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            menuItemList.UpdateAll();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            menuItemListBindingSource.AddNew();
        }

        private void dataGridViewMenuItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewMenuItems.Columns["buttonDelete"].Index)
            {
                if (MessageBox.Show("Are you sure you wish to delete the selected Menu Item?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Delete Current row.
                    ChattersLib.ChattersDBBusiness.MenuItem mi = ((ChattersLib.ChattersDBBusiness.MenuItem)dataGridViewMenuItems.Rows[e.RowIndex].DataBoundItem);
                    mi.Delete();

                    menuItemList.Remove(mi);

                    menuItemListBindingSource.ResetBindings(false);
                }
            }
        }
    }
}