using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        public CommandInterpreter()
        {

        }

        public string Read(string input)
        {
            var splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandName = splitInput[0];
            var commandArgs = splitInput.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                    .GetTypes()
                    .Where(x => (x.Name == (commandName + Suffix)) && x.IsClass)
                    .FirstOrDefault();

            if (commandType == null)
            {
                throw new InvalidOperationException("Command doesn`t exist");
            }

            var command = (ICommand)Activator.CreateInstance(commandType);

            return command.Execute(commandArgs);
        }
    }
}
