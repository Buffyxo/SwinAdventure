using System;
namespace SwinAdventure
{
	public class LookCommand : Command
	{
		public LookCommand() : base(new string[] { "look" })
		{
		}

		public override string Execute(Player p, string[] text)
		{
			if (text.Length != 3 && text.Length != 5)
			{
				return "I don't know how to look like that\n";
			}

			if (text[0] != "look")
			{
				return "Error in look input\n";
			}

			if (text[1] != "at")
			{
				return "What do you want to look at?";
			}

			if (text.Length == 5 && text[3] != "in")
			{
				return "What do you want to look in?";
			}

			IHaveInventory container = null;
			string itemId = text[2];

            if (text.Length == 3)
			{
				container = p;
                //container is player
            }

			if (text.Length == 5)
			{
                string containerId = text[4];
                // container is text[4];

                container = FetchContainer(p, containerId);
                // retrieve container from the Player.
            }

            if (container == null)
            {
                return "I can't find the " + text[4];
            }

            return LookAtIn(itemId, container);
            
		}

		private IHaveInventory FetchContainer(Player p, string containerId)
		{
			if (p.AreYou(containerId))
			{
				return p;
			}

			GameObject obj = p.Locate(containerId);
			IHaveInventory container = obj as IHaveInventory;

			return container;
        }

		private string LookAtIn(string thingId, IHaveInventory container)
		{
            
            if (container.Locate(thingId) == null)
			{
                return "I can't find the " + thingId;
            }
			 
			return container.Locate(thingId).FullDescription;
		}
	}
}

