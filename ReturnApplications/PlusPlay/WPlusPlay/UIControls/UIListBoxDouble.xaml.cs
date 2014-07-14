
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
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

namespace WPlusPlay.UIControls
{
    #region Delegates and Enums
    public delegate PlusPlayLib.List.ModelListB UIListBoxDouble_SetListBoxMain();
    public delegate PlusPlayLib.List.GalleryListB UIListBoxDouble_SetListBoxSub(PlusPlayLib.Bus.ModelB Model);
    public delegate void UIListBoxDouble_SubSelectedValueChanged(PlusPlayLib.Bus.Gallery Gallery);
    public delegate void UIListBoxDouble_MainSelectedValueChanged(PlusPlayLib.Bus.ModelB ModelB);
    #endregion Delegates and Enums
    public partial class UIListBoxDouble : UserControl
    {
        private enum CurrentlyDisplayed { Main, Sub };// Current ListBox being Displayed
        #region Variables
        public event UIListBoxDouble_SetListBoxMain ListBoxMain_Set;
        public event UIListBoxDouble_SetListBoxSub ListBoxSub_Set;
        public event UIListBoxDouble_SubSelectedValueChanged SubListBox_SelectedValueChanged;
        public event UIListBoxDouble_MainSelectedValueChanged MainListBox_SelectedValueChanged;

        CurrentlyDisplayed _currentlyDisplayed; // Is set in ShowListBoxSub(bool)
        double _downPosition;
        bool _mouseDown;
        #endregion Variables

        #region Construction
        public UIListBoxDouble()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            //ListBoxSub.Margin = new Thickness(ListBoxMain.ActualWidth, 0, 0, 0);
            //LabelGalleries.Margin = new Thickness(-300, 0, 0, 0);
        }
        #endregion Construction

        #region InternalMethods
        /// <summary>
        /// Populates the model listbox with the available models and selects the first model available
        /// </summary>
        /// <param name="models"></param>
        internal void SetListBoxMain(PlusPlayLib.List.ModelListB models)
        {
            ListBoxMain_Populate(models);

            // #FUTURE
            //if (_currentlyDisplayed == CurrentlyDisplayed.Sub)
            //    ListBoxSub_Populate(model
        }

        /// <summary>
        /// Populates the gallery listbox with the available galleries and selects the first gallery available
        /// </summary>
        /// <param name="galleries"></param>
        internal void SetListBoxSub(PlusPlayLib.List.GalleryListB galleries)
        {
            ListBoxSub_Populate(galleries);

            if (galleries.Count > 0)
                ListBoxSub.SelectedIndex = 0;
        }

        /// <summary>
        /// Populates the gallery listbox with the available galleries and selects specified gallery if available
        /// </summary>
        /// <param name="galleries"></param>
        /// <param name="galleryName"></param>
        internal void SetListBoxSub(PlusPlayLib.List.GalleryListB galleries, string galleryName)
        {
            ListBoxSub_Populate(galleries);

            foreach (PlusPlayLib.Bus.Gallery gallery in galleries)
                if (gallery.GalleryName == galleryName)
                    ListBoxSub.SelectedItem = gallery;
        }

        /// <summary>
        /// Sets the availability of this control. If import mode is active the main listbox is displayed and the control
        /// is deactivated.
        /// </summary>
        /// <param name="ImportActive"></param>
        internal void ImportMode(bool importActive)
        {
            if (importActive)
                if (ListBoxMain.Margin.Left > 0)
                    ShowListBoxSub(false);

            this.IsEnabled = importActive ? false : true;
        }
        #endregion InternalMethods

        #region Methods
        void ListBoxMain_Populate(PlusPlayLib.List.ModelListB models)
        {
            ListBoxMain.DataContext = models;
            ListBoxMain.DisplayMemberPath = "ModelName";
            DataContext = this;

            //ShowListBoxSub(false);
        }

        void ListBoxSub_Populate(PlusPlayLib.List.GalleryListB galleries)
        {
            ListBoxSub.DataContext = galleries;
            ListBoxSub.DisplayMemberPath = "GalleryName";
            DataContext = this;

            ShowListBoxSub(true);
        }

        void ShowListBoxSub(bool showListBoxSub)
        {
            _currentlyDisplayed = showListBoxSub ? CurrentlyDisplayed.Sub : CurrentlyDisplayed.Main;

            double width = showListBoxSub ? ListBoxMain.ActualWidth : ListBoxSub.ActualWidth;
            double width2 = showListBoxSub ? LabelModels.ActualWidth : LabelGalleries.ActualWidth;

            if (showListBoxSub)
            {
                ListBoxMain.BeginAnimation(ListBox.MarginProperty, new ThicknessAnimation(ListBoxMain.Margin, new Thickness(width, 0, 0, 0), TimeSpan.FromSeconds(0.5)));
                ListBoxSub.BeginAnimation(ListBox.MarginProperty, new ThicknessAnimation(new Thickness((width * -1), 0, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5)));
                LabelModels.BeginAnimation(TextBlock.MarginProperty, new ThicknessAnimation(LabelModels.Margin, new Thickness(width2, 0, 0, 0), TimeSpan.FromSeconds(0.5)));
                LabelGalleries.BeginAnimation(TextBlock.MarginProperty, new ThicknessAnimation(new Thickness((width2 * -1), 0, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5)));
            }
            else
            {
                ListBoxSub.BeginAnimation(ListBox.MarginProperty, new ThicknessAnimation(ListBoxSub.Margin, new Thickness((width * -1), 0, 0, 0), TimeSpan.FromSeconds(0.5)));
                ListBoxMain.BeginAnimation(ListBox.MarginProperty, new ThicknessAnimation(new Thickness(width, 0, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5)));
                LabelGalleries.BeginAnimation(TextBlock.MarginProperty, new ThicknessAnimation(LabelGalleries.Margin, new Thickness((width2 * -1), 0, 0, 0), TimeSpan.FromSeconds(0.5)));
                LabelModels.BeginAnimation(TextBlock.MarginProperty, new ThicknessAnimation(new Thickness(width2, 0, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5)));
            }
        }
        #endregion Methods

        #region Events
        private void ListBoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && ListBoxMain.SelectedItem != null)
            {
                ShowListBoxSub(true);
                SetListBoxSub(ListBoxSub_Set((PlusPlayLib.Bus.ModelB)ListBoxMain.SelectedItem));
            }
        }

        private void ListBoxMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxMain.SelectedItem != null)
            {
                ShowListBoxSub(true);
                SetListBoxSub(ListBoxSub_Set((PlusPlayLib.Bus.ModelB)ListBoxMain.SelectedItem));
            }
        }

        private void ListBoxSub_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown && (_downPosition - e.GetPosition(this).X > 60))
            {
                SetListBoxMain(ListBoxMain_Set());
                ShowListBoxSub(false);
            }
        }

        private void ListBoxSub_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _mouseDown = false;
        }

        private void ListBoxSub_MouseLeave(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void ListBoxSub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxSub.SelectedIndex > -1)
                SubListBox_SelectedValueChanged((PlusPlayLib.Bus.Gallery)ListBoxSub.SelectedItem);
        }

        private void ListBoxSub_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _downPosition = e.GetPosition(this).X;
            _mouseDown = true;
        }

        private void ListBoxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainListBox_SelectedValueChanged((PlusPlayLib.Bus.ModelB)ListBoxMain.SelectedItem);
        }
        #endregion Events
    }
}
