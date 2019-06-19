using System;
using System.Collections.Generic;
using System.Text;

namespace ClassPaulita
{
    class DeckOfCards
    {
        private List<Card> _unusedCards;
        private List<Card> _discardedCards;
        private Random _random;

        public DeckOfCards() // Declare new lists.
        {
            for (int i = 0; i > 4; i++)
            {
                for (int j = 0; j > 14; j++)
                {
                    Card currentCard = new Card((Card.PossibleCardValues)j, (Card.PossibleCardSuits)i);
                    _unusedCards.Add(currentCard);
                }
            }
        }

        // Put all the elements in the discardedCards list that way we can sort all the cards in random order into the unusedCards list one by one.
        public List<Card> Suffle()
        {
            _discardedCards.AddRange(_unusedCards);
            _unusedCards.Clear();

            while(_discardedCards.Count > 0)
            {
                int randomIndex = _random.Next(0, _discardedCards.Count - 1);
                _unusedCards.Add(_discardedCards[randomIndex]);
                _discardedCards.Remove(_discardedCards[randomIndex]);
            }

            return _unusedCards;
        }
        
        public Card Deal()
        {
            Card topCard = _unusedCards[0];
            _discardedCards.Add(_unusedCards[0]);
            _unusedCards.Remove(_unusedCards[0]);

            return topCard;
        }

        public List<Card> Order()
        {
            _unusedCards.AddRange(_discardedCards);

            _unusedCards.Sort();

            return _unusedCards;
        }
    }
}
