using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace PlusPlayDBGenLib.Data
{
    //public enum ExecuteTypes
    //{
    //    NonQuery,
    //    Scalar,
    //    Table
    //}

    //public class UpdateProperties
    //{
    //    public int RowsAffected { get; set; }
    //    public int Identity { get; set; }
    //}

    //public delegate void DataHelper_XQuery(SqlCeDataReader Reader);

    //public event DataHelper_XQuery XQuery;
    //static bool _isDatabaseAvailable = false;
    //static string _conn = null;

    public class DataHelper
    {
        public SqlCeConnection Conn { get; private set; }
        public static SqlCeTransaction SqlCeTran { get; private set; }
        public static System.Data.SqlClient.SqlTransaction SqlTran { get; private set; }
        private static string _connectionString = null;
        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                    return System.Configuration.ConfigurationManager.AppSettings.Get("PlusPlayDB Connection String");
                else
                    return _connectionString;
            }
        }

        public int MaxRows { get; set; }

        public DataHelper()
        {
            //try
            //{
            //    if (_conn == null)
            //        _conn = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString").ToString();

            //    using (var cn = new SqlCeConnection(_conn))
            //    {
            //        cn.Open();
            //        _isDatabaseAvailable = true;
            //    }
            //}
            //catch (SqlCeException) { _isDatabaseAvailable = false; }
            //catch (Exception) { _isDatabaseAvailable = false; }

            Conn = new SqlCeConnection(ConnectionString);
        }

        public static void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlCeTransaction BeginTransaction()
        {
            Conn.Open();
            SqlCeTran = Conn.BeginTransaction();
            return SqlCeTran;
        }

        public void CommitTransaction()
        {
            try
            {
                SqlCeTran.Commit();
                Conn.Close();
            }
            finally
            {
                SqlCeTran = null;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (SqlCeTran != null)
                    SqlCeTran.Rollback();

                Conn.Close();
            }
            finally
            {
                SqlCeTran = null;
            }
        }

        public object ExecuteCommand(ExecuteTypes returnType, SqlCeCommand cmd)
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

        public System.Data.DataTable ExecuteQuery(SqlCeCommand cmd)
        {
            lock (Conn)
            {
                try
                {
                    var dt = new System.Data.DataTable();
                    SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

                    Conn.Open();
                    da.Fill(dt);

                    return dt;
                }
                finally
                {
                    Conn.Close();
                }
            }
        }

        public int ExecuteNonQuery(SqlCeCommand cmd)
        {
            lock (Conn)
            {
                try
                {
                    if (SqlCeTran == null)
                        cmd.Connection.Open();

                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (SqlCeTran == null)
                        Conn.Close();
                }
            }
        }

        public object ExecuteScalar(SqlCeCommand cmd)
        {
            lock (Conn)
            {
                try
                {
                    if (SqlCeTran == null)
                        cmd.Connection.Open();

                    return cmd.ExecuteScalar();
                }
                finally
                {
                    if (SqlCeTran == null)
                        Conn.Close();
                }
            }
        }

        public UpdateProperties ExecuteAndReturn(SqlCeCommand cmd)
        {
            UpdateProperties up = new UpdateProperties();

            System.Data.DataTable dt = ExecuteQuery(cmd);
            if (dt.Rows[0]["ID"] != DBNull.Value)
                up.Identity = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
            up.RowsAffected = Convert.ToInt32(dt.Rows[0]["RowCount"].ToString());

            return up;
        }

        public SqlCeCommand CreateCommand(string q)
        {
            var cmd = new SqlCeCommand(q);

            if (SqlCeTran != null)
            {
                cmd.Connection = Conn;
                cmd.Transaction = SqlCeTran;
            }
            else
                cmd.Connection = Conn;

            cmd.CommandType = System.Data.CommandType.Text;
            return cmd;
        }

        //public System.Data.SqlClient.SqlCommand CreateCommand(string q)
        //{
        //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(q);

        //    if (SqlTran != null)
        //    {
        //        cmd.Connection = SqlTran.Connection;
        //        cmd.Transaction = SqlTran;
        //    }
        //    else
        //        cmd.Connection = new System.Data.SqlClient.SqlConnection(_connectionString);

        //    cmd.CommandType = System.Data.CommandType.Text;
        //    return cmd;
        //}
    }
}
