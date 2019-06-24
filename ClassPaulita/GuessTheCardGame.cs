using System;

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
            Console.WriteLine(deck.Deal());
            Console.Write("Is the next card lower or higher?: ");
            string userInput = Console.ReadLine();
        }

        private void Instructions()
        {
            Console.WriteLine("PLAY MOTHER FUCKER");
        }

        private void HighScoreBoard()
        {
            Console.WriteLine("PAULA = 1000000000000 POINTS.");
        }
    }
}