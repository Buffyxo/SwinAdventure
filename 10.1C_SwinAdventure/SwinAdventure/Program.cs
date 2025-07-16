using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace SwinAdventure;

class Program
{
    static void Main(string[] args)
    {
        // Prepare player data
        Console.Write("Enter player's name: ");
        string playerName = Console.ReadLine();

        Console.Write("Enter player's description: ");
        string playerDescription = Console.ReadLine();

        Player player = new Player(playerName, playerDescription);

        // Set available locations
        Location hallway = new Location("the Hallway", "This is a long well lit hallway.\n");
        Location closet = new Location("a small Closet", "A small dark closet, with an odd smell\n");
        Location garden = new Location("a small Garden", "There are many small shrubs and flowers growing from well tended garden beds.\n");

        // Prepare initial location
        player.Location = hallway;

        // Set default paths
        Path s = new Path(new string[] { "south", "s" }, "South", "You go through a door\n");
        Path n = new Path(new string[] { "north", "n" }, "North", "You go through a door\n");
        Path e = new Path(new string[] { "east", "e" }, "East", "You travel through a small door, and then crawl a few meters before arriving from the east\n");
        Path w = new Path(new string[] { "west", "w" }, "West", "You go through a door\n");
        Path ne = new Path(new string[] { "northeast", "ne" }, "Northeast", "You go through a door\n");
        Path nw = new Path(new string[] { "northwest", "nw" }, "Northwest", "You travel through a small dorr, and the crawl a few meters before arriving from the south east\n");
        Path se = new Path(new string[] { "southeast", "se" }, "Southeast", "You go through a door\n");
        Path sw = new Path(new string[] { "southeast", "sw" }, "Southeast", "You travel through a small dorr, and the crawl a few meters before arriving from the north west\n");

        // Prepare item data
        Item shovel = new Item(new string[] { "shovel" }, "shovel", "This is a shovel.");
        Item sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze.");
        Item gem = new Item(new string[] { "gem" }, "red gem", "A bright red ruby the size of your fist!");
        Item pc = new Item(new string[] { "pc" }, "small computer", "The light from the monitor of this computer illuminates the room.");
        Bags bag = new Bags(new string[] { "bag" }, "leather bag", "A small brown leather bag.");
        Bags pouch = new Bags(new string[] { "pouch" }, "leather pouch", "A small pouch.");
        Item emerald = new Item(new string[] { "emerald" }, "green gem", "A bright green emerald!");


        // Set items and paths for Hallway
        hallway.AddPath(s, closet);
        hallway.AddPath(se, garden);
        se.isLocked = true;
        hallway.Inventory.Put(shovel);
        hallway.Inventory.Put(sword);

        // Set items and paths for Closet
        closet.AddPath(n, hallway);
        closet.AddPath(e, garden);
        closet.Inventory.Put(pc);

        // Set items and paths for Garden
        garden.AddPath(w, closet);
        garden.Inventory.Put(pouch);
        pouch.Inventory.Put(gem);


        // Prepare player inventory
        player.Inventory.Put(bag);
        player.Inventory.Put(emerald);


        // Start Game
        Console.WriteLine("Welcome to Swin Adventure!");
        Console.WriteLine("You have arrived in " + hallway.Name);

        // Create CommandProcessor
        CommandProcessor processor = new CommandProcessor();

        //// Register commands with the processor (If aggregation relationship implemented instead)
        //processor.AddCommand(new LookCommand());
        //processor.AddCommand(new MoveCommand());
        //processor.AddCommand(new TakeCommand());
        //processor.AddCommand(new DropCommand());
        //processor.AddCommand(new InventoryCommand());

        // Game loop
        while (true)
        {
            Console.Write("Command -> ");
            string command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }

            // Process and execute command using the CommandProcessor
            string result = processor.ExecuteCommand(player, command.Split());
            Console.WriteLine(result);
        }

        Console.WriteLine("Bye");
    }
}

