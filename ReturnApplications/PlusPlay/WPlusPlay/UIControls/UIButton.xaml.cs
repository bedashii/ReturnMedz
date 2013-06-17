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
    public delegate void UIButton_Button_MouseDown(ButtonType ButtonType);
    public enum ButtonType { Import, Save, Discard, SelectAll, SelectNone, Posted, NotPosted, Dropbox };
    public partial class UIButton : UserControl
    {
        #region Variables
        public event UIButton_Button_MouseDown Button_MouseDown;
        Brush _brushMouseEnter;
        Brush _brushMouseLeave;
        Brush _brushMouseDown;
        Brush _brushMouseUp;
        ButtonType _buttonType;
        bool _pointerInRange;
        #endregion Variables

        #region Construction
        public UIButton()
        {
            InitializeComponent();
        }

        public UIButton(ButtonType buttonType, string iconFilePath, string buttonTitle, string buttonColour, string brushMouseEnterHexCode, string brushMouseLeaveHexCode, string brushMouseDownHexCode)
        {
            InitializeComponent();
            Initialize(buttonType, iconFilePath, buttonTitle, buttonColour, brushMouseEnterHexCode, brushMouseLeaveHexCode, brushMouseDownHexCode, null);
        }

        private void Initialize(ButtonType buttonType, string iconFilePath, string buttonTitle, string buttonColour, string brushMouseEnterHexCode, string brushMouseLeaveHexCode, string brushMouseDownHexCode, string brushMouseUpHexCode)
        {
            BrushConverter bc = new BrushConverter();
            _brushMouseEnter = (Brush)bc.ConvertFromString(brushMouseEnterHexCode);
            _brushMouseLeave = (Brush)bc.ConvertFromString(brushMouseLeaveHexCode);
            _brushMouseDown = (Brush)bc.ConvertFromString(brushMouseDownHexCode);
            _brushMouseUp = brushMouseUpHexCode == null ? Brushes.Transparent : (Brush)bc.ConvertFromString(brushMouseUpHexCode);

            TextBlockTitle.Background = (Brush)bc.ConvertFromString(buttonColour);
            TextBlockTitle.Text = buttonTitle;
            ImageIcon.Source = PlusPlayTools.ImageEditing.GenerateImage_FileStream(iconFilePath);

            _buttonType = buttonType;
        }
        #endregion Construction

        #region Events
        private void ImageIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GridControlFrame.Background = _brushMouseDown;
            Button_MouseDown(_buttonType);
        }

        private void ImageIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_pointerInRange)
                GridControlFrame.Background = _brushMouseEnter;
            else
                GridControlFrame.Background = _brushMouseUp;
        }

        private void ImageIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            _pointerInRange = true;
            TextBlockTitle.BeginAnimation(TextBlock.HeightProperty, GetMouseEnterAnimation(true));
            GridControlFrame.Background = _brushMouseEnter;
        }

        private void ImageIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlockTitle.BeginAnimation(TextBlock.HeightProperty, GetMouseEnterAnimation(false));
            _pointerInRange = false;
            GridControlFrame.Background = _brushMouseLeave;
        }
        #endregion Events

        #region Methods
        System.Windows.Media.Animation.DoubleAnimation GetMouseEnterAnimation(bool mouseEnter)
        {
            return mouseEnter ? new System.Windows.Media.Animation.DoubleAnimation(0, 20, TimeSpan.FromMilliseconds(120)) : new System.Windows.Media.Animation.DoubleAnimation(20, 0, TimeSpan.FromMilliseconds(120));
        }

        public void IsControlEnabled(bool isEnabled)
        {
            GridControlFrame.Visibility = isEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }
        #endregion Methods
    }
}
