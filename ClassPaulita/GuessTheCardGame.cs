using System;
using System.Collections.Generic;
using System.IO;

namespace ClassPaulita
{
    public class GuessTheCardGame
    {
        private string _fileName = "scoreBoard.txt";
        private List<KeyValuePair<int, string>> _scoreBoard = new List<KeyValuePair<int, string>>();
        private Random _random = new Random();
        private string _spacing = "\n\t\t\t\t\t\t";

        public GuessTheCardGame()
        {
            try
            {               
                if (File.Exists(_fileName))
                {
                    StreamReader reader = File.OpenText(_fileName);

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] scoreAndName = line.Split(' ');

                        if (scoreAndName.Length == 2)
                        {
                            bool isItConvertible = int.TryParse(scoreAndName[0], out int result);

                            if (isItConvertible && !string.IsNullOrWhiteSpace(scoreAndName[1]))
                            {
                                _scoreBoard.Add(new KeyValuePair<int, string>(result, scoreAndName[1]));
                            }
                        }

                        line = reader.ReadLine();
                    }

                    reader.Close();
                }
                else
                {
                    File.Create(_fileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nSomething went wrong. The following error was generated: {e.Message} Please exit the game and try again.");
            }            

            List<string> extraNames = new List<string> { "Blondie", "Oreo", "Mini", "Ginger", "Shawnikua", "Trooper", "Maui", "Ferguson" };

            while (_scoreBoard.Count < 5)
            {
                int randomNameIndex = _random.Next(extraNames.Count - 1);

                int randomScore = _random.Next(7);
                _scoreBoard.Add(new KeyValuePair<int, string>(randomScore, extraNames[randomNameIndex]));

                extraNames.Remove(extraNames[randomNameIndex]);
            }

            _scoreBoard.Sort((x, y) => y.Key.CompareTo(x.Key));
        }

        private bool IsUserChoiceValid(string userChoice)
        {
            if (userChoice == null || userChoice.Length > 1)
            {
                return false;
            }
            else if (UserChoseToPlay(userChoice[0]) || UserchoseToSeeInstructions(userChoice[0]) || UserChosetoSeeBoard(userChoice[0]) || UserChoseToQuit(userChoice[0]))
            {
                return true;
            }

            return false;
        }

        private bool IsUserGuessValid(string userGuess)
        {
            if(userGuess == null || userGuess.Length > 1 )
            {
                return false;
            }
            if (userGuess[0] == 'y' || userGuess[0] == 'Y' || userGuess[0] == 'n' || userGuess[0] == 'N')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsUserNameValid(string userName)
        {
            if (userName == null || userName.Length > 10)
            {
                return false;
            }

            for (int i = 0; i < userName.Length; i++)
            {
                if (!char.IsLetterOrDigit(userName[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private char GetUserMenuChoice()
        {

            string menu = $"{_spacing}Press P To Play" +
                          $"{_spacing}Press I For Instructions" +
                          $"{_spacing}Press B To See The High Score Board" +
                          $"{_spacing}Press Q To Quit";

            Console.WriteLine(menu);

            string userChoice = Console.ReadLine();

            while (!IsUserChoiceValid(userChoice))
            {
                Console.WriteLine("\n\tOoooops! You pressed an invalid option. Please try again.");

                Console.WriteLine(menu);

                userChoice = Console.ReadLine();
            }

            return userChoice[0];
        }

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

        private char GetUserGuess(Card previousCard)
        {
            Console.Write($"\n\n\tIs the next card greater than {previousCard}(y or n)? ");
            string userGuess = Console.ReadLine();

            while (!IsUserGuessValid(userGuess))
            {
                Console.WriteLine("\n\tYour answer is not valid. Please try again!");
                Console.Write($"\n\n\tIs the next card higher or lower than {previousCard}(y or n)? ");
                userGuess = Console.ReadLine();
            }

            return userGuess[0];
        }

        private void AddUserScoreToBoard(int userScore)
        {
            Console.WriteLine($"Congratulations! You made it to the Leader Board.\n{_spacing}Please enter your userName (10 characters max):\n\n{_spacing}");
            string userName = Console.ReadLine();

            while (!IsUserNameValid(userName))
            {
                Console.WriteLine($"\n{_spacing}You entered an invalid name. Please try again.\n{_spacing}Please enter your userName (10 characters max):\n\n{_spacing}");
                userName = Console.ReadLine();
            }

            _scoreBoard.Add(new KeyValuePair<int, string>(userScore, userName));

            _scoreBoard.Sort((x, y) => y.Key.CompareTo(x.Key));

            if (_scoreBoard.Count > 5)
            {
                while (_scoreBoard.Count > 5)
                {
                    _scoreBoard.RemoveAt(_scoreBoard.Count - 1);
                }
            }
        }

        private void UpdateScoreBoardFile()
        {
            StreamWriter writer = new StreamWriter(_fileName);

            foreach (var item in _scoreBoard)
            {
                writer.WriteLine(item);
            }

            writer.Close();
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
            Console.WriteLine($"{_spacing}Let's Play!");

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
                    Console.WriteLine($"\n{_spacing}Correct! The next card is {currentCard}.");

                    userScore++;

                    Console.WriteLine($"{_spacing}Your current score is: {userScore} point(s). Keep it up!");
                }

                else
                {
                    Console.WriteLine($"\n{_spacing}Incorrect! The next card was {currentCard}.");

                    Console.WriteLine($"{_spacing}Your current score is: {userScore} point(s). Try to get the next one right!");
                }

                previousCard = currentCard;
            }

            if (userScore > _scoreBoard[4].Key)
            {
                AddUserScoreToBoard(userScore);
            }
            else
            {
                Console.WriteLine("Sorry! You did not make it to the LeaderBoard. Keep trying!");
            }

            UpdateScoreBoardFile();
        }

        private void Instructions()
        {
            Console.WriteLine("PLAY MOTHER FUCKER");
        }

        private void HighScoreBoard()
        {
            Console.WriteLine($"\n\t\t\t\t****** Guess The Card LeaderBoard ******\n");

            foreach (var s in _scoreBoard)
            {
                Console.WriteLine($"{_spacing}* {s.Value} *");
                Console.WriteLine($"{_spacing}{s.Key} point(s)\n\n");
            }
        }
    }
}
