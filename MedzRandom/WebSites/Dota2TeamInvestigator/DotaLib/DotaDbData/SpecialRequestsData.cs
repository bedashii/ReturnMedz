using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Lists;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Data
{
    public partial class SpecialRequestsData : SpecialRequestsProperties
    {
        public void GetSpecialRequest(SpecialRequestsList list)
        {
            string q = "SELECT TOP 1";
            q += _selectColumnNames + "\n";
            q += "FROM SpecialRequests AS S\n";
            q += "WHERE DateResponded IS NULL\n";
            q += "ORDER BY DateRequested ASC";

            PopulateList(list, dataHelper.ExecuteQuery(dataHelper.CreateCommand(q)));
        }
    }
}
