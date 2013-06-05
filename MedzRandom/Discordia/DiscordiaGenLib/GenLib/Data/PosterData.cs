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
    public class PosterData : PosterProperties
    {
        DataHelper dh = new DataHelper();

        public PosterData()
        {
            dh.InitializeDB();
        }

        internal void Insert()
        {
            string q = "Insert INTO Posters(Movie,URL,Path, Width,Height)\n";
            q += "VALUES(" + Movie + ",'" + URL + "','" + Path + "'," + Width + "," + Height + ")";

            this.RecordExists = true;

            dh.ExecuteNonQuery(q);
        }

        internal void Update()
        {
            string q = "UPDATE Posters\n";
            q += "SET Movie = '" + Movie + "',\n";
            q += "URL = '" + URL + "',\n";
            q += "Path = '" + Path + "',\n";
            q += "Width = " + Width + ",\n";
            q += "Height = " + Height + "\n";
            q += "WHERE ROWID = " + ID;

            dh.ExecuteNonQuery(q);

            this.AnyPropertiesChanged = false;
        }

        internal void Delete()
        {
            string q = "DELETE FROM Posters\n";
            q += "WHERE ROWID = " + ID;

            dh.ExecuteNonQuery(q);
        }

        internal void LoadItemByMovie(int movie)
        {
            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT TOP 1 ROWID,Movie,URL,Path, Width,Height FROM Posters p\n";
                q += "Where p.Movie = " + movie;

                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(q, dh.connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    if (dh.HasColumn(dataReader, "ROWID"))
                        this.ID = Convert.ToInt32(dataReader["ROWID"]);
                    if (dh.HasColumn(dataReader, "Movie"))
                        this.Movie = Convert.ToInt32(dataReader["Movie"]);
                    if (dh.HasColumn(dataReader, "URL"))
                        this.URL = dataReader["URL"].ToString();
                    if (dh.HasColumn(dataReader, "Path"))
                        this.Path = dataReader["Path"].ToString();
                    if (dh.HasColumn(dataReader, "Width"))
                        this.Width = Convert.ToInt32(dataReader["Width"]);
                    if (dh.HasColumn(dataReader, "Height"))
                        this.Height = Convert.ToInt32(dataReader["Height"]);

                    this.RecordExists = true;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                dh.CloseConnection();
            }
        }

        internal void GetByMovie(int movie, Lists.PosterList posterList)
        {
            //Open connection
            if (dh.OpenConnection() == true)
            {
                string q = "SELECT ROWID,Movie,URL,Path, Width,Height FROM Posters p\n";
                q += "Where p.Movie = " + movie;

                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(q, dh.connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                posterList.Clear();

                while (dataReader.Read())
                {
                    Poster poster = new Poster();

                    if (dh.HasColumn(dataReader, "ROWID"))
                        poster.ID = Convert.ToInt32(dataReader["ROWID"]);
                    if (dh.HasColumn(dataReader, "Movie"))
                        poster.Movie = Convert.ToInt32(dataReader["Movie"]);
                    if (dh.HasColumn(dataReader, "URL"))
                        poster.URL = dataReader["URL"].ToString();
                    if (dh.HasColumn(dataReader, "Path"))
                        poster.Path = dataReader["Path"].ToString();
                    if (dh.HasColumn(dataReader, "Width"))
                        this.Width = Convert.ToInt32(dataReader["Width"]);
                    if (dh.HasColumn(dataReader, "Height"))
                        this.Height = Convert.ToInt32(dataReader["Height"]);


                    poster.RecordExists = true;

                    posterList.Add(poster);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                dh.CloseConnection();
            }
        }
    }
}
