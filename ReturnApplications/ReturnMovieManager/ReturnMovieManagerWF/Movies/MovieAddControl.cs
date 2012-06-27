using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RetLib;
using RetLib.Business;
using RetLib.Lists;


namespace ReturnMovieManagerWF.Movies
{
    public partial class MovieAddControl : UserControl
    {
        Movie SelectedMovie;
        string SelectedPath { get; set; }
        string DefaultMoviePath = System.Configuration.ConfigurationManager.AppSettings["DefaultMoviePath"];
        
        public MovieAddControl()
        {
            InitializeComponent();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();
            TBoxFolderName.Text = SelectedPath = fbd.SelectedPath;
        }

        private void GetMovieInfo()
        {
            if (SelectedMovie == null)
                SelectedMovie = new Movie();


        }
    }
}
