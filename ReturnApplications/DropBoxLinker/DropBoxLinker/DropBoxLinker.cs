using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DropBoxLinkerLib;

namespace DropBoxLinker
{
    public partial class DropBoxLinker : Form
    {
        public DropBoxLinker()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            foreach (string s in System.Configuration.ConfigurationManager.AppSettings.Get("Extensions").Replace(" ", "").Split(','))
                ComboBoxExtension.Items.Add(s);

            if (ComboBoxExtension.Items.Count > 0)
                ComboBoxExtension.SelectedIndex = 0;
        }

        void GetPublicLinks()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string[] links = new string[0];
                System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(TextBoxFilePath.Text);
                string extension = ComboBoxExtension.Text;

                if (dinfo.Exists)
                {
                    Array.Resize(ref links, extension == "" ? dinfo.GetFiles().Count() : dinfo.GetFiles("*." + extension).Count());
                    links = Linker.GetPublicURLFromFolder(dinfo.FullName, extension);
                }
                else
                {
                    Array.Resize(ref links, 1);
                    links[0] = Linker.GetPublicURLFromFile(dinfo.FullName);
                }


                ListBoxLinks.Items.Clear();

                foreach (string s in links)
                    ListBoxLinks.Items.Add(s);


                foreach (string s in links)
                    sb.AppendLine(s);

                System.Windows.Forms.Clipboard.SetText(sb.ToString());
            }
            catch (System.IO.IOException ioeX)
            {
                MessageBox.Show("IO Error: " + ioeX.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Error: " + ex.Message);
            }
        }

        private void ButtonGO_Click(object sender, EventArgs e)
        {
            GetPublicLinks();
        }

        private void TextBoxFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GetPublicLinks();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
