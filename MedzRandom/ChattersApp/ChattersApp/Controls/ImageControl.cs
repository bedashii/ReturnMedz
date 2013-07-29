using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattersApp.Controls
{
    public partial class ImageControl : UserControl
    {
        public ImageControl()
        {
            InitializeComponent();
        }

        private void ImageControl_Load(object sender, EventArgs e)
        {

        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (textBoxLocation.Text == "" || !File.Exists(textBoxLocation.Text))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxLocation.Text = ofd.FileName;
                }
            }

            if (textBoxLocation.Text == "" || !File.Exists(textBoxLocation.Text))
            {
                MessageBox.Show("Picture not found.");
                return;
            }


        }
    }
}
