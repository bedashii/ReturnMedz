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
    public class DeckBuilderProcessor
    {
        private HeroesList _heroesList = new HeroesList();
        public HeroesList HeroesList
        {
            get { return _heroesList; }
            set { _heroesList = value; }
        }

        private CardsList _cardsList = new CardsList();
        public CardsList CardsList
        {
            get { return _cardsList; }
            set { _cardsList = value; }
        }

        public DeckBuilderProcessor()
        {
            Refresh();
        }

        private void Refresh()
        {
            _cardsList.GetAll();

            _heroesList.GetAll();
            _heroesList.Remove(_heroesList.Last());
        }
    }
}
