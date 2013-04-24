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
                    _movies = new List<MovieControl>();
                return _movies;
            }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    updateMovieUI();
                }
            }
        }

        void updateMovieUI()
        {
            listBoxMain.Items.Clear();
            MovieControlList.ForEach(x =>
            {
                listBoxMain.Items.Add(new ListBoxItem() { Content = x });
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
