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

namespace PlusPlayUserControls
{
    /// <summary>
    /// Interaction logic for ucPictureBox.xaml
    /// </summary>
    public partial class ucPictureBox : UserControl
    {
        private const double _marginZero = 0d;
        private const double _marginShow = 42d;

        private bool _showTitle = false;
        public bool ShowTitle
        {
            get { return _showTitle; }
            set
            {
                if (value == true)
                    this.GridImage.Margin = new Thickness(_marginZero, _marginZero, _marginZero, _marginShow);
                else
                    this.GridImage.Margin = new Thickness(_marginZero);

                _showTitle = value;
            }
        }

        public ucPictureBox()
        {
            InitializeComponent();
        }

        public bool SetImage()
        {
            try
            {
                //ImagePath.

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
