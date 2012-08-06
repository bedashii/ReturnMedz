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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IMDBDLL
{
    /// <summary>
    /// Class that manages the api calls.
    /// </summary>
    public class IMDbManager
    {
        /// <summary>
        /// Delegate that handles error calls.
        /// </summary>
        /// <param name="exc">Exception that occured.</param>
        public delegate void errorCall(Exception exc);

        /// <summary>
        /// Delegate that handles progress update calls.
        /// </summary>
        /// <param name="value">value to add to actual progress value.</param>
        public delegate void progressCall(int value);

        /// <summary>
        /// Delegate that calls the parent error handler.
        /// </summary>
        public Delegate parentErrorCaller;

        /// <summary>
        /// Delegate that calls the parent info processing handler.
        /// </summary>
        public Delegate parentFunctionCaller;

        /// <summary>
        /// Delegate that calls the parent progress update handler.
        /// </summary>
        public Delegate parentProgressUpdaterCaller;

        /// <summary>
        /// Event that raises the error caller.
        /// </summary>
        private event errorCall errorCaller;

        /// <summary>
        /// Event that raises the progress updater caller.
        /// </summary>
        private event progressCall progressCaller;
        
        private string query;
        private int media;
        private int nActors;
        private int sSeas;
        private int eSeas;
        private bool[] fields;
        private bool error = false;


        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public IMDbManager()
        {
            // Set the properties of this class
            errorCaller += new errorCall(errorHandler);
            progressCaller += new progressCall(progressHandler);
            error = false;
        }

        /// <summary>
        /// The main function, in wich we call the api with the options that we got from the form.
        /// </summary>
        /// <param name="searchMode">If it's to search by title or by ID.</param>
        /// <param name="q">Word(s) that we search.</param>
        /// <param name="m">If it's to search movies or tv series.</param>
        /// <param name="nAct">Number of actors to parse in each title.</param>
        /// <param name="sS">Number of the first season we want to parse.</param>
        /// <param name="eS">Number of the last season we want to parse.</param>
        /// <param name="f">Fields that we want to parse in each title.</param>
        public void IMDbSearch(int searchMode, string q, int m, int nAct, int sS, int eS, bool[] f)
        {
            this.query = q;
            this.media = m;
            this.nActors = nAct;
            this.sSeas = sS;
            this.eSeas = eS;
            this.fields = f;
            string url = "";
            int type = -1;
            if (searchMode == 0)
            {
                url += "http://www.imdb.com/find?s=all&q=" + query;
            }
            else if (searchMode == 1)
            {
                url += "http://www.imdb.com/title/" + query;
            }

            IMDB imdb = new IMDB();
            imdb.parentErrorCaller = errorCaller;
            imdb.parentProgressCaller = progressCaller;

            bool success = imdb.getPage(url);

            if (success && searchMode == 0 && !error)
            {
                type = imdb.getPageType(media, query);
            }
            if (type == 0 && !error)
            {
                List<IMDbLink> links = imdb.parseTitleLinks(media); // Gets the relevant links from that page
                if (links.Count > 0)
                {
                    processInfo(1, links);
                    progressHandler(20);
                }
                else
                {
                    errorHandler(new Exception("No results found!"));
                }
            }
            else if(!error)
            {
                progressHandler(20);
                IMDbTitle title = imdb.parseTitlePage(fields, media, nActors, sSeas, eSeas);
                processInfo(0, title);
            }
        }

        /// <summary>
        /// Parses a page of a title
        /// </summary>
        /// <param name="url">Relative URL of the page to be parsed</param>
        public void IMDbParse(string url)
        {
            if (!error)
            {
                IMDB imdb = new IMDB();
                imdb.parentErrorCaller = errorCaller;
                imdb.parentProgressCaller = progressCaller;
                bool ok = imdb.getPage("http://www.imdb.com" + url);
                if (ok && !error)
                {
                    IMDbTitle title = imdb.parseTitlePage(fields, media, nActors, sSeas, eSeas);
                    processInfo(0, title);
                }
            }
        }

        /// <summary>
        /// Send feedback of an error occured in the API to the main application
        /// </summary>
        /// <param name="exc">Exception that occured</param>
        private void errorHandler(Exception exc)
        {
            error = true;
            if(parentErrorCaller != null) 
                parentErrorCaller.DynamicInvoke(new Object[] { exc });
        }

        /// <summary>
        /// Send progress feedback to the main application
        /// </summary>
        /// <param name="value">value to be added to the progress bar</param>
        private void progressHandler(int value)
        {
            if(parentProgressUpdaterCaller != null)
                parentProgressUpdaterCaller.DynamicInvoke(new Object[] { value });
        }

        /// <summary>
        /// Send a processed result to the main application. It can be a list of results or an IMDbTitle
        /// object.
        /// </summary>
        /// <param name="type">Type of result</param>
        /// <param name="result">Object that represents the result</param>
        private void processInfo(int type, object result)
        {
            Object[] param = { type, result };
            parentFunctionCaller.DynamicInvoke(param);
        }
    }
}
