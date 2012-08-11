using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MovieLib;
using MovieLib.Business;
using MovieLib.List;
using System.Net;


namespace ReturnMovieManagerWF.Controls
{
    public partial class MovieAddControl : UserControl
    {
        Processors.MovieAddProcessor _processor;

        public MovieAddControl()
        {
            InitializeComponent();
            _processor = new Processors.MovieAddProcessor();
            infoFileBindingSource.DataSource = _processor._infoFile;
            infoMovieBindingSource.DataSource = _processor._infoMovie;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"F:\[ROOT]  {~~}\~~\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _processor.GetInfo(ofd.FileName);

                if (_processor._infoMovie.Poster.ToLower().StartsWith("http"))
                    LoadImageFromUrl();
                else
                    LoadImageFromFile();

                LoadLanguages();
                LoadExtension();

                infoFileBindingSource.ResetBindings(false);
                infoMovieBindingSource.ResetBindings(false);
            }
        }

        private void LoadLanguages()
        {
            LBoxAudioLanguages.Items.Clear();
            
            if (_processor._infoFile.AudioLanguage1 != null)
                LBoxAudioLanguages.Items.Add(new AudioLanguages((short)_processor._infoFile.AudioLanguage1).Description);

            if (_processor._infoFile.AudioLanguage2 != null)
                LBoxAudioLanguages.Items.Add(new AudioLanguages((short)_processor._infoFile.AudioLanguage2).Description);

            if (_processor._infoFile.AudioLanguage3 != null)
                LBoxAudioLanguages.Items.Add(new AudioLanguages((short)_processor._infoFile.AudioLanguage3).Description);
        }

        private void LoadExtension()
        {
            ExtensionType et = new ExtensionType(_processor._infoFile.Extension);
            TBoxExtension.Text = et.Extension + " - " + et.ExtensionDescription;
        }

        public void LoadImageFromUrl()
        {
            HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create(_processor._infoMovie.Poster);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Image img = Image.FromStream(response.GetResponseStream());
            response.Close();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = img;
        }

        public void LoadImageFromFile()
        {
            Image img = Image.FromFile(_processor._infoMovie.Poster);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = img;
        }

    }
}
