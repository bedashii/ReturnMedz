using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempDataGenLib.Properties;

namespace TempDataGenLib.Lists
{
    public partial class CardsList : List<Business.Cards>
    {
        public CardsList()
        {

        }

        public void GetAllInOrder()
        {
            _data.LoadAllInOrder(this);
        }
    }
}