using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Data
{
    public class UpdateProperties
    {
        public int RowsAffected { get; set; }
        public int Identity { get; set; }
    }

    public class DataHelper
    {
        public static SqlConnection Conn { get; private set; }
        public int MaxRows { get; set; }

        public DataHelper()
        {
            if (Conn == null)
                Conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        }

        //public DataHelper(string connectionString)
        //{
        //    if (Conn == null)
        //        Conn = new SqlConnection(connectionString);
        //}

        public static void SetConnection(string connectionString)
        {
            Conn = new SqlConnection(connectionString);
        }

        public SqlCommand CreateCommand(string q)
        {
            SqlCommand cmd = new SqlCommand(q, Conn);
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        public DataTable ExecuteQuery(SqlCommand cmd)
        {
            lock (Conn)
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                finally
                {
                    Conn.Close();
                }
            }
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            int count = 0;

            lock (Conn)
            {
                try
                {
                    cmd.Connection.Open();
                    count = cmd.ExecuteNonQuery();
                }
                finally
                {
                    Conn.Close();
                }
            }

            return count;
        }

        public UpdateProperties ExecuteAndReturn(SqlCommand cmd)
        {
            UpdateProperties up = new UpdateProperties();

            DataTable dt = ExecuteQuery(cmd);
            if (dt.Rows[0]["ID"] != DBNull.Value)
                up.Identity = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
            up.RowsAffected = Convert.ToInt32(dt.Rows[0]["RowCount"].ToString());

            return up;
        }
    }
}
