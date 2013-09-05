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

namespace PlusPlayUserControls.ucControls
{
    /// <summary>
    /// Interaction logic for ucPictureBox.xaml
    /// </summary>
    public partial class ucPictureBox : UserControl
    {
        private bool _selectionMode = false;
        public bool SelectionMode
        {
            get { return _selectionMode; }
            set { _selectionMode = value; }
        }

        private bool _selected = false;
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public ucPictureBox()
        {
            InitializeComponent();
        }

        public void InitializeControl()
        {
            this.Background = Brushes.Transparent;
            this.GridOuter.Background = Brushes.Transparent;
        }

        public void SetImage(string filepath)
        {
            BitmapImage image = new BitmapImage(new Uri(filepath));
            this.ImageMain.Source = image;
        }

        public void SetImage(PlusPlayDBGenLib.Business.Photos photo)
        {
            BitmapImage image = new BitmapImage(new Uri(photo.PhotoFile));
            this.ImageMain.Source = image;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControl();
        }

        private void GridOuter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SelectionMode)
            {
                this.Background = this.Background == Brushes.Transparent ? (Brush)ColorConverter.ConvertFromString("#FF4B8BF8") : Brushes.Transparent;
                this.Selected = this.Selected == true ? false : true;
            }
        }
    }
}
