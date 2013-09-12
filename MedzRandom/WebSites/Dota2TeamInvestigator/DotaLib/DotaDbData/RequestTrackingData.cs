using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class RequestTrackingData : RequestTrackingProperties
    {
        protected void GetByRequest(string request)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.RequestTracking R\n";
            q += "WHERE R.Request = @Request\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Request", SqlDbType.VarChar).Value = request;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
    }
}
