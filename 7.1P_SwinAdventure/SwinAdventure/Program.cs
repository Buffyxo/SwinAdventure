using System.Numerics;

namespace SwinAdventure;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Swin Adventure!");

        Console.Write("Enter player's name: ");
        string playerName = Console.ReadLine();

        Console.Write("Enter player's description: ");
        string playerDescription = Console.ReadLine();

        Player player = new Player(playerName, playerDescription);

        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel.");
        Item sword = new Item(new string[] { "sword" }, "a bronze sword", "A short sword cast from bronze.");
       
        player.Inventory.Put(shovel);
        player.Inventory.Put(sword);

        Bags bag = new Bags(new string[] { "bag" }, "a leather bag", "A small brown leather bag.");

        player.Inventory.Put(bag);

        Item gem = new Item(new string[] { "gem" }, "a red gem", "A bright red ruby the size of your fist!");

        bag.Inventory.Put(gem);
        bag.Inventory.Put(sword);
        bag.Inventory.Put(shovel);

        while (true)
        {
            Console.Write("Command-> ");
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

