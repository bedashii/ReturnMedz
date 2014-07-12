using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadSorter
{
    public partial class DeleteConfirmationForm : Form
    {
        public DeleteConfirmationForm()
        {
            InitializeComponent();
        }

        public BindingSource CustomFileBindingSource
        {
            get
            {
                return customFileBindingSource;
            }
            set
            {
                customFileBindingSource = value;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
