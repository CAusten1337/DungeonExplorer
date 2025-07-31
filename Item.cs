namespace DungeonExplorer
{
    // Base class for all items in the game.
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    // A Weapon is a type of Item that has a damage value.
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, string description, int damage) : base(name, description)
        {
            Damage = damage;
        }
    }

    // A Potion is a type of Item that restores health.
    public class Potion : Item
    {
        public int HealthToRestore { get; set; }

        public Potion(string name, string description, int healthToRestore) : base(name, description)
        {
            HealthToRestore = healthToRestore;
        }
    }
}