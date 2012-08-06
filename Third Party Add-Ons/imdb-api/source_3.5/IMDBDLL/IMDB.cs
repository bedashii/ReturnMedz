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
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Xml;

namespace IMDBDLL
{
    /// <summary>
    /// Main class of the API.
    /// </summary>
    public class IMDB
    {
        /// <summary>
        /// String that holds the downloaded page from IMDb.
        /// </summary>
        private String page = "";
        
        /// <summary>
        /// String that holds the query.
        /// </summary> 
        private String query = "";
        
        /// <summary>
        /// StringBuilder for working on html String
        /// </summary>
        private StringBuilder sB;

        /// <summary>
        /// Delegate that calls the parent error handler.
        /// </summary>
        public Delegate parentErrorCaller;

        /// <summary>
        /// Delegate that calls the parent progress update handler.
        /// </summary>
        public Delegate parentProgressCaller;

        /// <summary>
        /// Function that will download the search result from IMDb.
        /// </summary>
        /// <param name="url">The URL of the search result page.</param>
        /// <returns>The result of the page download. OK if there was no problems; The message error if there was any problem.</returns>
        public bool getPage(String url)
        {
            page = "";
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.AllowAutoRedirect = true;
                myRequest.Method = "GET";
                myRequest.Timeout = 6000;
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream());
                page = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();
                return true;
            }
            catch(Exception e)
            {
                parentErrorCaller.DynamicInvoke(new object[] { e });
                return false;
            }
            
        }

        /// <summary>
        /// Function that detects if the download page is a result page or if its the page for a specific title.
        /// </summary>
        /// <param name="media">Defines if it's to search a movie(0) or a TV serie(1).</param>
        /// <param name="q">The query inputed by the user.</param>
        /// <returns>An integer that tells the user if it's a result page or the actual page of the title.</returns>
        public int getPageType(int media, String q)
        {
            query = q;
            sB = new StringBuilder(page);
            string pat = "<title>(.*?)</title>";
            Regex reg = new Regex(pat);
            Match match = reg.Match(sB.ToString());
            string tit = match.Groups[1].Value;
            if (tit.StartsWith("IMDb"))
                return 0;
            else
            {
                pat = @"span class=""tv-extra""";
                reg = new Regex(pat);
                match = reg.Match(sB.ToString());

                if (media == 0 && tit.ToLower().Contains(query.ToLower()) && !match.Success)
                    return 1;
                else if (media == 1 && tit.ToLower().Contains(query.ToLower()) && match.Success)
                    return 1;
            }
            return -1;
        }

        /// <summary>
        /// This method gets the titles's links in the result page, from the section "Popular Titles" and "Titles (Exact Match)".
        /// </summary>
        /// <returns>An ArrayList with Strings that represent the links found in those sections.</returns>
        public List<IMDbLink> parseTitleLinks(int media)
        {
            sB = new StringBuilder(page);
            List<IMDbLink> links = new List<IMDbLink>();
            string line = "";
            string pat = "(<p><b>.*?)\n";
            Regex reg = new Regex(pat);
            Match match = reg.Match(sB.ToString());
            if (match.Success)
            {
                line = match.Groups[1].Value;
            }
            pat = @"<b>Popular Titles</b>(.*?)<p><b>";
            reg = new Regex(pat);
            match = reg.Match(line);
            if (match.Success)
            {
                List<IMDbLink> temp = parseLinks(match.Groups[1].Value, "Popular Titles", media);
                foreach (IMDbLink l in temp)
                    links.Add(l);
            }
            pat = @"<b>Titles \(Exact Matches\)</b>(.*?)<p><b>";
            reg = new Regex(pat);
            match = reg.Match(line);
            if (match.Success)
            {
                List<IMDbLink> temp = parseLinks(match.Groups[1].Value, "Exact Matches", media);
                foreach (IMDbLink l in temp)
                    links.Add(l);
            }
            pat = @"<b>Titles \(Approx Matches\)</b>(.*?)<p><b>";
            reg = new Regex(pat);
            match = reg.Match(line);
            if (match.Success)
            {
                List<IMDbLink> temp = parseLinks(match.Groups[1].Value, "Approximated Matches", media);
                foreach (IMDbLink l in temp)
                    links.Add(l);
            }
            pat = @"<b>Titles \(Partial Matches\)</b>(.*?)(<p><b>|</table> )";
            reg = new Regex(pat);
            match = reg.Match(line);
            if (match.Success)
            {
                List<IMDbLink> temp = parseLinks(match.Groups[1].Value, "Partial Matches", media);
                foreach (IMDbLink l in temp)
                    links.Add(l);
            }
            return links;
        }

        private string cleanText(string line)
        {
            line = line.Replace("&#38;", "&").Replace("&#233;", "é").Replace("&#225;", "á").Replace("&#237;", "í");
            line = line.Replace("&#243;", "ó").Replace("&#250;", "ú").Replace("&#224;", "à").Replace("&#232;", "è");
            line = line.Replace("&#236;", "ì").Replace("&#242;", "ò").Replace("&#249;", "ù").Replace("&#193;", "Á");
            line = line.Replace("&#201;", "É").Replace("&#205;", "Í").Replace("&#211;", "Ó").Replace("&#218;", "Ú");
            line = line.Replace("&#192;", "À").Replace("&#200;", "È").Replace("&#204;", "Ì").Replace("&#210;", "Ò");
            line = line.Replace("&#217;", "Ù").Replace("&#227;", "ã").Replace("&#245;", "õ").Replace("&#241;", "ñ");
            line = line.Replace("&#195;", "Ã").Replace("&#213;", "Õ").Replace("&#209;", "Ñ").Replace("&#226;", "â");
            line = line.Replace("&#234;", "ê").Replace("&#194;", "Â").Replace("&#202;", "Ê").Replace("&#34;", "\"");
            return line;
        }


        /// <summary>
        /// Parse all the major links found in some piece of String.
        /// </summary>
        /// <param name="section">The section of the page to search for links.</param>
        /// <param name="cat">The category of the section of the page to search for links.</param>
        /// <param name="media">The type of titles to search (movies or tv series).</param>
        /// <returns>A List of IMDbLink objects.</returns>
        private List<IMDbLink> parseLinks(string section, string cat, int media)
        {
            List<IMDbLink> links = new List<IMDbLink>();
            string pat = @"(<a href=.*?)</td></tr>";
            Regex reg = new Regex(pat);
            MatchCollection matches = reg.Matches(section);

            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    string line = m.Groups[1].Value;
                    line = cleanText(line);
                    pat = @"<a href=""(.{17})";
                    reg = new Regex(pat);
                    string url = reg.Match(line).Groups[1].Value;
                    pat = @"<img src=""(.*?)""";
                    reg = new Regex(pat);
                    string cover = reg.Match(line).Groups[1].Value;
                    pat = @";"">(&#34;|"")?(['&,áéíóúàèìòùÁÉÍÓÚÀÈÌÒÙãÃõÕâêÊÂñÑA-Za-z0-9 :\(\)!]*)(&#34;|"")?</a>\s*?\((\d{4}).*?\)";
                    reg = new Regex(pat);
                    Match mat = reg.Match(line);
                    IMDbLink l = new IMDbLink();
                    l.Title = mat.Groups[2].Value;
                    l.Year = mat.Groups[4].Value;
                    l.URL = url;
                    l.Cover = cover;
                    l.Category = cat;
                    pat = @"<small>(.*?)</small>";
                    reg = new Regex(pat);
                    if (reg.Match(line).Groups[1].Value != null && reg.Match(line).Groups[1].Value != "")
                        l.Media = 1;
                    else l.Media = 0;
                    
                    if(l.Media == media)
                        links.Add(l);
                }
            }
            return links;
        }

        /// <summary>
        /// Parses an html page with one title's informations
        /// </summary>
        /// <param name="fields">The fields allowed to be parsed.</param>
        /// <param name="media">If it's to parse a movie or a TV Serie.</param>
        /// <param name="actorN">Number of actors to parse.</param>
        /// <param name="sSeas">Number of first season to parse.</param>
        /// <param name="eSeas">Number of last season to parse.</param>
        /// <returns>A list of Strings with the info from the title.</returns>
        public IMDbTitle parseTitlePage(bool[] fields, int media, int actorN, int sSeas, int eSeas)
        {
            try
            {
                sB = new StringBuilder(page);
                IMDbTitle titl = new IMDbTitle();
                titl.Media = media;
                sB = new StringBuilder(page);

                string pat = @"<title>(.*?)\((\d{4}).*?\)</title>";
                Regex reg = new Regex(pat);
                Match match = reg.Match(sB.ToString());
                string title = match.Groups[1].Value;
                string year = match.Groups[2].Value;

                pat = @"<h1>(.*?)</h1>";
                reg = new Regex(pat);
                string type = reg.Match(sB.ToString()).Groups[1].Value;
                bool parse = true;
                if ((media == 0 && type.Contains("TV series")) || (media == 1 && !type.Contains("TV series"))) 
                {
                    parse = false;
                }
                if (parse)
                {
                    pat = @";id=(tt\d{7});";
                    reg = new Regex(pat);
                    string link = "http://www.imdb.com/title/" + reg.Match(sB.ToString()).Groups[1].Value + "/";
                    titl.URL = link;
                    titl.ID = reg.Match(sB.ToString()).Groups[1].Value;

                    if (fields[0]) //Parse the titles's title
                    {
                        titl.Title = cleanText(title);
                    }
                    if (fields[1]) //Parse the titles's year
                    {
                        titl.Year = cleanText(year);
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 10 });

                    if (fields[2]) //Parse the titles's Cover link
                    {
                        if (!sB.ToString().Contains("http://ia.media-imdb.com/media/imdb/01/I/37/89/15/10.gif"))
                        {
                            pat = @"<a name=""poster"".*?src=""(.*?)""";
                            reg = new Regex(pat);
                            string covLink = reg.Match(sB.ToString()).Groups[1].Value;

                            titl.CoverURL = covLink;
                        }
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 5 });

                    if (fields[3]) //Parse the titles's User Rating
                    {
                        pat = @"<b>([0-9/\.]+)*.?</b>";
                        reg = new Regex(pat);
                        string rating = reg.Match(sB.ToString()).Groups[1].Value;

                        titl.Rating = cleanText(rating);
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 5 });

                    if (fields[4]) //Parse the Creators/Directors
                    {
                        if (media == 0) //directors
                        {
                            List<IMDbDirCrea> directors = new List<IMDbDirCrea>();
                            pat = @"<h5>Director.*?\n(<a href=.*?</a>)<br/>\n{1,2}</div>";
                            reg = new Regex(pat, RegexOptions.Singleline);
                            match = reg.Match(sB.ToString());
                            if (match.Success)
                            {
                                string temp = match.Groups[1].Value;
                                pat = @"<a href=""(.{16})"">(.*?)</a>";
                                reg = new Regex(pat);
                                MatchCollection matches = reg.Matches(temp);
                                foreach (Match m in matches)
                                {
                                    IMDbDirCrea director = new IMDbDirCrea();
                                    director.Type = 0;
                                    director.Name = cleanText(m.Groups[2].Value);
                                    director.URL = "http://www.imdb.com" + m.Groups[1].Value;
                                    directors.Add(director);
                                }
                                titl.Directors = directors;
                            }
                            
                        }
                        else if (media == 1) //creators
                        {
                            List<IMDbDirCrea> creators = new List<IMDbDirCrea>();
                            pat = @"<h5>Creator.*?\n(<a href=.*?</a>)<br/>\n{1,2}<a class";
                            reg = new Regex(pat, RegexOptions.Singleline);
                            match = reg.Match(sB.ToString());
                            if (match.Success)
                            {
                                string temp = match.Groups[1].Value;
                                pat = @"<a href=""(.{16})"">(.*?)</a>";
                                reg = new Regex(pat, RegexOptions.Singleline);
                                MatchCollection matches = reg.Matches(temp);
                                foreach (Match m in matches)
                                {
                                    IMDbDirCrea creator = new IMDbDirCrea();
                                    creator.Type = 0;
                                    creator.Name = cleanText(m.Groups[2].Value);
                                    creator.URL = "http://www.imdb.com" + m.Groups[1].Value;
                                    creators.Add(creator);
                                }
                                titl.Directors = creators;
                            }
                        }
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 15 });

                    if (media == 1 && fields[5]) // Parse serie's seasons
                    {
                        pat = @"<h5>Seasons.*?(<a href=.*?)</a>\n{1,2}<a class";
                        reg = new Regex(pat, RegexOptions.Singleline);
                        match = reg.Match(sB.ToString());

                        if (match.Success)
                        {
                            string startSeas = "episodes#season-";
                            if (sSeas == -1)
                                startSeas += "1";
                            else
                                startSeas += sSeas;
                            string temp = match.Groups[1].Value;
                            reg = new Regex(startSeas, RegexOptions.Singleline);
                            match = reg.Match(temp);
                            if (match.Success)
                            {
                                parseSeason(link + startSeas, eSeas, titl);
                            }
                        }       
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 25 });

                    if (fields[6]) //Parse Genres
                    {
                        pat = @"<h5>Genre.*?\n(<a href=.*?)<a class=";
                        reg = new Regex(pat);
                        match = reg.Match(sB.ToString());
                        if(match.Success) 
                        {
                            List<string> genres = new List<string>();
                            string temp = match.Groups[1].Value;
                            pat = @""">(.*?)</a>";
                            reg = new Regex(pat);
                            MatchCollection matches = reg.Matches(temp);
                            foreach (Match m in matches)
                            {
                                genres.Add(cleanText(m.Groups[1].Value));
                            }
                            titl.Genres = genres;
                        }
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 5 });

                    if (fields[7]) //Parse the Tagline
                    {
                        pat = @"<h5>Tagline.*?\n(.*?)\n?<";
                        reg = new Regex(pat);
                        titl.Tagline = cleanText(reg.Match(sB.ToString()).Groups[1].Value.Trim());
                    }

                    if (fields[8]) //Parse the Plot
                    {
                        pat = @"<h5>Plot.*?\n(.*?)\n?<";
                        reg = new Regex(pat);
                        titl.Plot = cleanText(reg.Match(sB.ToString()).Groups[1].Value.Trim());
                    }


                    if (fields[9]) //Parse the Actors
                    {
                        pat = @"<h3>Cast.*?(<a href=.*?)<a class=";
                        reg = new Regex(pat);
                        match = reg.Match(sB.ToString());
                        if (match.Success)
                        {
                            List<IMDbActor> actors = new List<IMDbActor>();
                            string temp = match.Groups[1].Value;
                            //pat = @"<a href="".*?<img src=""(.*?)"".*?<a href=""(.*?)"">(.*?)</a>.*?(href=""/character/.*?"">(.*?))?</a>";
                            pat = @"<a href="".*?<img src=""(.*?)"".*?<a href=""(.*?)"">(.*?)</a>.*?(<td class=""char"">(.*?))?</td></tr>";
                            reg = new Regex(pat);
                            MatchCollection matches = reg.Matches(temp);
                            int count = 0;
                            foreach (Match m in matches)
                            {
                                if (actorN == -1 || (count < actorN))
                                {
                                    IMDbActor actor = new IMDbActor();
                                    actor.Name = cleanText(m.Groups[3].Value);
                                    string caract = m.Groups[5].Value;
                                    if (caract != null && caract != "")
                                    {
                                        if (caract.Contains("<a href="))
                                        {
                                            pat = @"href=""/character/.*?"">(.*?)</a>";
                                            reg = new Regex(pat);
                                            caract = reg.Match(caract).Groups[1].Value;
                                        }
                                    }
                                    actor.Character = cleanText(caract);

                                    if (m.Groups[1].Value != "http://i.media-imdb.com/images/tn15/addtiny.gif")
                                    {
                                        actor.PhotoURL = m.Groups[1].Value;
                                    }

                                    actor.URL = "http://www.imdb.com" + m.Groups[2].Value;
                                    actors.Add(actor);
                                    count++;
                                }
                            }
                            titl.Actors = actors;
                        }
                    }

                    parentProgressCaller.DynamicInvoke(new object[] { 10 });

                    if (fields[10]) //Parse the Runtime
                    {
                        pat = @"<h5>Runtime.*?\n(\d+ min)";
                        reg = new Regex(pat);
                        match = reg.Match(sB.ToString());

                        if (match.Success)
                        {
                            titl.Runtime = match.Groups[1].Value;
                        }
                    }
                    
                    parentProgressCaller.DynamicInvoke(new object[] { 5 });
                }
                return titl;
            }
            catch (Exception ex)
            {
                parentErrorCaller.DynamicInvoke(new object[] { ex });
            }
            return null;
        }

        /// <summary>
        /// Connects to the seasons's info about a serie and parses the episodes's infos.
        /// </summary>
        /// <param name="url">url of the page.</param>
        /// <param name="eSeas">Parse till this season.</param>
        /// <param name="title">The title object that holds the infos.</param>
        private void parseSeason(String url, int eSeas, IMDbTitle title)
        {
            if (getPage(url))
            {
                StringBuilder strB = new StringBuilder(page);
                Regex reg;
                string pat;
                Match match;
                int season;
                if (eSeas != -1)
                    season = Int32.Parse(url.Substring(url.Length - 1));
                else //detect last available season
                {
                    season = 1;
                    eSeas = 0;

                    pat = "name=\"season-";
                    reg = new Regex(pat);
                    match = reg.Match(strB.ToString());
                    while (match.Success)
                    {
                        eSeas++;
                        match = match.NextMatch();
                    }
                }
                List<IMDbSerieSeason> seasons = new List<IMDbSerieSeason>();
                while (season <= eSeas)
                {
                    pat = @"Season "+season+"\n</a></h3>(.*?)\n\n</div>\n";
                    reg = new Regex(pat, RegexOptions.Singleline);
                    if (reg.Match(strB.ToString()).Success)
                    {
                        IMDbSerieSeason seas = new IMDbSerieSeason();
                        seas.Number = season;
                        string epList = reg.Match(strB.ToString()).Groups[1].Value;
                        string[] ep = epList.Split(Environment.NewLine.ToCharArray());
                        int epis = 1;
                        List<IMDbSerieEpisode> episodes = new List<IMDbSerieEpisode>();
                        foreach (string line in ep)
                        {
                            if (line.Length > 10)
                            {
                                IMDbSerieEpisode episode = new IMDbSerieEpisode();
                                pat = @"<a href="".{17}"">(.*?)</a>.*?<strong>(.*?)</strong>.*?<br>\s*(.*?)<";
                                reg = new Regex(pat);
                                match = reg.Match(line);

                                episode.Number = epis;
                                episode.Title = cleanText(match.Groups[1].Value);
                                episode.AirDate = match.Groups[2].Value;
                                string plot = match.Groups[3].Value;
                                if (plot != null && plot != "")
                                {
                                    episode.Plot = cleanText(match.Groups[3].Value);
                                }
                                episodes.Add(episode);

                                epis++;
                            }
                        }
                        seas.Episodes = episodes;
                        seasons.Add(seas);
                    }
                    season++;
                }
                title.Seasons = seasons;
            }
        }
    }
}
