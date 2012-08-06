using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMDBDLL;

namespace Test
{
    /// <summary>
    /// Class that represents the window that displays the search results
    /// </summary>
    public partial class Results : Form
    {
        /// <summary>
        /// The list with the results.
        /// </summary>
        private List<IMDbLink> links;
        
        private string selectedTitle = "";

        /// <summary>
        /// The title that was selected by the user to be parsed.
        /// </summary>
        public string Selected { get { return selectedTitle; } set { selectedTitle = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public Results()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add the results to the list to be displayed.
        /// </summary>
        /// <param name="results">The list of results, returned by the API.</param>
        public void setResults(List<IMDbLink> results)
        {
            links = results;

            foreach (IMDbLink l in links)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.AddRange(new DataGridViewRow[] { row });
                row.Cells[0].Value = l.Title + " (" + l.Year + ")";
            }
        }

        /// <summary>
        /// Set the selected title
        /// </summary>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Selected = links[dataGridView1.SelectedRows[0].Index].URL;
        }
    }
}
