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

        // Prepare initial location
        Location hallway = new Location("the Hallway", "This is a long well lit hallway.\nThere are exits to the south.");
        player.Location = hallway;

        // Prepare item data
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel." );
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze.");
        Item gem = new Item(new string[] { "gem" }, "a red gem", "A bright red ruby the size of your fist!");
        Item pc = new Item(new string[] { "pc" }, "a small computer", "The light from the monitor of this computer illuminates the room.");
        Bags bag = new Bags(new string[] { "bag" }, "a leather bag", "A small brown leather bag.");

        // Prepare items in location
        hallway.Inventory.Put(shovel);
        hallway.Inventory.Put(sword);

        // Prepare player inventory
        player.Inventory.Put(pc);
        player.Inventory.Put(bag);
        bag.Inventory.Put(gem);


        // Start Game
        Console.WriteLine("Welcome to Swin Adventure!");
        Console.WriteLine("You have arrived in the Hallway");

        //Console.Write(hallway.FullDescription);

        while (true)
        {
            Console.Write("Command -> ");
            string command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }

            LookCommand lookCommand = new LookCommand();
            string look = lookCommand.Execute(player, command.Split());
            Console.WriteLine(look);
        }



        Console.WriteLine("Bye");
    }
}

