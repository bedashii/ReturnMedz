using LainsDecryptor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LainsDecryptor.Models;
using LainsDecryptor.Extensions;
using System.Configuration;

namespace LainsDecryptor
{
    public partial class MainForm : Form
    {

        DecryptingService Service;
        Dictionary<string, string> IndexDictionary = Configs.IndexDictionary;

        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            Service = new DecryptingService();
            completedFriendshipGuideModelBindingSource.DataSource = Service.CompletedGuides;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["LastIndices"].Value = GetCSVDictionaryString();
            config.Save();
        }

        private string GetCSVDictionaryString()
        {
            var s = string.Empty;

            foreach (var index in IndexDictionary)
            {
                s += index.Value;
                s += index.Value.Equals(IndexDictionary.Last().Value) ? string.Empty : ",";
            }

            return s;
        }

        private void BuildListBoxes()
        {
            foreach (var guide in Service.CompletedGuides)
            {
                var listbox = new ListBox();

                listbox.Font = new Font("Consolas", 8.25f);
                listbox.Name = guide.PersonSystemName;
                listbox.HorizontalScrollbar = true;
                listbox.Items.Add(string.Empty);

                foreach (var eevent in guide.Events)
                {
                    listbox.Items.Add($"Level: {eevent.Level}");
                    listbox.Items.Add($"Day: {eevent.Day}");
                    listbox.Items.Add($"Time: {eevent.Time}");
                    listbox.Items.Add($"Location: {eevent.Location}");

                    eevent.Instructions.ForEach(instruction => listbox.Items.Add(instruction));

                    listbox.Items.Add("===============================================");
                }

                PanelTableMain.Controls.Find($"Panel{guide.PersonSystemName}", true).FirstOrDefault().Controls.Add(listbox);
                listbox.Dock = DockStyle.Fill;
                listbox.SelectedIndex = IndexDictionary[guide.PersonSystemName].ToInt32();
                listbox.SelectedValueChanged += Listbox_SelectedValueChanged;
            }
        }

        private void Listbox_SelectedValueChanged(object sender, EventArgs e)
        {
            IndexDictionary[(sender as ListBox).Name] = (sender as ListBox).SelectedIndex.ToString();
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Service.FriendshipGuides(openFileDialog.FileName);
            }

            BuildListBoxes();

            completedFriendshipGuideModelBindingSource.ResetBindings(false);

        }
    }
}
