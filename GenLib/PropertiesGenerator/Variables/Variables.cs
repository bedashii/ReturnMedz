using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Variable
{
    public class VariablesList : List<Variables>
    {
        //private DataHelper.DataHelper _dataHelper;

        //public void GetFromTable(string connectionString, string tableName)
        //{
        //    if (_dataHelper == null)
        //        _dataHelper = new DataHelper.DataHelper(connectionString);

        //    string q = "";

        //    SqlCommand cmd = _dataHelper.CreateCommand(q);

        //    DataTable dt = _dataHelper.ExecuteQuery(cmd);
        //}
    }

    public class Variables
    {
        public Variables()
        {
        }

        public Variables(string name, string sqlType, string cSharpType, int variableSize, bool allowNulls)
        {
            Name = name;
            SQLType = sqlType;
            CSharpType = cSharpType;
            VariableSize = variableSize;
            AllowNulls = allowNulls;
        }



        public string Name { get; set; }
        public string SQLType { get; set; }
        public string CSharpType { get; set; }
        public int VariableSize { get; set; }
        public bool AllowNulls { get; set; }

    }
}
