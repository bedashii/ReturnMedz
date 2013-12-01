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
using System.Windows.Shapes;

namespace Discordia.UI
{
    /// <summary>
    /// Interaction logic for RenameMovieWindow.xaml
    /// </summary>
    public partial class RenameMovieWindow : Window
    {
        public delegate void RenameHandler();
        public event RenameHandler Rename;

        public RenameMovieWindow()
        {
            InitializeComponent();
        }

        public string OriginalName
        {
            get
            {
                return textBoxOriginalName.Text;
            }
            set
            {
                textBoxOriginalName.Text = value;
            }
        }

        public string NewName
        {
            get
            {
                return textBoxNewName.Text;
            }
            set
            {
                textBoxNewName.Text = value;
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonRename_Click(object sender, RoutedEventArgs e)
        {
            Rename.Invoke();
            this.Close();
        }
    }
}
