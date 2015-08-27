using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempDataGenLib.Business
{
    public partial class DeckCards : Data.DeckCardsData
    {
        public string CardName
        {
            get { return CardMember.Name; }
        }

        public short CardCost
        {
            get { return CardMember.Cost; }
        }

        public short CardAttack
        {
            get { return CardMember.Attack; }
        }

        public short CardDuration
        {
            get { return CardMember.Duration; }
        }

        public short CardMinAdditionalDamage
        {
            get { return CardMember.MinAdditionalDamage; }
        }

        public short CardMaxAdditionalDamage
        {
            get { return CardMember.MaxExtraDamage; }
        }

        public short CardAdditionalCost
        {
            get { return CardMember.AdditionalCost; }
        }

        public DeckCards()
        {

        }
        
        /// <summary>
        /// This method can be used to do some preparation work 
        /// before any of the generated contructor do any processing
        /// </summary>
        private void PrepareBeforeConstruction()
        {
        }
    
        /// <summary>
        /// This method can be used to do some finalization work
        /// after the generated contructor did it's processing
        /// </summary>
        private void FinishAfterConstruction()
        {
        }
    }
}
