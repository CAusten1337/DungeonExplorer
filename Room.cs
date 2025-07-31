namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; private set; }
        public Monster Monster { get; set; }
        public Item Item { get; set; }

        // Navigation properties
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        public Room(string description)
        {
            Description = description;
        }

        // Provides a detailed description of the room and its contents.
        public string GetFullDescription()
        {
            string fullDescription = $"You are in a {Description}.";
            if (Monster != null && Monster.IsAlive)
            {
                fullDescription += $"\nA fearsome {Monster.Name} is here!";
            }
            if (Item != null)
            {
                fullDescription += $"\nYou see a {Item.Name} on the floor.";
            }
            return fullDescription;
        }
    }
}