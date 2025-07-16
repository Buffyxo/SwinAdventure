using System;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look", "examine" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "look")
            {
                return p.Location.FullDescription;
            }

            if (text.Length == 2 && text[0] == "examine")
            {
                return LookAtIn(text[1], p);
            }

            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] != "look" || text[1] != "at")
                {
                    return "That is an invalid look command.";
                }

                string itemId = text[2];
                IHaveInventory container = p;

                if (text.Length == 5)
                {
                    if (text[3] != "in")
                    {
                        return "What do you want to look in?";
                    }
                    container = FetchContainer(p, text[4]);
                    if (container == null)
                    {
                        return "I can't find the " + text[4] + ".";
                    }
                }

                return LookAtIn(itemId, container);
            }

            return "I don't know how to look like that.";
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p.AreYou(containerId)) return p;

            GameObject obj = p.Locate(containerId);
            return obj as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject item = container.Locate(thingId);
            if (item == null)
            {
                return "I can't find the " + thingId + ".";
            }
            return "\n" + item.FullDescription;
        }
    }
}