using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlusPlayUserControls.WFControls
{
    public partial class GallleryEditorControl : UserControl
    {
        public GallleryEditorControl()
        {
            InitializeComponent();
        }

        public GallleryEditorControl(PlusPlayDBGenLib.Business.Models model, bool newGallery)
        {
            InitializeComponent();

            if (newGallery)
            {
                using (var ofd = new FolderBrowserDialog())
                {
                    
                    //ofd.Description = "Select a Model";
                    //ofd.ShowNewFolderButton = false;

                    //if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //{
                    //    PlusPlayDBGenLib.Business.Models model = _processor.AddModel(ofd.SelectedPath);
                    //    BindingSourceModelsList.ResetBindings(false);
                    //    ShowModelControl(model);
                    //    PanelSplit.Panel1Collapsed = true;
                    //}
                }
            }
        }
    }
}
