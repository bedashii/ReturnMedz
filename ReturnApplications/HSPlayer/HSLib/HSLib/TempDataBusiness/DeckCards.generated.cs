using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempDataGenLib.Lists;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace TempDataGenLib.Business
{
    public partial class DeckCards : Data.DeckCardsData
    {
        #region ALL FOREIGN TABLE MEMBERS
        private static CardsList _cardMemberList = new CardsList();
		private Cards _cardMember;
		[System.Xml.Serialization.XmlIgnore]
		public Cards CardMember
		{
		    get
		    {
		        if (_cardMember == null || _cardMember.ID != this.Card)
		            _cardMember = _cardMemberList.GetByPrimaryKey(this.Card);
		        return _cardMember;
		    }
		    set { _cardMember = value; }
		}

		private static DecksList _deckMemberList = new DecksList();
		private Decks _deckMember;
		[System.Xml.Serialization.XmlIgnore]
		public Decks DeckMember
		{
		    get
		    {
		        if (_deckMember == null || _deckMember.ID != this.Deck)
		            _deckMember = _deckMemberList.GetByPrimaryKey(this.Deck);
		        return _deckMember;
		    }
		    set { _deckMember = value; }
		}

		        
        #endregion

        public DeckCards(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public DeckCards(Properties.DeckCardsProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public DeckCards(int deck, int card, byte quantity)
        {
            PrepareBeforeConstruction();
            
			this.Deck = deck;
			this.Card = card;
			this.Quantity = quantity;
			
            FinishAfterConstruction();
        }
        
        public void LoadItem(int iD)
        {
            this.ID = iD;
			
            base.LoadItemData(iD);
        }
        
        
        public void Refresh()
        {
            base.LoadItemData(this.ID);
        }
        
        private void SetProperties(Properties.DeckCardsProperties properties)
        {
            this.ID = properties.ID;
			this.Deck = properties.Deck;
			this.Card = properties.Card;
			this.Quantity = properties.Quantity;
			this.RecordExists = properties.RecordExists;

        }
    }
}
