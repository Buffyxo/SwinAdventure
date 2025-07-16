using System;
using System.ComponentModel;
using System.IO;
using System.Numerics;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "pickup", "take" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length != 4 && text.Length != 2)
            {
                return "I can't pick that up";
            }


            string itemId = text[1];
            IHaveInventory container = player.Location;

            if (text.Length == 4)
            {
                if (text[2] != "from")
                {
                    return "What do you want to take from?";
                }
                container = player.Location.Locate(text[3]) as IHaveInventory;
                if (container == null)
                {
                    return "I can't find the " + text[3] + ".";
                }
            }

            return TakeFrom(itemId, container, player);

        }


        // is container with player or in the room?
        // pick up thing from container in room
        // pick up thing from room
        private string TakeFrom(string thingId, IHaveInventory container, Player player)
        {
            GameObject item = container.Locate(thingId);
            if (item == null)
            {
                return "I can't find the " + thingId + ".";
            }
            else
            {
                player.Inventory.Put(item as Item);

                if (player.Location == container)
                {
                    player.Location.Inventory.Take(thingId);
                }
                else
                {
                    Bags bag = container as Bags;
                    bag.Inventory.Take(thingId);
                }
            }

            return "\nYou have taken the " + item.ShortDescription;
        }
    }
}

