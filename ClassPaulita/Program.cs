using System;
using System.Collections.Generic;

namespace ClassPaulita
{
    class Program
    {
        static void Main()
        {
            DeckOfCards deckOne = new DeckOfCards();


            //for (int i = 0; i < 52; i++)
            //{
            //    deckOne.Suffle();
            //    Console.WriteLine(deckOne.Deal());
            //}

            foreach (Card card in deckOne.Order())
            {
                Console.WriteLine(card);
            }
        } 
    }
}
