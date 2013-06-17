using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace R3_Zipper
{
    public partial class Form1 : Form
    {
        List<FileInfo> _files;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _files = new List<FileInfo>();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<string> filesToDelete = new List<string>();

                foreach (var file in listBox1.SelectedItems)
                    if (_files.Exists(x => x.FullName == file.ToString()))
                        filesToDelete.Add(file.ToString());

                if (filesToDelete.Count > 0)
                {
                    foreach (string fileToDelete in filesToDelete)
                    {
                        _files.Remove(_files.Find(x => x.FullName == fileToDelete));
                        listBox1.Items.Remove(fileToDelete);
                    }
                }
            }
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                foreach (string fileName in ofd.FileNames)
                {
                    _files.Add(new FileInfo(fileName));
                    listBox1.Items.Add(fileName);
                }
        }

        private void createArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ZipperLib.Archive archive = 
                    (!String.IsNullOrEmpty(TextBoxSize.Text) && Convert.ToInt32(TextBoxSize.Text) > 0) ? 
                    new ZipperLib.Archive(TextBoxArchiveName.Text, _files, Convert.ToInt32(TextBoxSize.Text)) : 
                    new ZipperLib.Archive(TextBoxArchiveName.Text, _files);

                archive.CreateArchive();

                MessageBox.Show("Archive Created");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}
