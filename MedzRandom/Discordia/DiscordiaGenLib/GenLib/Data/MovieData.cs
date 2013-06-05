using DiscordiaGenLib.GenLib.Business;
using DiscordiaGenLib.GenLib.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Data
{
    public class MovieData : MovieProperties
    {
        DataHelper dh = new DataHelper();

        public MovieData()
        {
            dh.InitializeDB();
        }

        internal void Insert()
        {
            string q = "Insert INTO Movies(Title,Poster,Synopsis,Year,Duration,Rating,AgeRestriction,IMDBID)\n";
            q += "VALUES('" + Title + "'," + Poster + ",'" + Synopsis + "'," + Year + "," + Duration + "," + Rating + ",'" + AgeRestriction + "'," + IMDBID + ")";

            this.RecordExists = true;

            dh.ExecuteNonQuery(q);
        }

        internal void Update()
        {
            string q = "UPDATE Movies\n";
            q += "SET Title = '" + Title + "',\n";
            q += "Poster = " + Poster + ",\n";
            q += "Synopsis = '" + Synopsis + "',\n";
            q += "Year = " + Year + ",\n";
            q += "Duration = " + Duration + ",\n";
            q += "Rating = " + Rating + ",\n";
            q += "AgeRestriction = '" + AgeRestriction + "',\n";
            q += "IMDBID = " + IMDBID + ",\n";
            q += "WHERE ID = " + ID;

            dh.ExecuteNonQuery(q);

            this.AnyPropertiesChanged = false;
        }

        internal void Delete()
        {
            string q = "DELETE FROM Movies\n";
            q += "WHERE ID = " + ID;

            dh.ExecuteNonQuery(q);
        }

        internal Lists.MovieList GetAll()
        {
            Lists.MovieList list = new Lists.MovieList();

            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT * FROM Movies";

                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(q, dh.connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                Movie m = null;

                while (dataReader.Read())
                {
                    m = new Movie();

                    if (dh.HasColumn(dataReader, "ID"))
                        m.ID = Convert.ToInt32(dataReader["ID"]);
                    if (dh.HasColumn(dataReader, "Title"))
                        m.Title = dataReader["Title"].ToString();
                    if (dh.HasColumn(dataReader, "Poster"))
                        m.Poster = Convert.ToInt32(dataReader["Poster"]);
                    if (dh.HasColumn(dataReader, "Synopsis"))
                        m.Synopsis = dataReader["Synopsis"].ToString();
                    if (dh.HasColumn(dataReader, "Year"))
                        m.Year = Convert.ToInt32(dataReader["Year"]);
                    if (dh.HasColumn(dataReader, "Duration"))
                        m.Duration = Convert.ToInt32(dataReader["Duration"]);
                    if (dh.HasColumn(dataReader, "Rating"))
                        m.Rating = Convert.ToInt32(dataReader["Rating"]);
                    if (dh.HasColumn(dataReader, "AgeRestriction"))
                        m.AgeRestriction = dataReader["AgeRestriction"].ToString();
                    if (dh.HasColumn(dataReader, "IMDBID"))
                        m.IMDBID = Convert.ToInt32(dataReader["IMDBID"]);

                    m.RecordExists = true;

                    list.Add(m);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                dh.CloseConnection();
            }

            return list;
        }

        internal void LoadItemByFileName(string fileName)
        {
            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT m.* FROM MoviePath mp\n";
q+="JOIN Movies m on mp.movie = m.ID\n";
q+="Where Filename = '" + fileName + "'";

                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(q, dh.connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                Movie m = null;

                while (dataReader.Read())
                {
                    if (dh.HasColumn(dataReader, "ID"))
                        this.ID = Convert.ToInt32(dataReader["ID"]);
                    if (dh.HasColumn(dataReader, "Title"))
                        this.Title = dataReader["Title"].ToString();
                    if (dh.HasColumn(dataReader, "Poster"))
                        this.Poster = Convert.ToInt32(dataReader["Poster"]);
                    if (dh.HasColumn(dataReader, "Synopsis"))
                        this.Synopsis = dataReader["Synopsis"].ToString();
                    if (dh.HasColumn(dataReader, "Year"))
                        this.Year = Convert.ToInt32(dataReader["Year"]);
                    if (dh.HasColumn(dataReader, "Duration"))
                        this.Duration = Convert.ToInt32(dataReader["Duration"]);
                    if (dh.HasColumn(dataReader, "Rating"))
                        this.Rating = Convert.ToInt32(dataReader["Rating"]);
                    if (dh.HasColumn(dataReader, "AgeRestriction"))
                        this.AgeRestriction = dataReader["AgeRestriction"].ToString();
                    if (dh.HasColumn(dataReader, "IMDBID"))
                        this.IMDBID = Convert.ToInt32(dataReader["IMDBID"]);

                    m.RecordExists = true;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                dh.CloseConnection();
            }
        }
    }
}
