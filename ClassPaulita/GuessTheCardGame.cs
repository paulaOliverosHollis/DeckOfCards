using System;

public class GuessTheCardGame
{  
    private bool IsValidInput(string input)
    {
        if (input == null || input.Length < 1)
            return false;

        char choice = input[0];

        // if user chose to play.
        if (choice == 'p' || choice == 'P')
        {
            return true;
        }

        // if user chose to read the instructions.
        if (choice == 'i' || choice == 'I')
        {
            return true;
        }

        // if user chose to see the score board.
        if (choice == 'b' || choice == 'B')
        {
            return true;
        }

        // if user chose to quit.
        if (choice == 'q' || choice == 'Q')
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

            if (userChoice[0] == 'p' || userChoice[0] == 'P')
            {
                Play();
            }

            if (userChoice[0] == 'i' || userChoice[0] == 'I')
            {
                Instructions();
            }

            if (userChoice[0] == 'b' || userChoice[0] == 'B')
            {
                HighScoreBoard();
            }

            if (userChoice[0] == 'q' || userChoice[0] == 'Q')
            {
                return;
            }
        }
    }

    private void Play()
    {
        Console.WriteLine("PLAYING");
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
