namespace DungeonExplorer
{
    // Represents a monster, inheriting from the Creature class.
    public class Monster : Creature
    {
        public Monster(string name, int health) : base(name, health)
        {
        }

        // Overrides the base attack method for monster-specific behavior.
        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} viciously claws at {target.Name}!");
            target.TakeDamage(15); // Monsters attack for 15 damage.
        }
    }
}