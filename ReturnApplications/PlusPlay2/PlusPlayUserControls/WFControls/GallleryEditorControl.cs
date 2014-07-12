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
        PlusPlayProcessors.GalleryEditorProcessor _processor;

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
                    ofd.SelectedPath = model.ModelDirectory;
                    ofd.Description = "Select a Gallery";
                    ofd.ShowNewFolderButton = false;

                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        PlusPlayDBGenLib.Business.Galleries Gallery = new PlusPlayDBGenLib.Business.Galleries();
                        BindingSourceGalleries.ResetBindings(false);
                    }
                }
            }
        }

        private void GallleryEditorControl_Load(object sender, EventArgs e)
        {
            _processor = new PlusPlayProcessors.GalleryEditorProcessor();
            
        }
    }
}
