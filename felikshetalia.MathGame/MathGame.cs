using System;
using System.Linq;
namespace MathGame
{
    internal class MathGame
    {
        // game history is a whole formatted string
        protected List<string> gameHistory;
        public MathGame() => gameHistory = new();

        // New game comes with 5 different options:
        // +, -, *, /, and randomized

        public void NewGame(string readLine)
        {
            // WARNING: this game operates only with integers
            int score = 0;
            int minQuestions = 5;
            int maxNumber = 101;

            char[] operations = { '+', '-', '*', '/' };
            var rnd = new Random();
            char op = operations[rnd.Next(operations.Length)];

            string writtenMessage = null;

            // user selects a game mode
            System.Console.WriteLine("1. Get a random game\n2. Adding game\n3. Subtracting game\n4. Multiplication game\n5. Division game\n");

            readLine = Console.ReadLine(); // read game mode
            if (readLine != null)
            {
                switch (readLine)
                {
                    case "1":
                        op = operations[rnd.Next(operations.Length)];
                        break;
                    case "2":
                        op = '+';
                        break;
                    case "3":
                        op = '-';
                        break;
                    case "4":
                        op = '*';
                        break;
                    case "5":
                        op = '/';
                        break;
                    default:
                        break;
                }
            }

            gameHistory.Add($"Game {DateTime.Now}");
            int i = 1;
            while (i <= minQuestions)
            {
                writtenMessage = $"{i}.";
                System.Console.WriteLine(writtenMessage);
                gameHistory[gameHistory.Count - 1] += $"\n{writtenMessage}";

                int first = rnd.Next(0, maxNumber);
                int second = rnd.Next(0, maxNumber);

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
                        if (second == 0) second = rnd.Next(1, maxNumber);
                        if (first < second && first > 0)
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
                // System.Console.WriteLine("1. Get a random game\n2. Adding game\n3. Subtracting game\n4. Multiplication game\n5. Division game\n6. History");
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