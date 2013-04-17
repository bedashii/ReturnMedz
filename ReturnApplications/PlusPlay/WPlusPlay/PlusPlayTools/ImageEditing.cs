using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WPlusPlay.PlusPlayTools
{
    public class ImageEditing
    {
        public static BitmapImage GenerateImage_Uri(string filePath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(filePath);
                bitmapImage.DecodePixelWidth = 140;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            catch (Exception) { }

            return bitmapImage;
        }

        public static BitmapImage GenerateImage_MemoryStream(string filepath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            //Stream stream = new MemoryStream();
            try
            {
                using (Stream stream = new MemoryStream())
                {

                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(filepath);
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    bitmap.Dispose();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                }

            }
            catch (Exception) { }

            return bitmapImage;
        }

        public static BitmapImage GenerateImage_FileStream(string filepath)
        {
            BitmapImage bitmapImage = new BitmapImage();

            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = fs;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                }
            }
            catch (IOException ioex)
            {
                throw new ApplicationException(ioex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return bitmapImage;
        }
    }
}
