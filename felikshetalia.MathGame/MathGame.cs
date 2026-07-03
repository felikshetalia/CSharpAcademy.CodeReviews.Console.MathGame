using System;

namespace MathGame
{
    internal class MathGame
    {
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
                            Console.WriteLine("This is the history of all games");
                            break;
                        case "2":
                            Console.WriteLine("Starting a new game");
                            break;
                        default:
                            continue;
                    }

                }
            }
        }
    }
}