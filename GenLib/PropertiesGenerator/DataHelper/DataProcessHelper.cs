using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/



namespace DataHelper
{
    public enum ExecuteTypes
    {
        NonQuery,
        Scalar,
        Table
    }

    public class UpdateProperties
    {
        public int RowsAffected { get; set; }
        public int Identity { get; set; }
    }

    public class DataProcessHelper
    {
        public static SqlConnection Conn { get; private set; }

        public int MaxRows { get; set; }

        public DataProcessHelper()
        {
        }

        public DataProcessHelper(string connectionString)
        {
            if (Conn == null)
                Conn = new SqlConnection(connectionString);
            else if (Conn.ConnectionString != connectionString)
                SetConnection(connectionString);
        }

        public static void SetConnection(string connectionString)
        {
            Conn = new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                Conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public object ExecuteCommand(ExecuteTypes returnType, SqlCommand cmd)
        {
            switch (returnType)
            {
                case ExecuteTypes.NonQuery:
                    this.ExecuteNonQuery(cmd);
                    return null;
                case ExecuteTypes.Scalar:
                    return this.ExecuteScalar(cmd);
                case ExecuteTypes.Table:
                    return this.ExecuteQuery(cmd);
                default:
                    return null;
            }
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

        public DataTable ExecuteQuery(string query)
        {
            lock (Conn)
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(new SqlCommand(query, Conn));
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

        public object ExecuteScalar(SqlCommand cmd)
        {
            lock (Conn)
            {
                try
                {
                    cmd.Connection.Open();
                    return cmd.ExecuteScalar();
                }
                finally
                {
                    Conn.Close();
                }
            }
        }

        public SqlCommand CreateCommand(string q)
        {
            SqlCommand cmd = new SqlCommand(q, Conn);
            cmd.CommandType = CommandType.Text;
            return cmd;
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

