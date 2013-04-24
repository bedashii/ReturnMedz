using DiscordiaGenLib.GenLib.Business;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Discordia.UI
{
    /// <summary>
    /// Interaction logic for MovieControl.xaml
    /// </summary>
    public partial class MovieControl : UserControl
    {
        public MovieControl()
        {
            InitializeComponent();
        }

        public MovieControl(string path)
        {
            InitializeComponent();
            FullPath = path;
        }

        string _fullPath;
        string FullPath
        {
            get
            {
                return _fullPath;
            }
            set
            {
                if (_fullPath != value)
                {
                    _fullPath = value;
                    findMovie();
                }
            }
        }

        private void findMovie()
        {
            FileInfo fi = new FileInfo(FullPath);

            Movie m = new Movie();
            m.GetByFileName(fi.Name);
            if (!m.RecordExists)
            {
                // Create new details
            }
        }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    updateTitleUI();
                }
            }
        }

        private void updateTitleUI()
        {
            textBlockTitle.Text = Title;
        }

        Image _poster;
        public Image Poster
        {
            get
            {
                return _poster;
            }
            set
            {
                if (_poster != value)
                {
                    _poster = value;
                    updatePosterUI();
                }
            }
        }

        List<string> _genres;
        public List<string> Genres
        {
            get
            {
                if (_genres == null)
                    _genres = new List<string>();
                return _genres;
            }
            set
            {
                if (_genres != value)
                {
                    _genres = value;
                    updateGenresUI();
                }
            }
        }

        List<string> _actors;
        public List<string> Actors
        {
            get
            {
                if (_actors == null)
                    _actors = new List<string>();
                return _actors;
            }
            set
            {
                if (_actors != value)
                {
                    _actors = value;
                    updateActorsUI();
                }
            }
        }

        string _synopsis;
        public string Synopsis
        {
            get
            {
                return _synopsis;
            }
            set
            {
                if (_synopsis != value)
                {
                    _synopsis = value;
                    updateSynopsisUI();
                }
            }
        }

        public string PosterPath { get; set; }

        private void updatePosterUI()
        {
            try
            {
                imagePoster.Source = new BitmapImage(new Uri(PosterPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateGenresUI()
        {
            wrapPanelGenres.Children.Clear();
            Genres.ForEach(genre =>
                {
                    wrapPanelGenres.Children.Add(new Button() { Content = genre });
                });
        }
        private void updateActorsUI()
        {
            wrapPanelActors.Children.Clear();
            Actors.ForEach(actor =>
                {
                    wrapPanelActors.Children.Add(new Button() { Content = actor });
                });
        }
        private void updateSynopsisUI()
        {
            textBlockSynopsis.Text = Synopsis;
        }

    }
}
