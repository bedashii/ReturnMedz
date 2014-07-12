using DiscordiaGenLib.GenLib.Data;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordia
{
    public class StartUp : DataHelper
    {
        public StartUp()
        {
            // Link To Database
            InitializeDB();

            // Create Primary Tables
            CreateSystemConfig();
            CreateMoviesTable();
            CreateActorsTable();
            CreateGenreTable();
            CreatePostersTable();
            CreateDirectorsTable();
            CreateWritersTable();

            // Create Linking Tables
            CreateMoviePath();
        }

        private void CreateMoviePath()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS MoviePath\n";
                q += "(\n";
                q += "Movie INT NOT NULL,\n";
                q += "Path VARCHAR(255),\n";
                q += "Filename VARCHAR(255)\n";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreateMoviesTable()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS Movies\n";
                q += "(\n";
                q += "Title VARCHAR(50) NOT NULL,\n";
                q += "Synopsis TEXT NULL,\n";
                q += "Year INT NULL,\n";
                q += "Duration INT NULL,\n";
                q += "Rating DOUBLE NULL,\n";
                q += "AgeRestriction VARCHAR(10),\n";
                q += "TMDBID INT";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreatePostersTable()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS Posters\n";
                q += "(\n";
                q += "Movie Path NOT NULL,\n";
                q += "URL VARCHAR NULL,\n";
                q += "Path VARCHAR NULL,\n";
                q += "Width INT NULL,\n";
                q += "Height INT NULL\n";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreateActorsTable()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS Actors\n";
                q += "(\n";
                q += "Name VARCHAR(50) NOT NULL,\n";
                q += "PicturePath VARCHAR(255) NULL,\n";
                q += "BIO TEXT NULL";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreateGenreTable()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS Genres\n";
                q += "(\n";
                q += "Name VARCHAR(50)";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreateDirectorsTable()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS Directors\n";
                q += "(\n";
                q += "Name VARCHAR(50),\n";
                q += "PicturePath  VARCHAR(255)";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreateWritersTable()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS Writers\n";
                q += "(\n";
                q += "NAME VARCHAR(50),\n";
                q += "PicturePath VARCHAR(255)";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public void CreateSystemConfig()
        {
            //open connection
            if (OpenConnection() == true)
            {
                string q = "CREATE TABLE IF NOT EXISTS SystemConfig\n";
                q += "(\n";
                q += "ConfigKey VARCHAR(50) NOT NULL,\n";
                q += "ConfigValue VARCHAR(255)";
                q += ");";

                //create command and assign the query and connection from the constructor
                SQLiteCommand cmd = new SQLiteCommand(q, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }
    }
}
