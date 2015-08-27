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

        private HeroesList _heroesList = new HeroesList();
        public HeroesList HeroesList
        {
            get { return _heroesList; }
            set { _heroesList = value; }
        }

        public CardsProcessor()
        {
            Refresh();
        }

        public void Refresh()
        {
            RefreshCardsList();
            RefreshHeroesList();
        }

        private void RefreshCardsList()
        {
            CardsList.Clear();
            CardsList.GetAllInOrder();
        }

        private void RefreshHeroesList()
        {
            HeroesList.Clear();
            HeroesList.GetAll();
            HeroesList.Insert(0, new Heroes() { ID = 0, Name = "All" });
        }

        internal void Save()
        {
            _cardsList.UpdateAll();
        }
    }
}
