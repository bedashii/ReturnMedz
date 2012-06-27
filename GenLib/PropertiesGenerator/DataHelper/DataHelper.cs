using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataHelper
{
    public class DataHelper : DataProcessHelper
    {
        public bool CanConnect { get; set; }
        public DataHelper(string connectionString)
        {
            SetConnection(connectionString);
            CanConnect = TestConnection();
        }
    }
}
