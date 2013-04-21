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
    /// <summary>
    /// #FFU = For Future Use
    /// </summary>
    public partial class PlusPlayForm : MetroWindow
    {
        #region Variables
        PlusPlayLib.Bus.ModelB _selectedModel;
        PlusPlayLib.Bus.Gallery _selectedGallery;
        PlusPlayProcessor _processor;
        System.Timers.Timer _busybee;
        string _resourcePath = System.Configuration.ConfigurationManager.AppSettings.Get("ResourcesPath");

        const string _zipDialogFilter = "ZIP Archive (.zip)|*.zip";
        bool _SelectAllActive = false;
        bool SelectAllActive
        {
            get { return _SelectAllActive; }
            set
            {
                _SelectAllActive = value;
                SetAvailabilityControls_SelectAllMode();
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

            if (SelectAllActive == false)
                PlusPlayProcessor.CleanUpTempFiles();
        }

        private void SetButtonImages()
        {
            ButtonSelectAllImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\SelectAll.png"));
            ButtonSaveImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Save.png"));
            ButtonDiscardImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Discard.png"));
            ButtonPostedImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Posted.png"));
            ButtonNotPostedImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\NotPosted.png"));
            ButtonSelectAllImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\SelectAll.png"));
            ButtonSelectNoneImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\SelectNone.png"));
            ButtonDropboxImage.Source = new BitmapImage(new Uri(_resourcePath + @"\Icons\Dropbox.png"));
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
            SetAvailabilityButton_PostingFunctions(true);

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
                //SetAvailabilityButton_PostingFunctions(false); #FFU

            }
            catch (Exception) { }
        }

        private void ListBoxModelGallerySelection_MainListBox_SelectedValueChanged(PlusPlayLib.Bus.ModelB ModelB)
        {
            _selectedModel = ModelB;
        }

        private void PicturePanelMain_SelectedItemsChanged(int ItemsSelected)
        {
            //SetAvailabilityButton_PostingFunctions(ItemsSelected > 0); #FFU
        }
        #endregion ForeignEvents

        #region ButtonEvents
        private void ButtonImport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ButtonSelectAllGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Pressed);
            Thread.Sleep(100);
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = _zipDialogFilter;
            dialog.Multiselect = false;

            if ((bool)dialog.ShowDialog(this))
            {
                SelectAllActive = true;
                _processor.ExtractArchive(dialog.FileName);
                Dictionary<Keyword, string> modelGalleryName = WPlusPlay.PlusPlayTools.StringManipulator.ExtractModelGalleryName(dialog.SafeFileName);

                PicturePanelMain.SetGallery(@"TEMP\All");
                InfoDisplayControl.SetDisplay(true, modelGalleryName);
            }
        }

        private void ButtonImportImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSelectAllTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonSelectAllGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonImportImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSelectAllTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonSelectAllGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Dictionary<Keyword, string> modelGalleryName = InfoDisplayControl.GetGalleryInfo();
            _processor.ImportGallery(PicturePanelMain.GetSelectedItems(), modelGalleryName);

            InfoDisplayControl.SetDisplay(false, modelGalleryName);

            SelectAllActive = false;

            ListBoxModelGallerySelection.SetListBoxMain(_processor.GetModelList(true));
            ListBoxModelGallerySelection.SetListBoxSub(_processor.GetGalleryList(modelGalleryName[Keyword.Model]), modelGalleryName[Keyword.Gallery]);
        }

        private void ButtonSaveImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSaveTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonSaveGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonSaveImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSaveTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonSaveGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonDiscard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel the directory SelectAll", "Cancel SelectAll", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                SelectAllActive = false;
                InfoDisplayControl.SetDisplay(false, null);
                PlusPlayProcessor.CleanUpTempFiles();
            }
        }

        private void ButtonDiscardImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonDiscardTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonDiscardGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonDiscardImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonDiscardTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonDiscardGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        

        private void ButtonSelect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as System.Windows.Controls.Image).Name)
            {
                case "ButtonSelectAllImage":
                    PicturePanelMain.SetSelection(true);
                    ButtonSelectAllGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Pressed);
                    break;
                case "ButtonSelectNoneImage":
                    ButtonSelectNoneGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Pressed);
                    PicturePanelMain.SetSelection(false);
                    break;
            }
        }

        private void ButtonSelectAllImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSelectAllTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonSelectAllGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonSelectAllImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSelectAllTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonSelectAllGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonSelectNoneImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSelectNoneTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonSelectNoneGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonSelectNoneImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSelectNoneTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonSelectNoneGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonUpdateGalleryStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _processor.SetGalleryStatus(_selectedGallery, (sender as System.Windows.Controls.Image).Name == "ButtonPostedImage");
            _processor.RefreshGallery(_selectedGallery);
            PicturePanelMain.SetGalleryStatus((sender as System.Windows.Controls.Image).Name == "ButtonPostedImage");
        }

        private void ButtonPostedImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonPostedTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonPostedGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonPostedImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonPostedTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonPostedGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonNotPostedImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNotPostedTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonNotPostedGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonNotPostedImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNotPostedTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonNotPostedGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonCleanUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlusPlayProcessor.CleanUpTempFiles())
                MessageBox.Show("Cleanup Successful", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Error during cleanup", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ButtonCleanUpImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonCleanUpTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonCleanUpGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Enter);
        }

        private void ButtonCleanUpImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonCleanUpTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonCleanUpGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }

        private void ButtonDropbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string dLinks = _processor.GetDLinks(_selectedGallery);
            System.Windows.Clipboard.SetText(dLinks);
        }

        private void ButtonDropboxImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonDropboxTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(true));
            ButtonDropboxGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Dropbox);
        }

        private void ButtonDropboxImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonDropboxTextBlock.BeginAnimation(TextBlock.HeightProperty, _processor.GetMouseEnterStoryboard(false));
            ButtonDropboxGrid.Background = _processor.GetButtonColour(PlusPlayProcessor.MouseStatus.Leave);
        }
        #endregion ButtonEvents

        #region FormEvents
        private void MetroWindow_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SelectAllActive && MessageBox.Show("An SelectAlling process is currently active, resume SelectAll later?", "Resume SelectAll Later?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                System.Configuration.ConfigurationManager.AppSettings.Set("ResumeSelectAll", "true");
            else if (SelectAllActive && MessageBox.Show("An SelectAlling process is currently active, resume SelectAll later?", "Resume SelectAll Later?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                System.Configuration.ConfigurationManager.AppSettings.Set("ResumeSelectAll", "false");
            else if (SelectAllActive && MessageBox.Show("An SelectAlling process is currently active, resume SelectAll later?", "Resume SelectAll Later?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        #endregion FormEvents

        #region Control Availability Methods
        private void SetAvailabilityButton_AllFunctions(bool available)
        {
            //ButtonSave.IsEnabled =
            //ButtonDiscard.IsEnabled =
            //ButtonPosted.IsEnabled =
            //ButtonNotPosted.IsEnabled =
            //ButtonSelectAll.IsEnabled =
            //ButtonSelectNone.IsEnabled = available;
        }

        private void SetAvailabilityButton_SelectFunctions(bool available)
        {
            //ButtonSelectAll.IsEnabled =
            //ButtonSelectNone.IsEnabled = available;
        }

        private void SetAvailabilityButton_SelectAllFunctions(bool available)
        {
            //ButtonSave.IsEnabled =
            //ButtonDiscard.IsEnabled = available;
        }

        private void SetAvailabilityButton_PostingFunctions(bool available)
        {
            //ButtonPosted.IsEnabled =
            //ButtonNotPosted.IsEnabled = available;
        }

        private void SetAvailabilityControls_SelectAllMode()
        {
            //ButtonSelectAll.IsEnabled =
            //ButtonPosted.IsEnabled =
            //ButtonNotPosted.IsEnabled = SelectAllActive ? false : true;

            //ButtonSave.IsEnabled =
            //ButtonDiscard.IsEnabled =
            //ButtonSelectAll.IsEnabled =
            //ButtonSelectNone.IsEnabled = SelectAllActive;

            //ListBoxModelGallerySelection.ImportMode(SelectAllActive);
        }

        #endregion Button Availability Methods

        #region OtherThreads
        void _busybee_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (SelectAllActive == false)
                PlusPlayProcessor.CleanUpTempFiles();
        }
        #endregion OtherThreads

        

        

       

      

        
    }
}
