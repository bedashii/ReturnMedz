using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PlusPlay.UIControls
{
    public partial class UIPicturePanel : UserControl
    {
        public UIPicturePanel()
        {
            InitializeComponent();
        }

        public void SetGallery(PlusPlayLib.Bus.Gallery gallery)
        {
            FlowLayoutPanelMain.Controls.Clear();

            foreach (FileInfo picture in gallery.Files)
            {
                UIPictureBox pb = new UIPictureBox();
                pb.SetData(picture);
                FlowLayoutPanelMain.Controls.Add(pb);
            }
        }
    }
}
