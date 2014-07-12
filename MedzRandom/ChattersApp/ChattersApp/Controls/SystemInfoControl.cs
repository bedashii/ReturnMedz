using System;
using System.Windows.Forms;
using ChattersLib.ChattersDBLists;

namespace ChattersApp.Controls
{
    public partial class SystemInfoControl : UserControl
    {
        private SystemInfoList systemInfoList;

        public SystemInfoControl()
        {
            InitializeComponent();

            systemInfoList = new SystemInfoList();
            systemInfoList.GetAll();

            systemInfoListBindingSource.DataSource = systemInfoList;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            systemInfoListBindingSource.AddNew();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            systemInfoList.UpdateAll();
            systemInfoListBindingSource.ResetBindings(false);
        }

        private void dataGridViewSystemInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn dataGridViewColumn = dataGridViewSystemInfo.Columns["buttonDelete"];
            if (dataGridViewColumn != null && e.ColumnIndex == dataGridViewColumn.Index)
            {
                if (MessageBox.Show("Are you sure you wish to delete the selected System Info Record?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Delete Current row.
                    ChattersLib.ChattersDBBusiness.SystemInfo systemInfo = ((ChattersLib.ChattersDBBusiness.SystemInfo)dataGridViewSystemInfo.Rows[e.RowIndex].DataBoundItem);
                    if (systemInfo.RecordsExists)
                        systemInfo.Delete();

                    systemInfoList.Remove(systemInfo);

                    systemInfoListBindingSource.ResetBindings(false);
                }
            }
        }
    }
}
