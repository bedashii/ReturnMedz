using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/



namespace PlusPlayDBGenLib.Data
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
        public SqlConnection Conn { get; private set; }
        public static SqlTransaction SqlTran { get; private set; }
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

        public DataProcessHelper()
        {
            Conn = new SqlConnection(ConnectionString);
        }

        public static void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlTransaction BeginTransaction()
        {
            Conn.Open();
            SqlTran = Conn.BeginTransaction();
            return SqlTran;
        }

        public void CommitTransaction()
        {
            try
            {
                SqlTran.Commit();
                Conn.Close();
            }
            finally
            {
                SqlTran = null;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (SqlTran != null)
                    SqlTran.Rollback();

                Conn.Close();
            }
            finally
            {
                SqlTran = null;
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
            lock(Conn)
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
                    if (SqlTran == null)
                        Conn.Close();
                }
            }
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            lock (Conn)
            {
                try
                {
                    if(SqlTran == null)
                        cmd.Connection.Open();

                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    if (SqlTran == null)
                        Conn.Close();
                }
            }
        }
        
        public object ExecuteScalar(SqlCommand cmd)
        {
            lock(Conn)
            {
                try
                {
                    if (SqlTran == null)
                        cmd.Connection.Open();

                    return cmd.ExecuteScalar();
                }
                finally
                {
                    if (SqlTran == null)
                        Conn.Close();
                }
            }
        }
        
        public SqlCommand CreateCommand(string q)
        {
            SqlCommand cmd = new SqlCommand(q);

            if (SqlTran != null)
            {
                cmd.Connection = SqlTran.Connection;
                cmd.Transaction = SqlTran;
            }
            else
                cmd.Connection = Conn;

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

        public static void ClearConnectionPools(Exception ex)
        {
            try
            {
                if (ex.GetType() == typeof(ArgumentException))
                {
                    if (ex.ToString().Contains("does not belong to table"))
                        System.Data.SqlClient.SqlConnection.ClearAllPools();
                }
            }
            catch (Exception)
            {
            }
        }
        
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.PropertyType.IsSerializable)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    if (prop.PropertyType.IsSerializable)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;

        }
    }
}

