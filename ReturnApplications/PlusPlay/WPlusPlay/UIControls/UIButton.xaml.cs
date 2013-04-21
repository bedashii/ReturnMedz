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
        bool PointerInRange
        {
            get { return _pointerInRange; }
            set
            {
                _pointerInRange = value;
                ButtonStatusChanged();
            }
        }
        #endregion Variables

        #region Construction
        public UIButton()
        {
            InitializeComponent();
        }

        public UIButton(ButtonType buttonType, string brushMouseEnterHexCode, string brushMouseLeaveHexCode, string brushMouseDownHexCode)
        {
            InitializeComponent();
            Initialize(buttonType, brushMouseEnterHexCode, brushMouseLeaveHexCode, brushMouseDownHexCode, null);
        }

        public UIButton(ButtonType buttonType, string brushMouseEnterHexCode, string brushMouseLeaveHexCode, string brushMouseDownHexCode, string brushMouseUpHexCode)
        {
            InitializeComponent();
            Initialize(buttonType, brushMouseEnterHexCode, brushMouseLeaveHexCode, brushMouseDownHexCode, brushMouseUpHexCode);
        }

        private void Initialize(ButtonType buttonType, string brushMouseEnterHexCode, string brushMouseLeaveHexCode, string brushMouseDownHexCode, string brushMouseUpHexCode)
        {
            BrushConverter bc = new BrushConverter();
            _brushMouseEnter = (Brush)bc.ConvertFromString(brushMouseEnterHexCode);
            _brushMouseLeave = (Brush)bc.ConvertFromString(brushMouseLeaveHexCode);
            _brushMouseDown = (Brush)bc.ConvertFromString(brushMouseDownHexCode);
            _brushMouseUp = brushMouseUpHexCode == null ? Brushes.Transparent : (Brush)bc.ConvertFromString(brushMouseUpHexCode);

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
            if (PointerInRange)
                GridControlFrame.Background = _brushMouseEnter;
            else
                GridControlFrame.Background = _brushMouseUp;
        }

        private void ImageIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            PointerInRange = true;
            GridControlFrame.Background = _brushMouseEnter;
        }

        private void ImageIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            PointerInRange = false;
            GridControlFrame.Background = _brushMouseLeave;
        }
        #endregion Events

        #region Methods
        private void ButtonStatusChanged()
        {
            
        }
        #endregion Methods
    }
}
