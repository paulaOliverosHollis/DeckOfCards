using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassPaulita
{
    public class DeckOfCards
    {
        private List<Card> _unusedCards;
        private List<Card> _discardedCards;
        private Random random = new Random();

        public int CardsLeftOnDeck
        {
            get
            {
                return _unusedCards.Count;
            }
        }

        //Constructor:
        public DeckOfCards()
        {
            _unusedCards = new List<Card>();
            _discardedCards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card currentCard = new Card((Card.PossibleCardValues)j, (Card.PossibleCardSuits)i);
                    _unusedCards.Add(currentCard);
                }
            }
        }

        // Put all the elements in the discardedCards list that way we can sort all the cards in random order into the unusedCards list one by one.
        public void Suffle()
        {
            _discardedCards.AddRange(_unusedCards);
            _unusedCards.Clear();

            while (_discardedCards.Count > 0)
            {
                int randomIndex = random.Next(0, _discardedCards.Count - 1);
                _unusedCards.Add(_discardedCards[randomIndex]);
                _discardedCards.Remove(_discardedCards[randomIndex]);
            }

        }

        public Card Deal()
        {
            if (_unusedCards.Count > 0)
            {
                Card topCard = _unusedCards[0];
                _discardedCards.Add(topCard);
                _unusedCards.RemoveAt(0);

                return topCard;
            }

            return null;
        }

        public List<Card> Order()
        {
            _unusedCards.AddRange(_discardedCards);

            _unusedCards.Sort((x, y) => x.CardValue.CompareTo(y.CardValue));

            return _unusedCards;
        }

        ////public List<Card> Order()
        //{
        //    _discardedCards.AddRange(_unusedCards);
        //    _unusedCards.Clear();

        //    _unusedCards = _discardedCards.OrderBy(o => o.CardValue).ToList();

        //    return _unusedCards;                        
        //}        
    }
}
