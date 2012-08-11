using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ReturnMovieManagerWF.Controls;

namespace ReturnMovieManagerWF
{
    public partial class MainMenu : Form
    {
        MovieAddControl _movieAddControl;
        
        public MainMenu()
        {
            InitializeComponent();
            InitializeControls();
            TabMovieAddControl.Controls.Add(_movieAddControl);
            SetAddedControlProperties();

            this.WindowState = FormWindowState.Maximized;
        }

        private void SetAddedControlProperties()
        {
            _movieAddControl.Dock = DockStyle.Fill;
        }

        private void InitializeControls()
        {
            _movieAddControl = new MovieAddControl(); 
        }
    }
}
