using System;
using System.Windows.Input;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>
            {
                new LookCommand(),
                new MoveCommand(),
                new TakeCommand(),
                new DropCommand(),
                new InventoryCommand()
            };
        }

        //public void AddCommand(Command command)
        //{
        //    _commands.Add(command);
        //}

        public string ExecuteCommand(Player player, string[] text)
        {
            string commandId = text[0];

            foreach (Command command in _commands)
            {
                if (command.AreYou(commandId))
                {
                    return command.Execute(player, text);
                }
            }

            return "That is an invalid command.";

        }
    }
}

