using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PlusPlayDBGenLib.Properties;

namespace PlusPlayDBGenLib.Data
{
    public partial class GalleriesData : GalleriesProperties
    {

        internal void LoadByModel(Lists.GalleriesList list, int model)
        {
            PopulateList(list, this.GetDataByModel(model));
        }

        private DataTable GetDataByModel(int model)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM Galleries AS G\n";
            q += "WHERE Model = " + model;
            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }
    }
}
