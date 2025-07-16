using System;
namespace SwinAdventure
{
    public class DropCommand : Command
    {
        public DropCommand() : base(new string[] { "drop", "put" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length != 4 && text.Length != 2)
            {
                return "I can't drop that.";
            }

            
            

            string itemId = text[1];
            IHaveInventory container = player.Location;
            

            if (text.Length == 4)
            {
                if (text[2] != "in")
                {
                    return "What do you want to drop in?";
                }
                else if (text[3] == "room") {
                    container = player.Location;
                }
                else
                {
                    container = player.Inventory.Fetch(text[3]) as IHaveInventory;
                }

            }

            if (container == null)
            {
                return "I can't drop the " + text[1] + " in the " + text[3] + ".";
            }

            return Drop(itemId, container, player);
        }




        private string Drop(string thingId, IHaveInventory container, Player player)
        {

            GameObject obj = player.Locate(thingId);

            if (obj == null)
            {
                return "I can't find the " + thingId + ".";
            }
            else
            {
                
                player.Inventory.Take(thingId); // remove item from player's inventory

                if (container == player.Location)
                {
                    player.Location.Inventory.Put(obj as Item);
                    // drop thing in room
                }
                else
                {
                    Bags bag = container as Bags;
                    Bags playerBag = player.Inventory.Fetch(bag.FirstId) as Bags;
                    bag.Inventory.Put(obj as Item);
                    // drop thing in player bag

                    return "\nYou have dropped the " + obj.ShortDescription + " in the " + bag.Name;

                }
            }

            return "\nYou have dropped the " + obj.ShortDescription;
        }

    }
}

