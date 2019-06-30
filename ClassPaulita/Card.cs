using System;
using System.Collections.Generic;
using System.Text;

namespace ClassPaulita
{
   public  class Card
    {
        public enum PossibleCardValues { A, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K };
        public enum PossibleCardSuits { Clubs, Diamonds, Hearts, Spades }

        private PossibleCardValues _cardValue;
        private PossibleCardSuits _cardSuit;

        public PossibleCardValues CardValue
        {
            get
            {
                return _cardValue;
            }

            set
            {
                _cardValue = value;
            }
        }

        public PossibleCardSuits CardSuit
        {
            get
            {
                return _cardSuit;
            }

            set
            {
                _cardSuit = value;
            }
        }

        public Card(PossibleCardValues cardValue, PossibleCardSuits cardSuit)
        {
            CardValue = cardValue;
            CardSuit = cardSuit;
        }

        public override string ToString()
        {
            return CardValue.ToString() + " of " + CardSuit.ToString();
        }        
    }
}
