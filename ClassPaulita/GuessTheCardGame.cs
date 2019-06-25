using System;

namespace ClassPaulita
{
    public class GuessTheCardGame
    {

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

        private bool IsValidInput(string input)
        {
            if (input == null || input.Length < 1)
                return false;

            char userChoice = input[0];

            if (UserChoseToPlay(userChoice) || UserchoseToSeeInstructions(userChoice) || UserChosetoSeeBoard(userChoice) || UserChoseToQuit(userChoice))
            {
                return true;
            }

            return false;
        }

        private string PrintMenu()
        {
            string spacing = "\n\t\t\t\t\t\t";

            string menu = $"{spacing}Press P To Play" +
                          $"{spacing}Press I For Instructions" +
                          $"{spacing}Press B To See The High Score Board" +
                          $"{spacing}Press Q To Quit";

            Console.WriteLine(menu);

            string userChoice = Console.ReadLine();

            while (!IsValidInput(userChoice))
            {
                Console.WriteLine("\n\tOoooops! You pressed an invalid option. Please try again.");

                Console.WriteLine(menu);

                userChoice = Console.ReadLine();
            }

            return userChoice;
        }

        public void Run()
        {
            while (true)
            {
                string userChoice = PrintMenu();

                if (UserChoseToPlay(userChoice[0]))
                {
                    Play();
                }

                if (UserchoseToSeeInstructions(userChoice[0]))
                {
                    Instructions();
                }

                if (UserChosetoSeeBoard(userChoice[0]))
                {
                    HighScoreBoard();
                }

                if (UserChoseToQuit(userChoice[0]))
                {
                    return;
                }
            }
        }

        private void Play()
        {
            DeckOfCards deck = new DeckOfCards();
            deck.Suffle();

            Card previousCard = deck.Deal();
            

            while (deck.CardsLeftOnDeck > 0)
            {
                Card currentCard = deck.Deal();

                char userInput = GetUserInput(previousCard);

                if (previousCard.CardValue > currentCard.CardValue && userInput == '1')
                {
                    Console.WriteLine("Correct!");
                }
                else if (previousCard.CardValue < currentCard.CardValue && userInput == '2')
                {
                    Console.WriteLine("Correct!");
                }

                else
                {
                    Console.WriteLine("Incorrect!");
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

        private bool IsInputValid(string userInput)
        {
            if (userInput.Length < 1 || userInput == null)
            {
                return false;
            }

            else if (userInput[0] == '1' || userInput[0] == '2')
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private char GetUserInput(Card previousCard)
        {
            Console.WriteLine($"\nIs the next card higher or lower than {previousCard}?");
            string userInput = Console.ReadLine();

            while (!IsInputValid(userInput))
            {
                Console.WriteLine("Your answer is not valid. Please try again!");
                Console.WriteLine($"Is the next card higher or lower than {previousCard}?");
                userInput = Console.ReadLine();
            }

            return userInput[0];
        }
    }
}
