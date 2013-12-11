using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BadReferenceFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonScan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxPath.Text == null || textBoxPath.Text.Trim() == "")
                    throw new ApplicationException("Please enter a path.");
                if (!Directory.Exists(textBoxPath.Text))
                    throw new ApplicationException("Path provided does not exist.");

                listBoxResults.Items.Clear();
                projectFiles = null;

                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += delegate
                {
                    if (textBoxPath.CheckAccess())
                        addFiles(textBoxPath.Text, true);
                    else
                        textBoxPath.Dispatcher.Invoke(delegate { addFiles(textBoxPath.Text, true); });

                    foreach (FileInfo fi in projectFiles)
                    {
                        if (listBoxResults.CheckAccess())
                            listBoxResults.Items.Add(fi.FullName);
                        else
                            listBoxResults.Dispatcher.Invoke(delegate { listBoxResults.Items.Add(fi.FullName); });
                    }
                };
                bg.RunWorkerCompleted += delegate
                {
                    MessageBox.Show("Scan Complete");
                };

                bg.RunWorkerAsync();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private List<FileInfo> projectFiles;

        private void addFiles(string path, bool includeSubfolders)
        {
            if (projectFiles == null)
                projectFiles = new List<FileInfo>();

            try
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(file);

                        if (fi.Extension == ".csproj")
                            projectFiles.Add(fi);
                    }
                    catch (Exception ex)
                    {
                        // If the file cannot be read then just ignore it.
                    }
                }

                if (includeSubfolders)
                {
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        addFiles(folder, includeSubfolders);
                    }
                }
            }
            catch (Exception ex)
            {
                // If the files cannot be read then just ignore it.
            }
        }

        private void listBoxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listBoxResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBoxResults.SelectedItem != null)
            {
                ReferencesWindow rw = new ReferencesWindow(listBoxResults.SelectedItem.ToString());
                rw.ShowDialog();
            }
        }
    }
}
