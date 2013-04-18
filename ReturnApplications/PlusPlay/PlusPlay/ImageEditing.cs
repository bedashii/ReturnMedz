using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace PlusPlay
{
    public class ImageEditing
    {
        public static BitmapImage GenerateImage(string filePath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {

                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(filePath);
                bitmapImage.DecodePixelWidth = 140;
                bitmapImage.EndInit();
            }
            catch (Exception) { }

            return bitmapImage;
        }
    }
}
