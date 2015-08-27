using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace TempDataGenLib.Properties
{
    public partial class DeckCardsProperties : PropertiesBase
    {
		partial void OnIDChanging();
		partial void OnIDChanged();
		protected int _iD;
		public virtual int ID
		{
			get { return _iD; }
			set
			{
				OnIDChanging();
				_iD = value;
				base.AnyPropertyChanged = true;
				OnIDChanged();
			}
		}

		partial void OnDeckChanging();
		partial void OnDeckChanged();
		protected int _deck;
		public virtual int Deck
		{
			get { return _deck; }
			set
			{
				OnDeckChanging();
				_deck = value;
				base.AnyPropertyChanged = true;
				OnDeckChanged();
			}
		}

		partial void OnCardChanging();
		partial void OnCardChanged();
		protected int _card;
		public virtual int Card
		{
			get { return _card; }
			set
			{
				OnCardChanging();
				_card = value;
				base.AnyPropertyChanged = true;
				OnCardChanged();
			}
		}

		partial void OnQuantityChanging();
		partial void OnQuantityChanged();
		protected byte _quantity;
		public virtual byte Quantity
		{
			get { return _quantity; }
			set
			{
				OnQuantityChanging();
				_quantity = value;
				base.AnyPropertyChanged = true;
				OnQuantityChanged();
			}
		}

    }
}