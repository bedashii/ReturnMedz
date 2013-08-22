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
    public partial class ModelViewerControl : UserControl
    {
        private enum ChangeMode { ReadOnly, ReadWrite };
        PlusPlayProcessors.ModelViewerProcessor _processor;

        public ModelViewerControl()
        {
            InitializeComponent();
            TextBoxChangeMode(ChangeMode.ReadOnly);
        }

        public ModelViewerControl(PlusPlayDBGenLib.Business.Models model)
        {
            InitializeComponent();
            _processor = new PlusPlayProcessors.ModelViewerProcessor(model);
            TextBoxChangeMode(ChangeMode.ReadOnly);

            BindingSourceModel.DataSource = _processor.CurrentModel;
            BindingSourceModel.ResetBindings(false);

            BindingSourceModelGalleriesList.DataSource = _processor.ModelGalleries;
            BindingSourceModelGalleriesList.ResetBindings(false);
        }

        void TextBoxChangeMode(ChangeMode mode)
        {
            switch (mode)
            {
                case ChangeMode.ReadOnly:
                    TextBoxModelName.RightToLeft = RightToLeft.Yes;
                    TextBoxModelName.BorderStyle = BorderStyle.None;
                    TextBoxModelName.BackColor = SystemColors.Control;
                    break;
                case ChangeMode.ReadWrite:
                    TextBoxModelName.RightToLeft = RightToLeft.No;
                    TextBoxModelName.BorderStyle = BorderStyle.Fixed3D;
                    TextBoxModelName.BackColor = Color.White;
                    break;
            }
        }
    }
}
