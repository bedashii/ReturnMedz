using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace PlusPlay.WUIControls
{
    public delegate void WUIPictureBox_SelectionEditing(Key KeyHeld, object Obj);
    public partial class WUIPictureBox : UserControl
    {
        #region Variables
        public event WUIPictureBox_SelectionEditing OverrideSelectionEvent;
        string _filePath;
        string _title;
        bool _selectionMode;
        bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
        }

        RadialGradientBrush _brushNotTransparent;
        byte[] _colourStart;
        byte[] _colourStop;

        #endregion Variables;

        #region Construction
        public WUIPictureBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                _colourStart = new byte[3];
                _colourStop = new byte[3];

                _colourStart[0] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStartR"));
                _colourStart[1] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStartG"));
                _colourStart[2] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStartB"));

                _colourStop[0] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStopR"));
                _colourStop[1] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStopG"));
                _colourStop[2] = Convert.ToByte(System.Configuration.ConfigurationManager.AppSettings.Get("ColourStopB"));

                _brushNotTransparent = new RadialGradientBrush(
                    Color.FromRgb(_colourStart[0], _colourStart[1], _colourStart[2]),
                    Color.FromRgb(_colourStop[0], _colourStop[1], _colourStop[2]));
            }
            catch (Exception) { }
        }
        #endregion Construction

        #region Methods
        public void SetData(BitmapImage bitmapImage, FileInfo file, bool selectionMode)
        {
            _selectionMode = true;
            _filePath = file.FullName;

            SetTitle(file.Name);

            //if (bitmapImage.Width > bitmapImage.Height)
            //{
            //    double originalWidth = bitmapImage.Height;
            //    ImageDisplay.Height = originalWidth;
            //    ImageDisplay.Width = originalWidth + ImageDisplay.Height;

            //}

            ImageDisplay.Opacity = 0;
            ImageDisplay.Source = bitmapImage;
            ImageDisplay.BeginAnimation(Image.OpacityProperty, new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1))));
        }

        public void OverrideSelection(bool select)
        {
            if (select)
                GridPictureBox.Background = _brushNotTransparent;
            else
                GridPictureBox.Background = Brushes.Transparent;
        }

        public string GetTitle()
        {
            return _title;
        }

        private void SetTitle(string fileName)
        {
            TextBlockTitle.Text = _title = ExtractFileTitle(fileName);

            BrushConverter bc = new BrushConverter();
            ColorConverter cc = new ColorConverter();
            Brush solidNotPosted = (Brush)bc.ConvertFrom("#FFDE0000"), solidPosted = (Brush)bc.ConvertFrom("#FF0BC113");
            LinearGradientBrush gradientPosted = new LinearGradientBrush((Color)cc.ConvertFrom("#FF6EF300"), (Color)cc.ConvertFrom("#FF54B800"), 90);
            LinearGradientBrush gradientNotPosted = new LinearGradientBrush((Color)cc.ConvertFrom("#FFA80000"), Colors.Red, 90);

            EllipseTitle.Fill = fileName.Contains(']') ? gradientPosted : gradientNotPosted;
            //EllipseTitle.Stroke = fileName.Contains(']') ? gradientPosted : gradientNotPosted;
        }
        #endregion Methods

        #region StaticMethods

        private static bool ExtractPostedStatus(string fileName)
        {
            return fileName.Contains("]");
        }

        private static string ExtractFileTitle(string fileName)
        {
            return fileName.Substring(fileName.IndexOf(" [") + 2, 2);
        }

        #endregion StaticMethods

        #region Events
        /// <summary>
        /// Opens the selected file in the Windows Fax and Image Viewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageDisplay_LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _selected = _selected ? false : true;

                Process p = new Process();
                p.StartInfo.FileName = "rundll32.exe";
                p.StartInfo.Arguments = @"C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " + _filePath;
                p.Start();
            }
            else if (e.ClickCount == 1 && _selectionMode)
            {
                _selected = _selected ? false : true;

                if (_selected)
                    GridPictureBox.Background = _brushNotTransparent;
                else
                    GridPictureBox.Background = Brushes.Transparent;

                e.Handled = true;

                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    OverrideSelectionEvent(Key.LeftCtrl, _title);
                else if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                    OverrideSelectionEvent(Key.LeftShift, _title);
                else
                    OverrideSelectionEvent(Key.None, new object[] { _title, this });
            }
        }
        #endregion Events
    }
}
