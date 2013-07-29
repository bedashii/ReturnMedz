using Discordia.UI;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Discordia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker _bg;
        private MainProcessor _processor;

        public MainWindow()
        {
            InitializeComponent();

            buttonScan.IsEnabled = false;
            buttonSettings.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_bg == null)
            {
                _bg = new BackgroundWorker();

                _bg.DoWork += delegate
                {
                    new StartUp();
                };

                _bg.RunWorkerCompleted += delegate
                {
                    _bg = null;
                    _bg = new BackgroundWorker();

                    _bg.DoWork += delegate
                    {
                        if (_processor == null)
                        {
                            _processor = new MainProcessor();
                        }
                    };
                    _bg.RunWorkerCompleted += delegate
                    {
                        buttonScan.IsEnabled = true;
                        buttonSettings.IsEnabled = true;
                    };

                    _bg.RunWorkerAsync();
                };
            }
            _bg.RunWorkerAsync();
        }

        private UIElement activeControl;

        private void setActiveControl(UIElement control)
        {
            if (activeControl != null)
                gridMain.Children.Remove(activeControl);

            gridMain.Children.Add(control);
            Grid.SetColumn(control, 2);

            activeControl = control;
        }

        private SettingsControl settings;
        private MoviesControl movies;

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null)
            {
                settings = new SettingsControl();
            }

            setActiveControl(settings);
        }

        private void ButtonScan_Click(object sender, RoutedEventArgs e)
        {
            if (movies == null)
                movies = new MoviesControl();
            else
                movies.MovieControlList.Clear();
            movies.MovieControlList = _processor.Scan();

            setActiveControl(movies);
        }
    }
}
