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
        Dictionary<UIControls.ButtonType, UIControls.UIButton> _uiButtons;

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

        }

        private void Initialize()
        {
            _processor = new PlusPlayProcessor();
            _uiButtons = new Dictionary<UIControls.ButtonType, UIControls.UIButton>();

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
            string defaultButton = System.Configuration.ConfigurationManager.AppSettings.Get("ButtonColourDefault"),
                   mouseEnter = System.Configuration.ConfigurationManager.AppSettings.Get("ColourMouseEnter"),
                   mosueLeave = System.Configuration.ConfigurationManager.AppSettings.Get("ColourMouseLeave"),
                   mouseDown = System.Configuration.ConfigurationManager.AppSettings.Get("ColourMouseDown"); ;

            _uiButtons.Add(UIControls.ButtonType.Dropbox, new UIControls.UIButton(UIControls.ButtonType.Dropbox, _resourcePath + @"\Icons\Dropbox.png", "Dropbox", System.Configuration.ConfigurationManager.AppSettings.Get("ButtonColourDropbox"), mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.SelectNone, new UIControls.UIButton(UIControls.ButtonType.SelectNone, _resourcePath + @"\Icons\SelectNone.png", "Select None", defaultButton, mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.SelectAll, new UIControls.UIButton(UIControls.ButtonType.SelectAll, _resourcePath + @"\Icons\SelectAll.png", "Select All", defaultButton, mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.NotPosted, new UIControls.UIButton(UIControls.ButtonType.NotPosted, _resourcePath + @"\Icons\NotPosted.png", "Not Posted", defaultButton, mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.Posted, new UIControls.UIButton(UIControls.ButtonType.Posted, _resourcePath + @"\Icons\Posted.png", "Posted", defaultButton, mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.Discard, new UIControls.UIButton(UIControls.ButtonType.Discard, _resourcePath + @"\Icons\Discard.png", "Discard", defaultButton, mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.Save, new UIControls.UIButton(UIControls.ButtonType.Save, _resourcePath + @"\Icons\Save.png", "Save", defaultButton, mouseEnter, mosueLeave, mouseDown));
            _uiButtons.Add(UIControls.ButtonType.Import, new UIControls.UIButton(UIControls.ButtonType.Import, _resourcePath + @"\Icons\Import.png", "Import", defaultButton, mouseEnter, mosueLeave, mouseDown));

            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.Dropbox]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.SelectNone]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.SelectAll]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.NotPosted]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.Posted]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.Discard]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.Save]);
            WrapPanelButtonContainer.Children.Add(_uiButtons[UIControls.ButtonType.Import]);



            foreach (UIControls.UIButton button in WrapPanelButtonContainer.Children)
                button.Button_MouseDown += button_Button_MouseDown;
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
            PlusPlayLib.List.GalleryListB galleryList = _processor.GetGalleryList(Model.ModelName);
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

        // The only reason this doesn't directly do the switch is to keep the uniformity of foreign events
        void button_Button_MouseDown(UIControls.ButtonType ButtonType)
        {
            ButtonEvent_MouseDown(ButtonType);
        }
        #endregion ForeignEvents

        #region ButtonEvents

        private void ButtonEvent_MouseDown(UIControls.ButtonType buttonType)
        {
            switch (buttonType)
            {
                case UIControls.ButtonType.Import:
                    ButtonImport_MouseDown();
                    break;
                case UIControls.ButtonType.Save:
                    ButtonSave_MouseDown();
                    break;
                case UIControls.ButtonType.Discard:
                    ButtonDiscard_MouseDown();
                    break;
                case UIControls.ButtonType.SelectAll:
                case UIControls.ButtonType.SelectNone:
                    ButtonSelect_MouseDown(buttonType);
                    break;
                case UIControls.ButtonType.Posted:
                case UIControls.ButtonType.NotPosted:
                    ButtonUpdateGalleryStatus_MouseDown(buttonType);
                    break;
                case UIControls.ButtonType.Dropbox:
                    ButtonDropbox_MouseDown();
                    break;
            }
        }
        private void ButtonImport_MouseDown()
        {
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

        private void ButtonSave_MouseDown()
        {
            Dictionary<Keyword, string> modelGalleryName = InfoDisplayControl.GetGalleryInfo();
            _processor.ImportGallery(PicturePanelMain.GetSelectedItems(), modelGalleryName);

            InfoDisplayControl.SetDisplay(false, modelGalleryName);

            SelectAllActive = false;

            ListBoxModelGallerySelection.SetListBoxMain(_processor.GetModelList(true));
            ListBoxModelGallerySelection.SetListBoxSub(_processor.GetGalleryList(modelGalleryName[Keyword.Model]), modelGalleryName[Keyword.Gallery]);
        }

        private void ButtonDiscard_MouseDown()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel the directory SelectAll", "Cancel SelectAll", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                SelectAllActive = false;
                InfoDisplayControl.SetDisplay(false, null);
                PlusPlayProcessor.CleanUpTempFiles();
            }
        }

        private void ButtonSelect_MouseDown(UIControls.ButtonType buttonType)
        {
            switch (buttonType)
            {
                case UIControls.ButtonType.SelectAll:
                    PicturePanelMain.SetSelection(true);
                    break;
                case UIControls.ButtonType.SelectNone:
                    PicturePanelMain.SetSelection(false);
                    break;
            }
        }

        private void ButtonUpdateGalleryStatus_MouseDown(UIControls.ButtonType buttonType)
        {
            _processor.SetGalleryStatus(_selectedGallery, buttonType == UIControls.ButtonType.Posted);
            _processor.RefreshGallery(_selectedGallery);
            PicturePanelMain.SetGalleryStatus(buttonType == UIControls.ButtonType.Posted);
        }

        private void ButtonDropbox_MouseDown()
        {
            string dLinks = _processor.GetDLinks(_selectedGallery);
            System.Windows.Clipboard.SetText(dLinks);

            uINotificationDisplay.SetImage(_resourcePath + @"\Icons\DropboxNotification.png");
            uINotificationDisplay.SetHeading("Public Links Copied");
            uINotificationDisplay.SetMessage(_selectedGallery.Files.Count().ToString("00") + " Public Dropbox image links copied to clipboard");
            Storyboard sb = (Storyboard)this.Resources["UINotificationDisplayAnimation"];
            sb.Begin();
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

            _uiButtons[UIControls.ButtonType.Save].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.Discard].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.Posted].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.NotPosted].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.SelectAll].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.SelectNone].IsControlEnabled(available);
        }

        private void SetAvailabilityButton_SelectFunctions(bool available)
        {
            _uiButtons[UIControls.ButtonType.SelectAll].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.SelectNone].IsControlEnabled(available);
        }

        private void SetAvailabilityButton_SelectAllFunctions(bool available)
        {
            _uiButtons[UIControls.ButtonType.Save].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.Discard].IsControlEnabled(available);
        }

        private void SetAvailabilityButton_PostingFunctions(bool available)
        {
            _uiButtons[UIControls.ButtonType.Posted].IsControlEnabled(available);
            _uiButtons[UIControls.ButtonType.NotPosted].IsControlEnabled(available);
        }

        private void SetAvailabilityControls_SelectAllMode()
        {
            _uiButtons[UIControls.ButtonType.SelectAll].IsControlEnabled(SelectAllActive ? false : true);
            _uiButtons[UIControls.ButtonType.Posted].IsControlEnabled(SelectAllActive ? false : true);
            _uiButtons[UIControls.ButtonType.NotPosted].IsControlEnabled(SelectAllActive ? false : true);

            _uiButtons[UIControls.ButtonType.Save].IsControlEnabled(SelectAllActive);
            _uiButtons[UIControls.ButtonType.Discard].IsControlEnabled(SelectAllActive);
            _uiButtons[UIControls.ButtonType.SelectAll].IsControlEnabled(SelectAllActive);
            _uiButtons[UIControls.ButtonType.SelectNone].IsControlEnabled(SelectAllActive);

            ListBoxModelGallerySelection.ImportMode(SelectAllActive);
        }

        #endregion Button Availability Methods

        #region OtherThreads
        void _busybee_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (SelectAllActive == false)
                PlusPlayProcessor.CleanUpTempFiles();
        }
        #endregion OtherThreads

        private void InfoDisplayControl_NameChangeRequest(object incoming)
        {
            if (incoming.GetType() == typeof(Dictionary<Keyword, string>))
                _processor.NameChangeRequest((Dictionary<Keyword, string>)incoming, _selectedModel);
            else
                _processor.NameChangeRequest((string)incoming, _selectedGallery);

            ListBoxModelGallerySelection.SetListBoxMain(_processor.GetModelList(true));
        }
    }
}
