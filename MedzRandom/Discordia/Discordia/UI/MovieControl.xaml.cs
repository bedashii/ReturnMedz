using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        #region CustomEvents
        public delegate void GainedFocusHandler(string fullPath);
        public event GainedFocusHandler GainedFocus; 
        #endregion

        #region Properties
        string _fullPath;
        public string FullPath
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

        private bool OnlineMode
        {
            get
            {
                if (System.Configuration.ConfigurationSettings.AppSettings.AllKeys.ToList().Find(x => x == "OnlineMode") != null)
                {
                    if (System.Configuration.ConfigurationSettings.AppSettings.Get("OnlineMode") == "1")
                        return true;
                    else
                        return false;
                }
                return true;
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

        PosterList _posters;
        public PosterList Posters
        {
            get
            {
                if (_posters == null)
                {
                    _posters = new PosterList();
                    //_posters.GetByMovie();
                }
                return _posters;
            }
            set
            {
                if (_posters != value)
                {
                    _posters = value;
                    updatePosterUI();
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
        #endregion

        #region Contructors
        public MovieControl()
        {
            InitializeComponent();
        }

        public MovieControl(string path)
        {
            InitializeComponent();
            FullPath = path;
        } 
        #endregion

        #region Events
        private void buttonPoster_Click(object sender, RoutedEventArgs e)
        {
            if (Posters.Count > 0)
            {
                if (Poster.Height.Value == 1)
                {
                    Poster.Height = new GridLength(0, GridUnitType.Star);
                    Main.Height = new GridLength(1, GridUnitType.Star);

                    GainedFocus.Invoke(FullPath);
                }
                else
                {
                    Poster.Height = new GridLength(1, GridUnitType.Star);
                    Main.Height = new GridLength(0, GridUnitType.Star);
                }
            }
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(FullPath);
        } 
        #endregion

        #region Methods
        private void findMovie()
        {
            FileInfo fi = new FileInfo(FullPath);

            string title = cleanTitle(fi.Name.Replace(fi.Extension, string.Empty));

            Movie m = new Movie();
            m.GetByTitle(title);
            //m.GetByFileName(fi.Name);
            if (OnlineMode && !m.RecordExists)
            {
                // TODO
                // Create new details and save
                WatTmdb.V3.Tmdb tmdb = new WatTmdb.V3.Tmdb("72cdccd9229e5896d3df21c8c96b3016");
                var movieSearch = tmdb.SearchMovie(title, 1);
                if (movieSearch.results.Count > 0)
                {
                    m.TMDBID = movieSearch.results[0].id;
                    m.Title = movieSearch.results[0].title.Replace(":", string.Empty).Replace("'", string.Empty);
                    m.Rating = movieSearch.results[0].popularity;
                    int year = 0;
                    if (Int32.TryParse(movieSearch.results[0].release_date, out year))
                        m.Year = year;

                    Posters.GetByMovie(m.TMDBID);

                    var images = tmdb.GetMovieImages(m.TMDBID);
                    images.posters.ForEach(x =>
                    {
                        if (Posters.Find(y => y.URL == x.file_path) == null)
                            Posters.Add(new Poster()
                            {
                                Movie = m.TMDBID,
                                URL = x.file_path,
                                Width = x.width,
                                Height = x.height
                            });
                    });


                    Posters.InsertOrUpdateAll();
                    m.InsertOrUpdate();

                    string dest = m.Title;
                    if (m.Year != 0)
                        dest += " " + m.Year;
                    dest += fi.Extension;

                    if (fi.Name != dest)
                    {
                        File.Move(fi.FullName, fi.DirectoryName + "\\" + dest);
                        _fullPath = fi.DirectoryName + "\\" + dest;
                        fi = null;
                    }
                }
            }
            else
            {
                m.Title = title;
            }

            if (Posters.Count == 0)
            {
                Posters.GetByMovie(m.TMDBID);
            }

            updateUI(m);
        }

        List<string> cleanStrings = new List<string>() { "480p", "720p", "1080p" };

        // Gets rid of strings that are most likely not part of the title.
        private string cleanTitle(string title)
        {
            title = removeDate(title);

            string newTitle = "";
            title.Split(' ').ToList().ForEach(x =>
            {
                if (cleanStrings.Find(y => x == y) == null)
                {
                    newTitle = appendTitle(newTitle, x);
                }
            });
            return newTitle;
        }

        private string appendTitle(string newTitle, string x)
        {
            if (x == "And" || x == "and")
                x = "&";
            if (newTitle == "")
                newTitle += x;
            else
                newTitle += " " + x;

            return newTitle;
        }

        private string removeDate(string title)
        {
            string newTitle = "";
            List<string> titleSplit = title.Split(' ').ToList();
            int counter = 0;
            int tempInt = 0;
            titleSplit.ForEach(x =>
            {
                if (Int32.TryParse(x, out tempInt))
                    counter++;
            });

            // No Date Found
            if (counter == 0)
                return title;

            int counterPlaceHolder = 0;

            titleSplit.ForEach(x =>
            {
                if (counter == 1) // only one number, assumed date
                {
                    if (!Int32.TryParse(x, out tempInt))
                        newTitle = appendTitle(newTitle, x);
                    else
                    {
                        if (x.Length != 4)
                            newTitle = appendTitle(newTitle, x);
                    }
                }
                else // More than one number, only remove last.
                {
                    if (Int32.TryParse(x, out tempInt))
                    {
                        // If it's the last number, skip it, aka remove it.
                        if (counter - 1 != counterPlaceHolder)
                        {
                            newTitle = appendTitle(newTitle, x);
                            counterPlaceHolder++;
                        }
                    }
                    else
                    {
                        newTitle = appendTitle(newTitle, x);
                    }
                }
            });
            return newTitle;
        }

        private void updateUI(Movie m)
        {
            // TODO
            Title = m.Title;
            updatePosterUI();
        }

        private void updateTitleUI()
        {
            textBlockTitle.Text = Title;
        }
        private void updatePosterUI()
        {
            try
            {
                if (Posters.Count > 0)
                {
                    if (OnlineMode)
                    {
                        string url = @"http://cf2.imgobject.com/t/p/w500" + @Posters[0].URL;
                        if (Posters[0].Path == null || Posters[0].Path == "" || !File.Exists("Posters\\" + @Posters[0].Path))
                        {
                            if (!Directory.Exists("Posters"))
                                Directory.CreateDirectory("Posters");

                            FileInfo fi = new FileInfo("Posters\\" + Posters[0].URL.Substring(1));
                            if (!fi.Exists)
                            {
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFile(@url, "Posters\\" + Posters[0].URL.Substring(1));
                                }
                            }
                            Posters[0].Path = Posters[0].URL.Substring(1);
                            Posters[0].Update();
                        }
                    }

                    if (Posters[0].Path != "")
                    {
                        FileInfo fi = new FileInfo("Posters\\" + @Posters[0].Path);
                        if (fi.Exists)
                        {
                            imagePoster.Source = new BitmapImage(new Uri(fi.FullName));
                            imageMainPoster.Source = new BitmapImage(new Uri(fi.FullName));
                        }
                        fi = null;
                    }
                }

                if (Posters.Count == 0)
                {
                    Poster.Height = new GridLength(0, GridUnitType.Star);
                    Main.Height = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    Poster.Height = new GridLength(1, GridUnitType.Star);
                    Main.Height = new GridLength(0, GridUnitType.Star);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
        #endregion
    }
}
