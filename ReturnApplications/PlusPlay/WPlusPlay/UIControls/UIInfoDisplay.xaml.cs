using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for UIInfoDisplay.xaml
    /// </summary>
    public partial class UIInfoDisplay : UserControl//, INotifyPropertyChanged
    {
        #region Variables
        private string _modelName;
        public string ModelName
        {
            get { return _modelName; }
            set { TextBlockModel.Text = TextBoxModel.Text = _modelName = value; }
        }

        private string _galleryName;
        public string GalleryName
        {
            get { return _galleryName; }
            set { TextBlockGallery.Text = TextBoxGallery.Text = _galleryName = value; }
        }
        #endregion Variables

        #region Construction
        public UIInfoDisplay()
        {
            InitializeComponent();
        }
        #endregion Construction

        #region Methods
        internal void SetDisplay(string modelName, string galleryName)
        {
            if (!modelName.Equals(ModelName)) SetModel(modelName);
            SetGallery(galleryName);
        }

        internal void SetDisplay(bool importMode, Dictionary<Keyword, string> modelGalleryName)
        {
            TextBoxModel.Visibility = TextBoxGallery.Visibility
                = importMode ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

            TextBlockModel.Visibility = TextBlockGallery.Visibility
                = importMode ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;

            if (importMode)
            {
                TextBlockModel.Width = this.Width / 3;
                TextBlockGallery.Width = this.Width / 2;
            }

            if (modelGalleryName != null)
            {
                ModelName = modelGalleryName[Keyword.Model];
                GalleryName = modelGalleryName[Keyword.Gallery];
            }
        }

        internal Dictionary<Keyword, string> GetGalleryInfo()
        {
            Dictionary<Keyword, string> galleryInfo = new Dictionary<Keyword, string>();
            galleryInfo.Add(Keyword.Model, TextBoxModel.Text);
            galleryInfo.Add(Keyword.Gallery, TextBoxGallery.Text);
            return galleryInfo;
        }

        private void SetModel(string model)
        {
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.1));
            fadeOut.Completed += (sender, eArgs) =>
                {
                    GalleryName = "";
                    ModelName = model;
                    TextBlockModel.BeginAnimation(TextBlock.OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.15)));
                };

            TextBlockModel.BeginAnimation(TextBlock.OpacityProperty, fadeOut);
        }

        private void SetGallery(string gallery)
        {
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.1));
            fadeOut.Completed += (sender, eArgs) =>
            {
                GalleryName = gallery;
                TextBlockGallery.BeginAnimation(TextBlock.OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.15)));
            };

            TextBlockGallery.BeginAnimation(TextBlock.OpacityProperty, fadeOut);
        }
        #endregion Methods
    }
}
