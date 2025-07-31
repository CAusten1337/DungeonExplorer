using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Run tests before starting the game
            Testing tests = new Testing();
            tests.RunTests();

            // Start the game
            Game game = new Game();
            game.Start();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}