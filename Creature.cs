namespace DungeonExplorer
{
    // Abstract base class for all living entities in the game.
    public abstract class Creature
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public bool IsAlive => Health > 0;

        protected Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Method for taking damage.
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
            Console.WriteLine($"{Name} takes {damage} damage and has {Health} health remaining.");
        }

        // Virtual attack method that can be overridden by subclasses.
        public virtual void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
            target.TakeDamage(10); // Default attack damage
        }
    }
}