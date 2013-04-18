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

namespace PlusPlay.WUIControls
{
    /// <summary>
    /// Interaction logic for WUIButton.xaml
    /// </summary>
    public delegate void WUIButton_ButtonPressed();
    public partial class WUIButton : UserControl
    {
        public event WUIButton_ButtonPressed ButtonPressed;

        public WUIButton()
        {
            InitializeComponent();
        }

        public void SetButtonImage(string filePath)
        {
            BitmapImage bitmap = new BitmapImage();

            try
            {

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath);
                bitmap.DecodePixelWidth = 140;
                bitmap.EndInit();
            }
            catch (Exception) { }

            ButtonIcon.Source = bitmap;
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ButtonPressed();
        }

        private void ButtonIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
                
        }
    }
}
