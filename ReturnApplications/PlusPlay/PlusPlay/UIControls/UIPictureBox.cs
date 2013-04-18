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
    public partial class UIPictureBox : UserControl
    {
        bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
        }

        int _width = 100, _height = 100;
        byte[] _colourNotTransparentData;
        Color _colourNotTransparent;

        public UIPictureBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                _colourNotTransparentData = new byte[3];
                _colourNotTransparentData[0] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStartR"));
                _colourNotTransparentData[1] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStartG"));
                _colourNotTransparentData[2] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStartB"));

                _colourNotTransparent = Color.FromArgb(_colourNotTransparentData[0], _colourNotTransparentData[1], _colourNotTransparentData[2]);
            }
            catch (Exception) { }
        }

        public void SetData(FileInfo file)
        {
            LabelNameDisplay.Text = ExtractFileTitle(file.Name);
            PictureBoxMain.Image = CreateThumbnail(file, null, null);

            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri(file.FullName);
            //bitmap.DecodePixelWidth = 140;
            //bitmap.EndInit();

            //ImageDisplay.Source = bitmap;
        }

        public Bitmap CreateThumbnail(FileInfo file, int? iWidth, int? iHeight)
        {
            Bitmap image = new Bitmap(file.FullName);
            SetSize(image, iWidth, iHeight);

            Bitmap thumbnail = new Bitmap(_width, _height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(thumbnail))
                graphics.DrawImage(image, new Rectangle(0, 0, thumbnail.Width, thumbnail.Height));

            return thumbnail;
        }

        private void SetSize(Bitmap image, int? iWidth, int? iHeight)
        {
            decimal oWidth, oHeight;
            decimal dWidth = 100, dHeight = 100;

            oWidth = image.Width;
            oHeight = image.Height;

            if (oWidth > oHeight)
                dHeight = oHeight / oWidth * 100;
            else
                dWidth = oWidth / oHeight * 100;

            _width = Convert.ToInt32(Decimal.Round(dWidth, 0, MidpointRounding.AwayFromZero));
            _height = Convert.ToInt32(Decimal.Round(dHeight, 0, MidpointRounding.AwayFromZero));
        }

        #region MiniMethods
        private string ExtractFileTitle(string fileName)
        {
            return fileName.Substring(fileName.IndexOf(" [") + 2, 2);
        }

        private bool ExtractPostedStatus(string fileName)
        {
            return fileName.Contains("]");
        }
        #endregion MiniMethods

        private void Picture_Click(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _selected = _selected ? false : true;

                if (_selected)
                    PanelMain.BackColor= _colourNotTransparent;
                else
                    PanelMain.BackColor = Color.Transparent;
            }
        }

        private void PictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            Picture_Click(e);
        }

        private void UIPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Picture_Click(e);
        }
    }
}
