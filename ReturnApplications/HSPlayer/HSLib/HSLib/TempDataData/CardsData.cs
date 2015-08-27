using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TempDataGenLib.Properties;
using TempDataGenLib.Lists;

namespace TempDataGenLib.Data
{
    public partial class CardsData : CardsProperties
    {
        internal void LoadAllInOrder(CardsList cardsList)
        {
            PopulateList(cardsList, GetAllInOrderData());
        }

        private DataTable GetAllInOrderData()
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT " + _selectColumnNames);
            sb.AppendLine("FROM    dbo.Cards AS C");
            sb.AppendLine("ORDER BY C.Hero, C.Cost, C.Name");

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(sb.ToString()));
        }
    }
}
