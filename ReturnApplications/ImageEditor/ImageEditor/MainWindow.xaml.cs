using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string SelectedFile = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLoadImage_Click(object sender, RoutedEventArgs e)
        {

            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK && ofd.CheckFileExists == true)
            {
                SelectedFile = ofd.FileName;
                BitmapImage bi = new BitmapImage(new Uri(SelectedFile));
                ImageMain.Source = bi;
            }
        }

        private void ButtonCrop_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.UpArrow;
        }
    }
}
