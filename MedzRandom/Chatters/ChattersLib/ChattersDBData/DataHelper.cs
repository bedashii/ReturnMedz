using System;
using System.Data;
using System.Linq;

namespace ChattersLib.ChattersDBData
{
    public class DataHelper
    {
        private System.Data.OleDb.OleDbConnection conn;

        public DataHelper()
        {
            //System.Configuration.ConfigurationManager
            string path;
            if (System.Configuration.ConfigurationSettings.AppSettings != null &&
                System.Configuration.ConfigurationSettings.AppSettings.Get("DataSourcePath") != null)
                path = @System.Configuration.ConfigurationSettings.AppSettings.GetValues("DataSourcePath").First();
            else throw new ApplicationException("Please set the DataBase Path in the web.Config file.");
            SetConnectionString("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path);
        }

        public DataHelper(string connectionString)
        {
            SetConnectionString(connectionString);
        }

        public void SetConnectionString(string connectionString)
        {
            conn = new System.Data.OleDb.OleDbConnection(connectionString);
        }

        internal DataTable ExecuteReader(System.Data.OleDb.OleDbCommand cmd)
        {
            try
            {
                cmd.Connection = conn;

                conn.Open();

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            finally
            {
                conn.Close();
            }
        }

        internal void ExecuteNonReader(System.Data.OleDb.OleDbCommand cmd)
        {
            try
            {
                cmd.Connection = conn;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}