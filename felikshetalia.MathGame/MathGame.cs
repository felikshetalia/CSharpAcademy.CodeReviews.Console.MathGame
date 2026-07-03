using System;
using System.Linq;
namespace MathGame
{
    internal class MathGame
    {
        // game history is a whole formatted string
        protected List<string> gameHistory;
        public MathGame() => gameHistory = new();

        public void NewGame(string readLine)
        {
            // WARNING: this game operates only with integers
            int score = 0;
            int minQuestions = 5;
            // stopping condition: you answer wrong 3 times and game ends
            int wrongAnswers = 0;
            int maxNumber = 11;

            char[] operations = { '+', '-', '*', '/' };

            var rnd = new Random();

            string writtenMessage = null;

            // in the game loop you should get an operator at a random index

            // get at least 5 questions

            // apply the stopping condition
            // if you have 3 wrong answers before you've answered 5 questions, the game ends after the 5th question

            gameHistory.Add($"Game {DateTime.Now}");
            int i = 1;
            while (i <= minQuestions || wrongAnswers < 3)
            {
                writtenMessage = $"{i}.";
                System.Console.WriteLine(writtenMessage);
                gameHistory[gameHistory.Count - 1] += $"\n{writtenMessage}";

                int first = rnd.Next(1, maxNumber);
                int second = rnd.Next(1, maxNumber);
                var op = operations[rnd.Next(operations.Length)];

                int correctAnswer;

                switch (op)
                {
                    case '+':
                        correctAnswer = first + second;
                        break;
                    case '-':
                        correctAnswer = first - second;
                        break;
                    case '*':
                        correctAnswer = first * second;
                        break;
                    case '/':
                        // first < second - always a fraction
                        if (first < second)
                            first = rnd.Next(second, maxNumber);
                        while (first % second != 0)
                        {
                            second = rnd.Next(1, first + 1);
                        }
                        correctAnswer = first / second;
                        break;
                    default:
                        correctAnswer = 0;
                        break;
                }

                // now user's turn
                writtenMessage = $"{first} {op} {second} = ";
                System.Console.Write(writtenMessage);
                gameHistory[gameHistory.Count - 1] += $"\n{writtenMessage}";

                readLine = Console.ReadLine();
                int userAnswer;

                if (readLine != null)
                {
                    gameHistory[gameHistory.Count - 1] += $"\n{readLine}";

                    if (int.TryParse(readLine, out userAnswer))
                    {
                        if (userAnswer == correctAnswer)
                        {
                            score++;
                            writtenMessage = "Correct.";
                        }
                        else
                        {
                            wrongAnswers++;
                            writtenMessage = "Nope";
                        }

                    }
                    else
                    {
                        writtenMessage = "The answer should be a number don't you think?";
                    }
                    System.Console.WriteLine(writtenMessage);
                    gameHistory[gameHistory.Count - 1] += $"\n{writtenMessage}";
                    i++;
                }
            }
            writtenMessage = $"Game over. You have scored {score} points\n\n";
            System.Console.WriteLine(writtenMessage);
            gameHistory[gameHistory.Count - 1] += $"\n{writtenMessage}";
        }

        public void DisplayHistory(string readLine)
        {
            Console.WriteLine("Choose a game you want to display by the number in the list\n");
            for (int i = 1; i <= gameHistory.Count; i++)
            {
                Console.WriteLine($"{i}. {gameHistory[i - 1].Substring(0, DateTime.Now.ToString().Length)}");

            }
            Console.WriteLine();
            readLine = Console.ReadLine();
            int indexOfGame;
            if (readLine != null)
            {

                if (int.TryParse(readLine, out indexOfGame))
                {
                    Console.WriteLine(gameHistory[indexOfGame - 1]);
                }
            }
        }
        public void StartGame()
        {
            // the main game that will start the loop with main menu
            string lineRead; // the user input to console

            while (true)
            {
                Console.WriteLine("Welcome to Math game!\nSelect an option to load the history of games or start a new game.\n");
                System.Console.WriteLine("1. New game\n2. History");
                System.Console.WriteLine("\nType \"Bye\" to exit the game");

                lineRead = Console.ReadLine();
                if (lineRead != null)
                {
                    switch (lineRead?.Trim().ToLower())
                    {
                        case "bye":
                            return;
                        case "1":
                            Console.WriteLine("Starting a new game");
                            NewGame(lineRead);
                            break;
                        case "2":
                            DisplayHistory(lineRead);
                            break;
                        default:
                            continue;
                    }

                }
            }
        }
    }
}