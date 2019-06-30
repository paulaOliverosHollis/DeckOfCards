using System;

namespace ClassPaulita
{
    public class GuessTheCardGame
    {
        private string spacing = "\n\t\t\t\t\t\t";

        private bool UserChoseToPlay(char userChoice)
        {
            return userChoice == 'p' || userChoice == 'P';
        }

        private bool UserchoseToSeeInstructions(char userChoice)
        {
            return userChoice == 'i' || userChoice == 'I';
        }

        private bool UserChosetoSeeBoard(char userChoice)
        {
            return userChoice == 'b' || userChoice == 'B';
        }

        private bool UserChoseToQuit(char userChoice)
        {
            return userChoice == 'q' || userChoice == 'Q';
        }

        private bool IsUserChoiceValid(char userChoice)
        {                      

            if (UserChoseToPlay(userChoice) || UserchoseToSeeInstructions(userChoice) || UserChosetoSeeBoard(userChoice) || UserChoseToQuit(userChoice))
            {
                return true;
            }

            return false;
        }

        private char GetUserMenuChoice()
        {

            string menu = $"{spacing}Press P To Play" +
                          $"{spacing}Press I For Instructions" +
                          $"{spacing}Press B To See The High Score Board" +
                          $"{spacing}Press Q To Quit";

            Console.WriteLine(menu);

            char userChoice = Convert.ToChar(Console.ReadLine());

            while (!IsUserChoiceValid(userChoice))
            {
                Console.WriteLine("\n\tOoooops! You pressed an invalid option. Please try again.");

                Console.WriteLine(menu);

                userChoice = Convert.ToChar(Console.ReadLine());
            }

            return userChoice;
        }

        public void Run()
        {
            while (true)
            {
                char userChoice = GetUserMenuChoice();

                if (UserChoseToPlay(userChoice))
                {
                    Play();
                }

                if (UserchoseToSeeInstructions(userChoice))
                {
                    Instructions();
                }

                if (UserChosetoSeeBoard(userChoice))
                {
                    HighScoreBoard();
                }

                if (UserChoseToQuit(userChoice))
                {
                    return;
                }
            }
        }

        private void Play()
        {
            Console.WriteLine($"{spacing}Play!");

            DeckOfCards deck = new DeckOfCards();
            deck.Suffle();

            Card previousCard = deck.Deal();

            int userScore = 0;


            while (deck.CardsLeftOnDeck > 0)
            {
                Card currentCard = deck.Deal();

                char userGuess = GetUserGuess(previousCard);

                if (userGuess == char.ToLower('y') && currentCard.CardValue > previousCard.CardValue || userGuess == char.ToLower('n') && currentCard.CardValue <= previousCard.CardValue)
                {
                    Console.WriteLine($"\n{spacing}Correct! The next card is {currentCard}.");

                    userScore++;

                    Console.WriteLine($"{spacing}Your current score is: {userScore} point(s). Keep it up!");
                }

                else
                {
                    Console.WriteLine($"\n{spacing}Incorrect! The next card was {currentCard}.");

                    Console.WriteLine($"{spacing}Your current score is: {userScore} point(s). Try to get the next one right!");
                }

                previousCard = currentCard;
            }
        }

        private void Instructions()
        {
            Console.WriteLine("PLAY MOTHER FUCKER");
        }

        private void HighScoreBoard()
        {
            Console.WriteLine("PAULA = 1000000000000 POINTS.");
        }

        private bool IsUserGuessValid(char userInput)
        {

            if (userInput == 'y' || userInput == 'Y' || userInput == 'n' || userInput == 'N')
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private char GetUserGuess(Card previousCard)
        {
            Console.Write($"\n\n\tIs the next card greater than {previousCard}(y or n)? ");
            char userGuess = Convert.ToChar(Console.ReadLine());

            while (!IsUserGuessValid(userGuess))
            {
                Console.WriteLine("\n\tYour answer is not valid. Please try again!");
                Console.Write($"\n\n\tIs the next card higher or lower than {previousCard}(y or n)? ");
                userGuess = Convert.ToChar(Console.ReadLine());
            }

            return userGuess;
        }
    }
}
