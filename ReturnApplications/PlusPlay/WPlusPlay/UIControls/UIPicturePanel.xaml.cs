﻿using System;
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
    public delegate void UIPicturePanel_SelectedItemsChanged(int ItemsSelected);
    public partial class UIPicturePanel : UserControl
    {
        #region Variables
        public event UIPicturePanel_SelectedItemsChanged SelectedItemsChanged;
        List<string> _pictures;
        UIPictureBox[] _boxes;
        BackgroundWorker _imageLoaderBackgroundWorker;
        BackgroundWorker _galleryStatusUpdaterBackgroudnWorker;
        string _previousSelectionString;
        #endregion Variables

        #region Construction
        public UIPicturePanel()
        {
            InitializeComponent();
            Initialize(false);
        }

        void Initialize(bool fromExtracted)
        {
            _imageLoaderBackgroundWorker = new BackgroundWorker();
            _galleryStatusUpdaterBackgroudnWorker = new BackgroundWorker();

            if (fromExtracted)
                _imageLoaderBackgroundWorker.DoWork += _backgroundWorkerExtracted_LoadGalleryFiles;
            else
                _imageLoaderBackgroundWorker.DoWork += _backgroundWorker_LoadGalleryFiles;

            _galleryStatusUpdaterBackgroudnWorker.DoWork += _galleryStatusUpdaterBackgroudnWorker_UpdateGalleryStatus;

            //_pictures = new List<FileInfo>();
            _pictures = new List<string>();
            _boxes = new UIPictureBox[0];
        }
        #endregion Construction

        #region Methods
        /// <summary>
        /// Sets the gallery for the UIPicture Panel. This method generates it's own UIPictureBox controls
        /// using a background worker. OVERLOAD: THIS OVERLOAD IS POST-PROCESSED FILES.
        /// </summary>
        /// <param name="Gallery"></param>
        /// <param name="SelectionMode"></param>
        public void SetGallery(PlusPlayLib.Bus.Gallery gallery, bool selectionMode)
        {
            try
            {
                Initialize(false);


                foreach (UIPictureBox children in WrapPanelMain.Children)
                    children.UIPictureBox_OverrideSelectionEvent(Key.None, children);

                WrapPanelMain.Children.Clear();



                for (int i = 0; i < gallery.Files.Count; i++)
                {
                    UIControls.UIPictureBox pb = new UIPictureBox();
                    pb.OverrideSelectionEvent += pb_OverrideSelectionEvent;
                    _pictures.Add(gallery.Files[i].FullName);

                    Array.Resize(ref _boxes, _boxes.Length + 1);
                    _boxes[i] = pb;

                    WrapPanelMain.Children.Add(pb);
                }

                _imageLoaderBackgroundWorker.RunWorkerAsync();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Sets the gallery for the UIPicture Panel. This method generates it's own UIPictureBox controls
        /// using a background worker. OVERLOAD: THIS OVERLOAD IS PRE-PROCESSED FILES.
        /// </summary>
        /// <param name="Gallery Location" type="System.IO.DirectoryInfo"></param>
        /// <param name="ModelGaleryName" type="string[]"></param>
        public void SetGallery(string galleryFilePath)
        {
            try
            {
                Initialize(true);
                DirectoryInfo galleryDirectory = new DirectoryInfo(galleryFilePath);

                WrapPanelMain.Children.Clear();

                FileInfo[] galleryFiles = galleryDirectory.GetFiles();

                for (int i = 0; i < galleryFiles.Length; i++)
                {
                    UIControls.UIPictureBox pb = new UIPictureBox();
                    pb.OverrideSelectionEvent += pb_OverrideSelectionEvent;
                    _pictures.Add(galleryFiles[i].FullName);

                    Array.Resize(ref _boxes, _boxes.Length + 1);
                    _boxes[i] = pb;

                    WrapPanelMain.Children.Add(pb);
                }

                _imageLoaderBackgroundWorker.RunWorkerAsync();
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
                    foreach (UIControls.UIPictureBox wuiPictureBox in WrapPanelMain.Children)
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
                    foreach (UIControls.UIPictureBox wuiPictureBox in WrapPanelMain.Children)
                        if (wuiPictureBox != (UIPictureBox)objA[1])
                            wuiPictureBox.OverrideSelection(false);
                    break;
            }

            SelectedItemsChanged(GetSelectedItems().Count());
        }

        internal void SetSelection(bool selectAll)
        {
            foreach (UIControls.UIPictureBox wuiPictureBox in WrapPanelMain.Children)
                wuiPictureBox.OverrideSelection(selectAll);

            SelectedItemsChanged(GetSelectedItems().Count());
        }

        internal List<UIPictureBoxDetailsStruct> GetSelectedItems()
        {
            List<UIPictureBoxDetailsStruct> returnList = new List<UIPictureBoxDetailsStruct>();

            foreach (UIPictureBox pb in this.WrapPanelMain.Children)
                if (pb.Selected)
                    returnList.Add(pb.GetUIPictureBoxDetails());

            return returnList;
        }

        internal void SetGalleryStatus(bool posted)
        {
            _galleryStatusUpdaterBackgroudnWorker.RunWorkerAsync(posted);
        }
        #endregion Methods

        #region Events
        void _backgroundWorker_LoadGalleryFiles(object sender, DoWorkEventArgs e)
        {
            Action<BitmapImage, int> workMethod = (bitmapImage, i) =>
                {
                    _boxes[i].SetData(bitmapImage, new FileInfo(_pictures[i]));
                };

            for (int i = 0; i < _pictures.Count; i++)
                try
                {
                    BitmapImage generated = PlusPlayTools.ImageEditing.GenerateImage_FileStream(_pictures[i]);
                    generated.Freeze();

                    if (!_boxes[i].Dispatcher.CheckAccess())
                        _boxes[i].Dispatcher.Invoke(DispatcherPriority.Normal, workMethod, generated, i);
                    else
                        workMethod(generated, i);

                }
                catch (Exception) { }
        }

        void _backgroundWorkerExtracted_LoadGalleryFiles(object sender, DoWorkEventArgs e)
        {
            Action<BitmapImage, int> workMethod = (bitmapImage, i) =>
                {
                    _boxes[i].SetData(bitmapImage, _pictures[i], (i + 1).ToString("00"));
                };

            for (int i = 0; i < _pictures.Count; i++)
                try
                {
                    BitmapImage generated = PlusPlayTools.ImageEditing.GenerateImage_FileStream(_pictures[i]);
                    generated.Freeze();

                    if (!_boxes[i].Dispatcher.CheckAccess())
                        _boxes[i].Dispatcher.Invoke(DispatcherPriority.Normal, workMethod, generated, i);
                    else
                        workMethod(generated, i);
                }
                catch (Exception) { }
        }

        void _galleryStatusUpdaterBackgroudnWorker_UpdateGalleryStatus(object sender, DoWorkEventArgs e)
        {
            Action<bool, int> workMethod = (markAsPosted, i) =>
                {
                    _boxes[i].UpdateStatus(markAsPosted);
                };
            
            bool posted = (bool) e.Argument;
            Thread.Sleep(2);
            
            for(int i = 0; i < _pictures.Count; i++)
                try
                {
                    if (!_boxes[i].Dispatcher.CheckAccess())
                        _boxes[i].Dispatcher.Invoke(DispatcherPriority.Normal, workMethod, posted, i);
                    else
                        workMethod(posted, i);
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
