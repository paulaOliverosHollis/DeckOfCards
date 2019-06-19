﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassPaulita
{
    class Card
    {
        public enum PossibleCardValues { A, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K };       
        public enum PossibleCardSuits { Clubs, Diamond, Hearts, Spades}

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

        public Card( PossibleCardValues cardValue, PossibleCardSuits cardSuit)
        {
            CardValue = cardValue;
            CardSuit = cardSuit;
        }
    }
}
