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
    public partial class MenusControl : UserControl
    {
        public MenusControl()
        {
            InitializeComponent();

            menuList = new ChattersLib.ChattersDBLists.MenuList();
            menuList.GetAll();

            menuListBindingSource.DataSource = menuList;
        }

        ChattersLib.ChattersDBLists.MenuList menuList = null;

        private void buttonNew_Click(object sender, EventArgs e)
        {
            menuListBindingSource.AddNew();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            menuList.UpdateAll();
            menuListBindingSource.ResetBindings(false);
        }

        private void dataGridViewMenus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewMenus.Columns["buttonDelete"].Index)
            {
                if (MessageBox.Show("Are you sure you wish to delete the selected Menu Item?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Delete Current row.
                    ChattersLib.ChattersDBBusiness.Menu m = ((ChattersLib.ChattersDBBusiness.Menu)dataGridViewMenus.Rows[e.RowIndex].DataBoundItem);
                    if (m.RecordsExists)
                        m.Delete();

                    menuList.Remove(m);

                    menuListBindingSource.ResetBindings(false);
                }
            }
        }
    }
}