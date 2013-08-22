using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace HolisticsCommander.Lib.Data
{
    public delegate void DataHelper_XQuery(SqlCeDataReader Reader);
    public class DataHelper
    {
        public event DataHelper_XQuery XQuery;
        static bool _isDatabaseAvailable = false;
        static string _conn = null;

        public DataHelper()
        {
            try
            {
                if (_conn == null)
                    _conn = System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionString").ToString();

                using (var cn = new SqlCeConnection(_conn))
                {
                    cn.Open();
                    _isDatabaseAvailable = true;
                }
            }
            catch (SqlCeException) { _isDatabaseAvailable = false; }
            catch (Exception) { _isDatabaseAvailable = false; }
        }

        public void ExecuteQuery(SqlCeCommand cmd)
        {
            if (_isDatabaseAvailable)
                try
                {
                    using (var cn = new SqlCeConnection(_conn))
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        XQuery(cmd.ExecuteReader());
                        //return cmd.ExecuteReader();

                    }
                }
                catch (SqlCeException cex)
                {
                    System.Windows.Forms.MessageBox.Show(cex.ToString());
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

            //return null;
        }

        public void ExecuteNonQuery(SqlCeCommand cmd)
        {
            if (_isDatabaseAvailable)
                try
                {
                    using (var cn = new SqlCeConnection(_conn))
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlCeException cex)
                {
                    System.Windows.Forms.MessageBox.Show(cex.ToString());
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
        }
    }
}
