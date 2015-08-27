using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempDataGenLib;
using TempDataGenLib.Business;
using TempDataGenLib.Lists;

namespace HSPlayer.Processors
{
    public class DecksProcessor
    {
        private DecksList _decksList = new DecksList();
        public DecksList DecksList
        {
            get { return _decksList; }
            set { _decksList = value; }
        }

        private DeckCardsList _deckCardsList = new DeckCardsList();
        public DeckCardsList DeckCardsList
        {
            get { return _deckCardsList; }
            set { _deckCardsList = value; }
        }

        public DecksProcessor()
        {
            Refresh();
        }

        private void Refresh()
        {
            _decksList.GetAll();
            _deckCardsList.GetAll();
        }
    }
}
