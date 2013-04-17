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

namespace WPlusPlay.UIControls
{
    public struct UIPictureBoxDetailsStruct
    {
        public string FilePath;
        public string Title;
    }

    public delegate void UIPictureBox_SelectionEditing(Key KeyHeld, object Obj);
    public partial class UIPictureBox : UserControl
    {
        #region Variables
        public event UIPictureBox_SelectionEditing OverrideSelectionEvent;

        bool _selected = false;
        public bool Selected { get { return _selected; } }

        string _filePath;
        string _title;
        bool _selectionMode;

        RadialGradientBrush _brushNotTransparent;
        byte[] _colourStart;
        byte[] _colourStop;

        #endregion Variables;

        #region Construction
        public UIPictureBox()
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

                OverrideSelectionEvent += UIPictureBox_OverrideSelectionEvent;
            }
            catch (Exception) { }
        }

        public void UIPictureBox_OverrideSelectionEvent(Key KeyHeld, object Obj)
        {
            //ImageDisplay.Source = null;
        }
        #endregion Construction

        #region Methods
        public void SetData(BitmapImage bitmapImage, FileInfo file)
        {
            Random r = new Random();
            _selectionMode = true;
            _filePath = file.FullName;

            SetTitle(file.Name);

            ImageDisplay.Opacity = 0;
            ImageDisplay.Source = bitmapImage;
            ImageDisplay.BeginAnimation(Image.OpacityProperty, new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.17))));

            if (r.Next(0, 6) == 3)
            {
                this.MaxHeight = this.ActualHeight > this.ActualWidth ? this.MaxHeight += (this.MaxHeight / 2) : this.MaxHeight;
                this.MaxWidth = this.ActualWidth > this.ActualHeight ? this.MaxWidth += (this.MaxWidth / 2) : this.MaxWidth;
            }
        }

        public void SetData(BitmapImage bitmapImage, string filepath)
        {
            _selectionMode = true;
            _filePath = filepath;

            SetTitle("Please Work - I Shit You Not [00]");

            ImageDisplay.Opacity = 0;
            ImageDisplay.Source = bitmapImage;
            ImageDisplay.BeginAnimation(Image.OpacityProperty, new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.17))));
        }

        internal void SetData(BitmapImage bitmapImage, string filepath, string title)
        {
            _selectionMode = true;
            _filePath = filepath;

            SetTitleFromExtracted(title);

            ImageDisplay.Opacity = 0;
            ImageDisplay.Source = bitmapImage;
            ImageDisplay.BeginAnimation(Image.OpacityProperty, new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.17))));
        }

        public void OverrideSelection(bool select)
        {
            if (select)
                GridPictureBox.Background = _brushNotTransparent;
            else
                GridPictureBox.Background = Brushes.Transparent;

            _selected = select;
        }

        public string GetTitle()
        {
            return _title;
        }

        public UIPictureBoxDetailsStruct GetUIPictureBoxDetails()
        {
            UIPictureBoxDetailsStruct details = new UIPictureBoxDetailsStruct();
            details.FilePath = _filePath;
            details.Title = _title;

            return details;
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
        }

        private void SetTitleFromExtracted(string fileName)
        {
            TextBlockTitle.Text = _title = fileName;

            BrushConverter bc = new BrushConverter();
            ColorConverter cc = new ColorConverter();
            Brush solidNotPosted = (Brush)bc.ConvertFrom("#FFDE0000"), solidPosted = (Brush)bc.ConvertFrom("#FF0BC113");
            LinearGradientBrush gradientNotPosted = new LinearGradientBrush((Color)cc.ConvertFrom("#FFA80000"), Colors.Red, 90);

            EllipseTitle.Fill = gradientNotPosted;
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
                _selected = true;

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
