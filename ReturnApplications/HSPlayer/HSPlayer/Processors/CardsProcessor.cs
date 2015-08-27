using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempDataGenLib.Business;
using TempDataGenLib.Lists;

namespace HSPlayer.Processors
{
    public class CardsProcessor
    {
        private CardsList _cardsList = new CardsList();
        public CardsList CardsList
        {
            get { return _cardsList; }
            set { _cardsList = value; }
        }


        public CardsProcessor()
        {
            Refresh();
        }

        public void Refresh()
        {
            CardsList.GetAllInOrder();
        }
    }
}
