using System;

namespace MathGame
{
    internal class MathGame
    {

        public void NewGame(string readLine)
        {
            // WARNING: this game operates only with integers
            int score = 0;
            int minQuestions = 5;
            // 2 params = 1 point
            // 3 params = 2 pts
            // 4 params = 3 pts

            char[] operations = { '+', '-', '*', '/' };

            var rnd = new Random();

            // in the game loop you should get an operator at a random index

            // get at least 5 questions

            // start with 5 questions and 2 params only

            for (int i = 0; i < minQuestions; i++)
            {
                System.Console.WriteLine($"{i + 1}.");
                int first = rnd.Next(1, 11);
                int second = rnd.Next(1, 11);
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
                        correctAnswer = first / second;
                        // needs further modification
                        break;
                    default:
                        correctAnswer = 0;
                        break;
                }

                // now user's turn
                Console.Write($"{first} {op} {second} = ");
                readLine = Console.ReadLine();
                int userAnswer;
                if (readLine != null)
                {
                    if (int.TryParse(readLine, out userAnswer))
                    {
                        if (userAnswer == correctAnswer)
                        {
                            score++;
                            System.Console.WriteLine("Correct.");
                        }
                        else
                        {
                            Console.WriteLine("Nope");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("The answer should be a number don't you think?");
                    }
                }
            }
        }
        public void StartGame()
        {
            // the main game that will start the loop with main menu
            string lineRead; // the user input to console

            while (true)
            {
                // Console.Clear(); // exception
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
                            Console.WriteLine("This is the history of all games");
                            break;
                        default:
                            continue;
                    }

                }
            }
        }
    }
}