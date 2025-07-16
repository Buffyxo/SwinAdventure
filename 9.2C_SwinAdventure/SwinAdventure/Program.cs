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
        Bags bag2 = new Bags(new string[] { "bag" }, "leather bag", "A small brown leather bag.");


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
        garden.Inventory.Put(bag2);
        

        // Prepare player inventory
        player.Inventory.Put(bag);
        bag.Inventory.Put(gem);


        // Start Game
        Console.WriteLine("Welcome to Swin Adventure!");
        Console.WriteLine("You have arrived in " + hallway.Name);

        //Console.Write(hallway.FullDescription); FOR TESTING

        ////TESTS:
        //Console.WriteLine(player.Location.Paths);

        while (true)
        {
            Console.Write("Command -> ");
            string command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }
            else if (command.Contains("look"))
            {
                LookCommand lookCommand = new LookCommand();
                string look = lookCommand.Execute(player, command.Split());
                Console.WriteLine(look);
            }
            else if (command.Contains("move") || command.Contains("go") || command.Contains("head") || command.Contains("leave"))
            {
                MoveCommand moveCommand = new MoveCommand();
                string move = moveCommand.Execute(player, command.Split());
                Console.WriteLine(move);
            }
            else
            {
                Console.WriteLine("That is an invalid command.");
            }
            


        }



        Console.WriteLine("Bye");
    }
}

