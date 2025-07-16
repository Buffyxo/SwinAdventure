namespace SwinAdventure;

class Program
{
    static void Main(string[] args)
    {
        IdentifiableObject id = new IdentifiableObject(new string[] { "104673370", "Zakirah", "Adnan" });
        Player newPlayer = new Player("Player", "A player");
        Inventory newInventory = new Inventory();

        Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel.");
        Item rock = new Item(new string[] { "rock", "stone" }, "a rock", "This is a rock.");

        newPlayer.Inventory.Put(shovel);
        newPlayer.Inventory.Put(rock);

        string desc = newPlayer.FullDescription;
        Console.WriteLine(desc);
        Console.WriteLine(newPlayer.Locate("shovel"));
    }
}

