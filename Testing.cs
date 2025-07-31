using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
        public void RunTests()
        {
            Console.WriteLine("--- Running Verification Tests ---");

            // Test 1: Player Creation
            Player testPlayer = new Player("TestDummy", 100);
            Debug.Assert(testPlayer.Name == "TestDummy" && testPlayer.Health == 100, "Player creation failed.");
            Console.WriteLine("Player Creation Test: Passed");

            // Test 2: Item Pickup
            Item testItem = new Weapon("Test Sword", "A sword for testing.", 10);
            testPlayer.PickUpItem(testItem);
            Debug.Assert(testPlayer.InventoryContents().Contains("Test Sword"), "Item pickup failed.");
            Console.WriteLine("Item Pickup Test: Passed");

            // Test 3: Monster and Player Damage
            Monster testMonster = new Monster("Test Goblin", 50);
            testPlayer.Attack(testMonster);
            Debug.Assert(testMonster.Health < 50, "Player attack on monster failed.");
            Console.WriteLine("Player Attack Test: Passed");
            
            testMonster.Attack(testPlayer);
            Debug.Assert(testPlayer.Health < 100, "Monster attack on player failed.");
            Console.WriteLine("Monster Attack Test: Passed");

            Console.WriteLine("--- All Tests Finished ---\n");
        }
    }
}