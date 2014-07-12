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

namespace WPlusPlay.UIControls
{
    /// <summary>
    /// Interaction logic for UINotificationDisplay.xaml
    /// </summary>
    public partial class UINotificationDisplay : UserControl
    {
        public UINotificationDisplay()
        {
            InitializeComponent();
        }

        public UINotificationDisplay(string imagePath, string heading, string message)
        {
            InitializeComponent();

            ImageSource.Source = PlusPlayTools.ImageEditing.GenerateImage_FileStream(imagePath);
            TextBlockHeading.Text = heading;
            TextBlockMessage.Text = message;
        }

        internal void SetImage(string imagePath)
        {
            ImageSource.Source = PlusPlayTools.ImageEditing.GenerateImage_FileStream(imagePath);
        }

        internal void SetHeading(string heading)
        {
            TextBlockHeading.Text = heading;
        }

        internal void SetMessage(string message)
        {
            TextBlockMessage.Text = message;
        }
    }
}
