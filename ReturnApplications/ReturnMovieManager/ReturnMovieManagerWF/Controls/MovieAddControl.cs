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


namespace ReturnMovieManagerWF.Movies
{
    public partial class MovieAddControl : UserControl
    {
        Processors.MovieAddProcessor _processor;

        public MovieAddControl()
        {
            InitializeComponent();
            
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            
            _processor = new Processors.MovieAddProcessor();
	    OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"F:\[ROOT] Collections and Sequels\{Sequels}\[ROOT] Harry Potter\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _processor.FileName = ofd.FileName;
            }
        }
    }
}
