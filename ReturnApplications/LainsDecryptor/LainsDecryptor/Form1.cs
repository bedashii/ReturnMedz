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

namespace LainsDecryptor
{
    public partial class MainForm : Form
    {

        DecryptingService service;
        CompletedFriendshipGuideModel selected = new CompletedFriendshipGuideModel();

        public MainForm()
        {
            InitializeComponent();
            service = new DecryptingService();
            completedFriendshipGuideModelBindingSource.DataSource = service.CompletedGuides;
            listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            selected = (CompletedFriendshipGuideModel)listBox1.SelectedItem;
            CreatePanels();
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                service.FriendshipGuides(openFileDialog.FileName);
            }

            completedFriendshipGuideModelBindingSource.ResetBindings(false);

        }

        private void CreatePanels()
        {
            PanelFlowGuides.Controls.Clear();

            if (selected != null && selected.Events != null)
            {
                selected.Events.ForEach(x =>
                {
                    var listbox = new ListBox();
                    listbox.Width = PanelFlowGuides.Width - 30;
                    listbox.Font = new Font("Consolas", listBox1.Font.Size);
                    listbox.Items.Add($"Level: {x.Level}");
                    listbox.Items.Add($"Day: {x.Day}");
                    listbox.Items.Add($"Time: {x.Time}");
                    listbox.Items.Add($"Location: {x.Location}");

                    x.Instructions.ForEach(y =>
                    {
                        listbox.Items.Add(y);
                    });

                    PanelFlowGuides.Controls.Add(listbox);
                });
            }
        }
    }
}
