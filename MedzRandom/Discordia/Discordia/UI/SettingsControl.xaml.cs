using Discordia.Processors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        SettingsProcessor _processor;

        public SettingsControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _processor = new SettingsProcessor();
            _processor.MoviePathsWorkComplete += delegate
            {
                double width = 0;
                double newWidth = 0;

                listBoxMovieLocations.Items.Clear();
                _processor.MoviePaths.ForEach(x =>
                    {
                        newWidth = new FormattedText(x.ConfigValue, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 32, Brushes.Black).Width;
                        if (newWidth > width)
                            width = newWidth;
                        listBoxMovieLocations.Items.Add(x.ConfigValue);
                        newWidth = 0;
                    });
                if (width != 0)
                    listBoxMovieLocations.Width = width;
            };

            if (System.Configuration.ConfigurationSettings.AppSettings.AllKeys.ToList().Find(x => x == "OnlineMode") != null)
            {
                if (System.Configuration.ConfigurationSettings.AppSettings.Get("OnlineMode") == "1")
                    checkBoxOnlineMode.IsChecked = true;
                else
                    checkBoxOnlineMode.IsChecked = false;
            }
        }

        private void buttonMovieLocation_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DiscordiaGenLib.GenLib.Business.SystemConfig sc = new DiscordiaGenLib.GenLib.Business.SystemConfig("MoviePath", fbd.SelectedPath);

                _processor.MoviePaths.Add(sc);
                listBoxMovieLocations.Items.Add(sc.ConfigValue);

                double newWidth = new FormattedText(sc.ConfigValue, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 32, Brushes.Black).Width;

                if (newWidth > listBoxMovieLocations.Width)
                    listBoxMovieLocations.Width = newWidth;
            }
            _processor.MoviePaths.InsertOrUpdateAll();
        }

        private void checkBoxOnlineMode_Checked(object sender, RoutedEventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings.Set("OnlineMode", "1");
            MessageBox.Show("This option doesn't work yet.");
        }

        private void checkBoxOnlineMode_Unchecked(object sender, RoutedEventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings.Set("OnlineMode", "0");
            MessageBox.Show("This option doesn't work yet.");
        }
    }
}