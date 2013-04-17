using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace WPlusPlay
{
    public partial class PlusPlayForm : MetroWindow
    {
        #region Variables
        PlusPlayLib.Bus.ModelB _selectedModel;
        PlusPlayLib.Bus.Gallery _selectedGallery;
        PlusPlayProcessor _processor;
        System.Timers.Timer _busybee;
        string _resourcePath = System.Configuration.ConfigurationManager.AppSettings.Get("ResourcesPath");

        const string _zipDialogFilter = "ZIP Archive (.zip)|*.zip";
        bool _importActive = false;
        bool ImportActive
        {
            get { return _importActive; }
            set
            {
                _importActive = value;
                SetAvailabilityControls_ImportMode();
            }
        }
        #endregion Variables

        #region Construction
        public PlusPlayForm()
        {
            InitializeComponent();
            Initialize();

            if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("DevMode")))
                InitializeDevMode();
        }

        private void InitializeDevMode()
        {
            ButtonCleanUp.Visibility = System.Windows.Visibility.Visible;
            ButtonCleanUpImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\CleanUp.png"));
        }

        private void Initialize()
        {
            _processor = new PlusPlayProcessor();

            _busybee = new System.Timers.Timer(10000);
            _busybee.Elapsed += _busybee_Elapsed;
            _busybee.Start();

            ListBoxModelGallerySelection.SetListBoxMain(_processor.GetModelList(true));
            SetButtonImages();
            SetAvailabilityButton_AllFunctions(false);

            if (ImportActive == false)
                PlusPlayProcessor.CleanUpTempFiles();
        }

        private void SetButtonImages()
        {
            ButtonImportImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Import.png"));
            ButtonSaveImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Save.png"));
            ButtonDiscardImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Discard.png"));
            ButtonPostedImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Posted.png"));
            ButtonNotPostedImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\NotPosted.png"));
            ButtonSelectAllImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\SelectAll.png"));
            ButtonSelectNoneImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\SelectNone.png"));
        }
        #endregion Construction

        #region ForeignEvents
        public PlusPlayLib.List.ModelListB ListBoxModelGallerySelection_ListBoxMain_Set()
        {
            SetAvailabilityButton_PostingFunctions(false);

            if (_processor.ModelCount > 0)
            {
                SetAvailabilityButton_SelectFunctions(false);
                return _processor.GetModelList(false);
            }
            else
                return null;
        }

        public PlusPlayLib.List.GalleryListB ListBoxModelGallerySelection_ListBoxSub_Set(PlusPlayLib.Bus.ModelB Model)
        {
            PlusPlayLib.List.GalleryListB galleryList = _processor.GetGalleryList(Model);
            SetAvailabilityButton_PostingFunctions(false);

            if (galleryList.Count > 0)
                SetAvailabilityButton_SelectFunctions(true);

            return galleryList;
        }

        private void ListBoxModelGallerySelection_SubListBox_SelectedValueChanged(PlusPlayLib.Bus.Gallery Gallery)
        {
            try
            {
                _selectedGallery = Gallery;

                PicturePanelMain.SetGallery(Gallery, false);
                InfoDisplayControl.SetDisplay(_selectedModel.ModelName, _selectedGallery.GalleryName);
                SetAvailabilityButton_PostingFunctions(false);
            }
            catch (Exception) { }
        }

        private void ListBoxModelGallerySelection_MainListBox_SelectedValueChanged(PlusPlayLib.Bus.ModelB ModelB)
        {
            _selectedModel = ModelB;
        }

        private void PicturePanelMain_SelectedItemsChanged(int ItemsSelected)
        {
            SetAvailabilityButton_PostingFunctions(ItemsSelected > 0);
        }
        #endregion ForeignEvents

        #region ButtonEvents
        private void ButtonImport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = _zipDialogFilter;
            dialog.Multiselect = false;

            if ((bool)dialog.ShowDialog(this))
            {
                ImportActive = true;
                _processor.ExtractArchive(dialog.FileName);
                Dictionary<Keyword, string> modelGalleryName = WPlusPlay.PlusPlayTools.StringManipulator.ExtractModelGalleryName(dialog.SafeFileName);

                PicturePanelMain.SetGallery(@"TEMP\All");
                InfoDisplayControl.SetDisplay(true, modelGalleryName);
            }
        }

        private void ButtonSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Dictionary<Keyword, string> modelGalleryName = InfoDisplayControl.GetGalleryInfo();
            _processor.ImportGallery(PicturePanelMain.GetSelectedItems(), modelGalleryName);

            InfoDisplayControl.SetDisplay(false, modelGalleryName);

            ImportActive = false;

            ListBoxModelGallerySelection.SetListBoxMain(_processor.GetModelList(true));
            ListBoxModelGallerySelection.SetListBoxSub(_processor.GetGalleryList(modelGalleryName[Keyword.Model]), modelGalleryName[Keyword.Gallery]);
        }

        private void ButtonDiscard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel the directory import", "Cancel Import", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ImportActive = false;
                InfoDisplayControl.SetDisplay(false, null);
                PlusPlayProcessor.CleanUpTempFiles();
            }
        }

        private void ButtonSelect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as System.Windows.Controls.Image).Name)
            {
                case "ButtonSelectAllImage":
                    PicturePanelMain.SetSelection(true);
                    break;
                case "ButtonSelectNoneImage":
                    PicturePanelMain.SetSelection(false);
                    break;
            }
        }

        private void ButtonUpdateGalleryStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as System.Windows.Controls.Image).Name)
            {
                case "ButtonPostedImage":
                    _processor.SetGalleryStatus(_selectedGallery, true);
                    break;
                case "ButtonNotPostedImage":
                    _processor.SetGalleryStatus(_selectedGallery, false);
                    break;
            }
        }

        private void ButtonCleanUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlusPlayProcessor.CleanUpTempFiles())
                MessageBox.Show("Cleanup Successful", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Error during cleanup", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion ButtonEvents

        #region FormEvents
        private void MetroWindow_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ImportActive && MessageBox.Show("An importing process is currently active, resume import later?", "Resume Import Later?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                System.Configuration.ConfigurationManager.AppSettings.Set("ResumeImport", "true");
            else if (ImportActive && MessageBox.Show("An importing process is currently active, resume import later?", "Resume Import Later?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                System.Configuration.ConfigurationManager.AppSettings.Set("ResumeImport", "false");
            else if (ImportActive && MessageBox.Show("An importing process is currently active, resume import later?", "Resume Import Later?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        #endregion FormEvents

        #region Control Availability Methods
        private void SetAvailabilityButton_AllFunctions(bool available)
        {
            ButtonSave.IsEnabled =
            ButtonDiscard.IsEnabled =
            ButtonPosted.IsEnabled =
            ButtonNotPosted.IsEnabled =
            ButtonSelectAll.IsEnabled =
            ButtonSelectNone.IsEnabled = available;
        }

        private void SetAvailabilityButton_SelectFunctions(bool available)
        {
            ButtonSelectAll.IsEnabled =
            ButtonSelectNone.IsEnabled = available;
        }

        private void SetAvailabilityButton_ImportFunctions(bool available)
        {
            ButtonSave.IsEnabled =
            ButtonDiscard.IsEnabled = available;
        }

        private void SetAvailabilityButton_PostingFunctions(bool available)
        {
            ButtonPosted.IsEnabled =
            ButtonNotPosted.IsEnabled = available;
        }

        private void SetAvailabilityControls_ImportMode()
        {
            ButtonImport.IsEnabled =
            ButtonPosted.IsEnabled =
            ButtonNotPosted.IsEnabled = ImportActive ? false : true;

            ButtonSave.IsEnabled =
            ButtonDiscard.IsEnabled =
            ButtonSelectAll.IsEnabled =
            ButtonSelectNone.IsEnabled = ImportActive;

            ListBoxModelGallerySelection.ImportMode(ImportActive);
        }

        #endregion Button Availability Methods

        #region OtherThreads
        void _busybee_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ImportActive == false)
                PlusPlayProcessor.CleanUpTempFiles();
        }
        #endregion OtherThreads
    }
}
