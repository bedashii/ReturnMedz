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
    public partial class WUIPicturePanel : UserControl
    {
        #region Variables
        List<FileInfo> _pictures;
        WUIPictureBox[] _boxes;
        BackgroundWorker _backgroundWorker;
        string _previousSelectionString;
        #endregion Variables

        #region Construction
        public WUIPicturePanel()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;

            _pictures = new List<FileInfo>();
            _boxes = new WUIPictureBox[0];
        }
        #endregion Construction

        #region Methods
        public void SetGallery(PlusPlayLib.Bus.Gallery gallery, bool selectionMode)
        {
            try
            {
                Initialize();
                WrapPanelMain.Children.Clear();

                for (int i = 0; i < gallery.Files.Count; i++)
                {
                    WUIControls.WUIPictureBox pb = new WUIPictureBox();
                    pb.OverrideSelectionEvent += pb_OverrideSelectionEvent;
                    _pictures.Add(gallery.Files[i]);

                    Array.Resize(ref _boxes, _boxes.Length + 1);
                    _boxes[i] = pb;

                    WrapPanelMain.Children.Add(pb);
                }

                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception) { }
        }

        void pb_OverrideSelectionEvent(Key KeyHeld, object Obj)
        {
            switch (KeyHeld)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    _previousSelectionString = (string)Obj;
                    break;
                case Key.LeftShift:
                case Key.RightShift:
                    foreach (WUIControls.WUIPictureBox wuiPictureBox in WrapPanelMain.Children)
                        if (int32(_previousSelectionString) < int32(Obj))
                        {
                            if (int32(wuiPictureBox.GetTitle()) >= int32(_previousSelectionString) && int32(wuiPictureBox.GetTitle()) <= int32(Obj))
                                wuiPictureBox.OverrideSelection(true);
                            else
                                wuiPictureBox.OverrideSelection(false);

                        }
                        else
                        {
                            if (int32(wuiPictureBox.GetTitle()) <= int32(_previousSelectionString) && int32(wuiPictureBox.GetTitle()) >= int32(Obj))
                                wuiPictureBox.OverrideSelection(true);
                            else
                                wuiPictureBox.OverrideSelection(false);
                        }
                    break;
                default:
                    object[] objA = (object[])Obj;

                    _previousSelectionString = (string)objA[0];
                    foreach (WUIControls.WUIPictureBox wuiPictureBox in WrapPanelMain.Children)
                        if (wuiPictureBox != (WUIPictureBox)objA[1])
                            wuiPictureBox.OverrideSelection(false);
                    break;
            }


        }
        #endregion Methods

        #region Events
        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Action<BitmapImage, int> workMethod = (bitmapImage, i) => _boxes[i].SetData(bitmapImage, _pictures[i], false);

            for (int i = 0; i < _pictures.Count; i++)
                try
                {
                    BitmapImage generated = ImageEditing.GenerateImage(_pictures[i].FullName);
                    generated.Freeze();

                    if (!_boxes[i].Dispatcher.CheckAccess())
                        _boxes[i].Dispatcher.Invoke(DispatcherPriority.Normal, workMethod, generated, i);
                    else
                        workMethod(generated, i);

                }
                catch (Exception) { }
        }
        #endregion Events

        #region StaticMethods
        private static int int32(object intObject)
        {
            return Convert.ToInt32(intObject);
        }
        #endregion StaticMethods
    }
}
