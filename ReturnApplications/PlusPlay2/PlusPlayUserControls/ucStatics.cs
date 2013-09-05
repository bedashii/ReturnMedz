using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlusPlayUserControls
{
    public class ucStatics
    {
        public static System.Windows.Forms.OpenFileDialog GetImageOpenFileDialog(string initialDirectory = null, string dialogTitle = null)
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (initialDirectory != null)
                ofd.InitialDirectory = initialDirectory;

            if (dialogTitle != null)
                ofd.Title = dialogTitle;

            return ofd;
        }

        //public static System.Windows.Media.Imaging.BitmapImage (string imageDirectory = null)
        //{
            
        //}
    }
}
