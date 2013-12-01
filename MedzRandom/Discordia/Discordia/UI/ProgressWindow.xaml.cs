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
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        public double ProgressValue
        {
            get
            {
                return progressBarLoading.Value;
            }
            set
            {
                progressBarLoading.Value = value;
                textBlockProgress.Text = progressBarLoading.Value + " of " + progressBarLoading.Maximum;
            }
        }

        public double ProgressMax
        {
            get
            {
                return progressBarLoading.Maximum;
            }
            set
            {
                progressBarLoading.Maximum = value;
                textBlockProgress.Text = progressBarLoading.Value + " of " + progressBarLoading.Maximum;
            }
        }

        public string ProgressAction
        {
            get
            {
                return textBlockAction.Text;
            }
            set
            {
                textBlockAction.Text = value;
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        internal void ProgressStep()
        {
            if (progressBarLoading.Dispatcher.CheckAccess())
            {
                progressBarLoading.Value++;
            }
            else
            {
                progressBarLoading.Dispatcher.Invoke(delegate
                {
                    progressBarLoading.Value++;
                });
            }
            if (textBlockProgress.Dispatcher.CheckAccess())
            {
                textBlockProgress.Text = progressBarLoading.Value + " of " + progressBarLoading.Maximum;
            }
            else
            {
                textBlockProgress.Dispatcher.Invoke(delegate
                {
                    textBlockProgress.Text = progressBarLoading.Value + " of " + progressBarLoading.Maximum;
                });
            }
        }
    }
}
