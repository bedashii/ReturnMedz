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

namespace Discordia.UI
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class MoviesControl : UserControl
    {
        public MoviesControl()
        {
            InitializeComponent();
        }

        List<MovieControl> _movies;
        public List<MovieControl> MovieControlList
        {
            get
            {
                if (_movies == null)
                {
                    _movies = new List<MovieControl>();
                }
                return _movies;
            }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    // This adds an event handler that will run on all movies except the one being selected.
                    // This is currently being used to maximize the poster when a movie is not selected.
                    _movies.ForEach(x =>
                        {
                            x.GainedFocus += delegate(string fullPath)
                            {
                                _movies.ForEach(y =>
                                    {
                                        if (fullPath != y.FullPath && y.Posters.Count != 0)
                                        {
                                            y.Poster.Height = new GridLength(1, GridUnitType.Star);
                                            y.Main.Height = new GridLength(0, GridUnitType.Star);
                                        }
                                    });
                            };
                        });
                    updateMovieUI();
                }
            }
        }

        int selectedIndex = 0;

        void updateMovieUI()
        {
            // Originally I wanted 3 seperate list boxes to hold the movies so that you could scroll though them.
            // Kinda like Movies spinning around a cylinder

            //listBoxTop.Items.Clear();
            //wrapPanelMain.Children.Clear();
            //listBoxBottom.Items.Clear();

            //if (selectedIndex != 0 && selectedIndex > 5)
            //{

            //}

            //if (selectedIndex != 0 && selectedIndex > 6)
            //{

            //}
            MovieControlList.ForEach(x =>
                {
                    wrapPanelMain.Children.Add(x);
                });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < 15; i++)
            //{
            //    MovieControlList.Add(new MovieControl());
            //}
            //updateMovieUI();
        }
    }
}
