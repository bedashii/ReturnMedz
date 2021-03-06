﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PlusPlayUserControls;
using PlusPlayUserControls.WFControls;

namespace PlusPlayWF
{
    public partial class MainForm : Form
    {
        Processors.MainProcessor _processor;

        private void ShowModelControl(PlusPlayDBGenLib.Business.Models model)
        {
            if (!PanelControls.Controls.Contains(new ModelViewerControl()))
            {
                var control = new ModelViewerControl(model);
                PanelControls.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _processor = new Processors.MainProcessor();
            _processor.LoadModels();
            BindingSourceModelsList.DataSource = _processor.ModelsList;
        }

        private void TSMI_AddModel_Click(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                ofd.SelectedPath = _processor.InitialDirectory;
                ofd.Description = "Select a Model";
                ofd.ShowNewFolderButton = false;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PlusPlayDBGenLib.Business.Models model = _processor.AddModel(ofd.SelectedPath);
                    BindingSourceModelsList.ResetBindings(false);
                    ShowModelControl(model);
                    PanelSplit.Panel1Collapsed = true;
                }
            }
        }


    }
}
