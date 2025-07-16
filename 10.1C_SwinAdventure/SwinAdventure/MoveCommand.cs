using System;
using System.IO;
using System.Numerics;

namespace SwinAdventure
{
	public class MoveCommand : Command
	{
		public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
		}


        public override string Execute(Player player, string[] text)
        {
            Path path = null;
            
            if (text.Length == 2)
            {
                string pathId = text[1]; // get pathId from the input
                path = player.Location.Locate(pathId) as Path; // Find if the path exists in the location   
            }
            else if (text.Length == 1)
            {
                return "Where do you want to move?";
            }
            else
            {
                return "That is an invalid move command.";
            }

            if (path == null)
            {
                return "There are no paths that lead there.";
            }
            return path.Move(player);

        }


    }
}

