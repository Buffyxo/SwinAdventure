using System;
namespace SwinAdventure
{
    public class InventoryCommand : Command
    {
        public InventoryCommand() : base(new string[] { "inv", "inventory" })
        {
        }

        public override string Execute(Player player, string[] text)
        {

            return "Your inventory contains:" + player.Inventory.ItemList;
        }

    }
}

