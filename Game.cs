using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player

            currentRoom = new Room("Starting room");

            player = new Player("jeff", 100);

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here

                Console.WriteLine("Welcome to the Dungeon... \n");
                
                Console.WriteLine("Please press I to move forward through the dungeon");
                Console.WriteLine("Please press l to move right through the dungeon");
                Console.WriteLine("Please press j to move left through the dungeon");

                string playerInput = Console.ReadLine();

                if (playerInput == "i")
                {

                    Console.WriteLine("...Moving fowards the Dungeon...");
                    currentRoom = new Room("grimy room");

                }
                else if (playerInput == "l")
                {

                    Console.WriteLine("...Moving through the Dungeon...");
                    currentRoom = new Room("Slimy room");

                }
                else if (playerInput == "j")
                {

                    Console.WriteLine("...Moving through the Dungeon...");
                    currentRoom = new Room("Dark room");

                }
                else
                {
                    Console.WriteLine("Input not recognised");
                }

            }
        }
    }
}

