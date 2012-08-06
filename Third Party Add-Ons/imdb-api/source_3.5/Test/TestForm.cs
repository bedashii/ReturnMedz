/*
 * This file is part of IMDBDLL.
 *
 *  IMDBDLL is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  IMDBDLL is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with IMDBDLL.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using IMDBDLL;
using System.Xml;

namespace Test
{
    /// <summary>
    /// Class that tests the API and shows how to use it.
    /// </summary>
    public partial class TestForm : Form
    {
        /// <summary>
        /// Delegate to call the processResults.
        /// </summary>
        public delegate void functionCall(int type, object result);

        /// <summary>
        /// Delegate to call the errorHandler.
        /// </summary>
        /// <param name="exc">The Exception.</param>
        public delegate void errorCall(Exception exc);

        /// <summary>
        /// Delegate to call the progressUpdater.
        /// </summary>
        /// <param name="value">Value to add to the progress bar.</param>
        public delegate void progressCall(int value);

        /// <summary>
        /// Event of functionCall.
        /// </summary>
        private event functionCall formFunctionCaller;

        /// <summary>
        /// Event of errorCall.
        /// </summary>
        private event errorCall formErrorCaller;

        /// <summary>
        /// Event of progressCall.
        /// </summary>
        private event progressCall formProgressCaller;

        /// <summary>
        /// Boolean that tells if there was an error.
        /// </summary>
        private bool error = false;

        /// <summary>
        /// The api manager instance.
        /// </summary>
        private IMDbManager manag;



        /// <summary>
        /// Constructor
        /// </summary>
        public TestForm()
        {
            InitializeComponent();

            //Adds the events
            formFunctionCaller += new functionCall(processResult); 
            formErrorCaller += new errorCall(errorHandler);
            formProgressCaller += new progressCall(progressUpdater);
        }

        /// <summary>
        /// Displays a message box with the error that occured.
        /// </summary>
        /// <param name="exc">Exception occured.</param>
        public void errorHandler(Exception exc)
        {
            error = true;
            button1.Enabled = true;
            Cursor = Cursors.Default;
            progressBar1.Value = 0;
            MessageBox.Show(exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Change the progress bar value.
        /// </summary>
        /// <param name="value">Value to add to the current value.</param>
        public void progressUpdater(int value)
        {
            progressBar1.Value += value;
        }

        /// <summary>
        /// Here we do whatever we want with the info.
        /// </summary>
        /// <param name="type">Type of result to process (list of results or a title).</param>
        /// <param name="result">The result object to be processed.</param>
        public void processResult(int type, object result)
        {
            if (!error) // if no errors occured
            {
                if (type == 0) // if we get a title
                {
                    IMDbTitle title = (IMDbTitle)result;
                    Console.WriteLine(title.Title);
                    richTextBox1.SelectionFont = new Font("arial", 12, FontStyle.Bold);
                    richTextBox1.AppendText("Title: ");
                    richTextBox1.SelectionFont = new Font("arial", 12, FontStyle.Regular);
                    richTextBox1.AppendText(title.Title + Environment.NewLine);

                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  IMDbLink: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.URL + Environment.NewLine);

                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  Year: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.Year + Environment.NewLine);

                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  Cover URL: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.CoverURL + Environment.NewLine);

                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  User Rating: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.Rating + Environment.NewLine);

                    if (title.Directors != null)
                    {
                        richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                        if (title.Media == 0)
                            richTextBox1.AppendText("  Directors:" + Environment.NewLine);
                        else richTextBox1.AppendText("  Creators:" + Environment.NewLine);

                        richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);


                        foreach (IMDbDirCrea person in title.Directors)
                        {
                            richTextBox1.AppendText("   " + person.Name + Environment.NewLine);
                            richTextBox1.AppendText("   " + person.URL + Environment.NewLine);
                        }
                    }

                    if (title.Media == 1 && title.Seasons != null)
                    {
                        richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                        richTextBox1.AppendText("  Seasons:" + Environment.NewLine);
                        for (int i = 0; i < title.Seasons.Count; i++)
                        {
                            IMDbSerieSeason season = title.Seasons[i];
                            richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                            richTextBox1.AppendText("   Season " + season.Number + Environment.NewLine);
                            if (season.Episodes != null)
                            {
                                foreach (IMDbSerieEpisode ep in season.Episodes)
                                {
                                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Bold);
                                    richTextBox1.AppendText("    Episode " + ep.Number + ": " + ep.Title + Environment.NewLine);
                                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                                    richTextBox1.AppendText("      Aired on: " + ep.AirDate + Environment.NewLine);
                                    richTextBox1.AppendText("      " + ep.Plot + Environment.NewLine);
                                }
                            }
                            else
                            {
                                richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Bold);
                                richTextBox1.AppendText("    No episodes!" + Environment.NewLine);
                            }
                            richTextBox1.AppendText(Environment.NewLine);
                        }
                    }

                    if (title.Genres != null)
                    {
                        richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                        richTextBox1.AppendText("  Genres: " + Environment.NewLine);
                        richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                        foreach (string genre in title.Genres)
                        {
                            richTextBox1.AppendText("   " + genre + Environment.NewLine);
                        }
                    }

                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  Tagline: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.Tagline + Environment.NewLine);

                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  Plot: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.Plot + Environment.NewLine);

                    if (title.Actors != null)
                    {
                        richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                        richTextBox1.AppendText("  Cast: " + Environment.NewLine);
                        foreach (IMDbActor actor in title.Actors)
                        {
                            richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                            richTextBox1.AppendText("   " + actor.Name + " as " + actor.Character + Environment.NewLine);
                            richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                            if (actor.PhotoURL != null)
                                richTextBox1.AppendText("   Photo URL: " + actor.PhotoURL + Environment.NewLine);
                            else richTextBox1.AppendText("   Photo URL: N/A" + Environment.NewLine);
                            richTextBox1.AppendText("   Page URL: " + actor.URL + Environment.NewLine);
                        }
                    }
                    richTextBox1.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                    richTextBox1.AppendText("  Runtime: ");
                    richTextBox1.SelectionFont = new Font("arial", 8, FontStyle.Regular);
                    richTextBox1.AppendText(title.Runtime + Environment.NewLine + Environment.NewLine);

                }
                else if (type == 1) // if we get a result list
                {
                    List<IMDbLink> results = (List<IMDbLink>)result;
                    Results res = new Results();
                    res.setResults(results);
                    if (res.ShowDialog() == DialogResult.OK)
                        manag.IMDbParse(res.Selected);
                }
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Function that handles the search button click. It is here that the API is called.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text != "") // if there is text in the textBox.
            {
                Cursor = Cursors.WaitCursor;
                richTextBox1.Clear(); // Clear the text field.
                error = false; //Reset the error.
                progressBar1.Value = 0; //Reset the progressbar.
                

                //Starts the manager of the api.

                manag = new IMDbManager();
                manag.parentErrorCaller = formErrorCaller;
                manag.parentFunctionCaller = formFunctionCaller;
                manag.parentProgressUpdaterCaller = formProgressCaller;

                //Read the options of the user.
                bool[] fields = { true, true, true, true, true, true, true, true, true, true, true }; //Parses all the fields.
                bool titleR = radioButton1.Checked, serieR = radioButton4.Checked;
                int media = 0, sSeas = 0, eSeas = 0, searchMode = 0, nActors = 5;
                if (serieR) // If it's a TV serie we are looking for
                { 
                    media = 1;
                    if (checkBox1.Checked) // Set how much seasons is to parse.
                    {
                        sSeas = -1;
                        eSeas = -1;
                    }
                    else
                    {
                        sSeas = Int32.Parse(textBox3.Text);
                        eSeas = Int32.Parse(textBox4.Text);
                    }
                }

                if (!titleR) // If it's to search by ID
                    searchMode = 1;

                if (checkBox2.Checked) // Set how much actors is to parse.
                {
                    nActors = -1;
                }
                else nActors = Int32.Parse(textBox5.Text);

                //Call the api.
                manag.IMDbSearch(searchMode, text, media, nActors, sSeas, eSeas, fields);
            }
        }

        /// <summary>
        /// Detect if the enter key was pressed in the textbox.
        /// </summary>
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, null);
        }

        /// <summary>
        /// If series radio button checked state changed
        /// </summary>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = !checkBox1.Enabled;
        }

        /// <summary>
        /// If all seasons radio button checked state changed.
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = !textBox3.Enabled;
            textBox4.Enabled = !textBox4.Enabled;
        }

        /// <summary>
        /// If all actors radio button checked state changed.
        /// </summary>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = !textBox5.Enabled;
        }
    }
}
