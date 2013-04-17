using System;
using System.Collections.Generic;
using System.IO;
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

namespace PlusPlay.WUIControls
{
    /// <summary>
    /// Interaction logic for WUIControlBox.xaml
    /// </summary>
    /// 
    public enum WUIControlBoxCommand { Min, Max, Close };
    public delegate void WUIControlBox_ControlActivated(WUIControlBoxCommand Command);
    public partial class WUIControlBox : UserControl
    {
        public event WUIControlBox_ControlActivated ControlActivated;

        BrushConverter _bc;
        Brush _click;
        Brush _hover;
        Brush _leave;
        string _resourcesDirectory = System.Configuration.ConfigurationManager.AppSettings.Get("ResourcesPath");

        string _minIconPath
        {
            get
            {
                if (_resourcesDirectory == null)

                    return @"\Control_Min.png";
                else
                    return _resourcesDirectory + @"\Icons\Control_Min.png";
            }
        }
        string _maxIconPath
        {
            get
            {
                if (_resourcesDirectory == null)

                    return @"\Control_Max.png";
                else
                    return _resourcesDirectory + @"\Icons\Control_Max.png";
            }
        }
        string _closeIcon
        {
            get
            {
                if (_resourcesDirectory == null)

                    return @"\Control_Close.png";
                else
                    return _resourcesDirectory + @"\Icons\Control_Close.png";
            }
        }
        bool _keyDown = false;

        public WUIControlBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _bc = new BrushConverter();
            _click = (Brush)_bc.ConvertFrom("#007acc");
            _hover = (Brush)_bc.ConvertFrom("#fcfcfc");
            _leave = Brushes.Transparent;

            ControlMin.Source = ImageEditing.GenerateImage(_minIconPath);
            ControlMax.Source = ImageEditing.GenerateImage(_maxIconPath);
            ControlClose.Source = ImageEditing.GenerateImage(_closeIcon);
        }

        private void ControlMin_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid g = (Grid)(sender as Image).Parent;
            g.Background = _hover;
        }

        private void ControlMin_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid g = (Grid)(sender as Image).Parent;
            g.Background = _leave;
        }

        private void ControlMin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid g = (Grid)(sender as Image).Parent;
            g.Background = _click;

            _keyDown = true;
        }

        private void ControlMin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid g = (Grid)(sender as Image).Parent;
            g.Background = _hover;

            
            if (_keyDown)
                ControlActivated(IdentifyControl((Image)sender));

            _keyDown = false;
        }

        private static WUIControlBoxCommand IdentifyControl(Image image)
        {
            switch (image.Name)
            {
                case "ControlMin":
                    return WUIControlBoxCommand.Min;
                case "ControlMax":
                    return WUIControlBoxCommand.Max;
                default:
                    return WUIControlBoxCommand.Close;

            }
        }
    }
}
