using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPlayer.Processors
{
    public class CardCaptureProcessor
    {
        private TempDataGenLib.Business.Cards _card = new TempDataGenLib.Business.Cards();
        public TempDataGenLib.Business.Cards Card
        {
            get { return _card; }
            set { _card = value; }
        }

        private TempDataGenLib.Lists.CardsList _cardsList = new TempDataGenLib.Lists.CardsList();
        public TempDataGenLib.Lists.CardsList CardsList
        {
            get { return _cardsList; }
            set { _cardsList = value; }
        }

        public CardCaptureProcessor()
        {
            _cardsList.GetAll();
        }

        internal void AddCard()
        {
            _cardsList.Add(_card);
        }

        internal void EditCard()
        {
            _cardsList[_cardsList.IndexOf(_cardsList.Find(x => x.ID == _card.ID))] = _card;
        }

        internal void SaveCards()
        {
            _cardsList.UpdateAll();
            _card = new TempDataGenLib.Business.Cards();
        }

        internal void CancelEdit()
        {
            _cardsList.GetAll();
            _card = new TempDataGenLib.Business.Cards();
        }

        internal void DeleteCard(TempDataGenLib.Business.Cards cards)
        {
            _cardsList.Delete(cards);
        }
    }
}
