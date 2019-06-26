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

        private bool IsUserChoiceValid(string input)
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

            string menu = $"{spacing}Press P To Play" +
                          $"{spacing}Press I For Instructions" +
                          $"{spacing}Press B To See The High Score Board" +
                          $"{spacing}Press Q To Quit";

            Console.WriteLine(menu);

            string userChoice = Console.ReadLine();

            while (!IsUserChoiceValid(userChoice))
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
            Console.WriteLine($"{spacing}Play!");

            DeckOfCards deck = new DeckOfCards();
            deck.Suffle();

            Card previousCard = deck.Deal();

            int userScore = 0;


            while (deck.CardsLeftOnDeck > 0)
            {
                Card currentCard = deck.Deal();

                char userInput = GetUserInput(previousCard);

                if (currentCard.CardValue > previousCard.CardValue && userInput == char.ToLower('y') || currentCard.CardValue == previousCard.CardValue && userInput == char.ToLower('n')
                    || currentCard.CardValue < previousCard.CardValue && userInput == char.ToLower('n'))
                {
                    Console.WriteLine($"\n{spacing}Correct! The next card is {currentCard}.");

                    userScore++;

                    Console.WriteLine($"{spacing}Your current score is: {userScore} points. Keep it up!");
                }

                else
                {
                    Console.WriteLine($"\n{spacing}Incorrect! The next card was {currentCard}.");

                    Console.WriteLine($"{spacing}Your current score is: {userScore} points. Try to get the next one right!");
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

        private bool IsUserInputValid(char userInput)
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

        private char GetUserInput(Card previousCard)
        {
            Console.Write($"\n\n\tIs the next card greater than {previousCard}(y or n)? ");
            char userInput = Convert.ToChar(Console.ReadLine());

            while (!IsUserInputValid(userInput))
            {
                Console.WriteLine("\n\tYour answer is not valid. Please try again!");
                Console.Write($"\n\n\tIs the next card higher or lower than {previousCard}(y or n)? ");
                userInput = Convert.ToChar(Console.ReadLine());
            }

            return userInput;
        }
    }
}
