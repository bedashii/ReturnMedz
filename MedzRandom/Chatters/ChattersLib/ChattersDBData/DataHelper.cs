using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattersLib.ChattersDBData
{
    public class DataHelper
    {
        private System.Data.OleDb.OleDbConnection conn = null;

        public DataHelper()
        {
            SetConnectionString("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\Rian\\Documents\\GitHub\\ReturnMedz\\MedzRandom\\Chatters\\Database\\ChattersDB.accdb");
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