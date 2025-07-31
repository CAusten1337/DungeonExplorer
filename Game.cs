using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player _player;
        private Room _currentRoom;

        public Game()
        {
            // Create the player
            _player = new Player("Jeff", 100);

            // Create the rooms and items
            var startingRoom = new Room("dank starting chamber");
            var monsterRoom = new Room("slimy, foul-smelling cavern");
            var treasureRoom = new Room("room shimmering with a faint light");
            
            // Link the rooms together
            startingRoom.North = monsterRoom;
            monsterRoom.South = startingRoom;
            monsterRoom.East = treasureRoom;
            treasureRoom.West = monsterRoom;

            // Place a monster and an item
            monsterRoom.Monster = new Monster("Giant Spider", 60);
            treasureRoom.Item = new Weapon("Steel Sword", "A trusty blade.", 25);
            
            // Set the starting room
            _currentRoom = startingRoom;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("Your goal is to find treasure and survive.");
            Console.WriteLine("Commands: 'north', 'south', 'east', 'west', 'look', 'take', 'attack', 'inventory', 'quit'");
            Console.WriteLine("------------------------------------------");

            bool playing = true;
            while (playing && _player.IsAlive)
            {
                Console.WriteLine("\n" + _currentRoom.GetFullDescription());
                Console.Write("> ");
                string playerInput = Console.ReadLine().ToLower();

                switch (playerInput)
                {
                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(playerInput);
                        break;
                    case "look":
                        // The description is already shown at the start of the loop.
                        break;
                    case "take":
                        TakeItem();
                        break;
                    case "attack":
                        Battle();
                        break;
                    case "inventory":
                        Console.WriteLine(_player.InventoryContents());
                        break;
                    case "quit":
                        playing = false;
                        Console.WriteLine("You decide to leave the dungeon. Farewell.");
                        break;
                    default:
                        Console.WriteLine("Input not recognized. Type 'help' for a list of commands.");
                        break;
                }
            }

            if (!_player.IsAlive)
            {
                Console.WriteLine("\nYou have been defeated. Game Over.");
            }
        }

        private void Move(string direction)
        {
            Room nextRoom = null;
            switch (direction)
            {
                case "north": nextRoom = _currentRoom.North; break;
                case "south": nextRoom = _currentRoom.South; break;
                case "east":  nextRoom = _currentRoom.East;  break;
                case "west":  nextRoom = _currentRoom.West;  break;
            }

            if (nextRoom != null)
            {
                _currentRoom = nextRoom;
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }
        }

        private void TakeItem()
        {
            if (_currentRoom.Item != null)
            {
                _player.PickUpItem(_currentRoom.Item);
                _currentRoom.Item = null; // Item is removed from the room
            }
            else
            {
                Console.WriteLine("There is nothing to take.");
            }
        }
        
        private void Battle()
        {
            Monster monster = _currentRoom.Monster;
            if (monster == null || !monster.IsAlive)
            {
                Console.WriteLine("There is nothing here to attack.");
                return;
            }

            Console.WriteLine($"\n--- Battle Start: {_player.Name} vs. {monster.Name} ---");

            while (_player.IsAlive && monster.IsAlive)
            {
                // Player's turn
                _player.Attack(monster);
                if (!monster.IsAlive)
                {
                    Console.WriteLine($"You have defeated the {monster.Name}!");
                    _currentRoom.Monster = null; // Monster is removed from the room
                    break;
                }

                // Monster's turn
                monster.Attack(_player);
                if (!_player.IsAlive)
                {
                    Console.WriteLine($"The {monster.Name} has defeated you!");
                    break;
                }
                 Console.WriteLine("---"); // Separator for turns
            }
             Console.WriteLine("--- Battle End ---");
        }
    }