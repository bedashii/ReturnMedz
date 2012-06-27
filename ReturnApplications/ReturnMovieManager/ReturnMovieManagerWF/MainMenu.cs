using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReturnMovieManagerWF
{
    public partial class MainMenu : Form
    {
        Dictionary<string, Control> ControlList = new Dictionary<string, Control>();
        Control DisplayedControl;

        public MainMenu()
        {
            InitializeComponent();
            ControlList = new Dictionary<string, Control>();
            DisplayedControl = new Control();
        }

        private void addMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControlList.ContainsKey("MovieAddControl") == false)
            {
                Movies.MovieAddControl mac = new Movies.MovieAddControl();
                ControlList.Add("MovieAddControl", mac);
                FormatNewControl(ControlList["MovieAddControl"]);
            }

            //DisplayedControl = ControlList["MovieAddControl"];
            PanelMain.Controls.Add(ControlList["MovieAddControl"]);
        }

        public void FormatNewControl(Control control)
        {
            control.Dock = DockStyle.Fill;
        }

    }
}
