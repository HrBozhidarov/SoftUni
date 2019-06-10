using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();
            var command = Console.ReadLine();
            Func<List<string>, string, string, string, List<string>> transformList =
                    (allNames, currentCommand, criteria, generalCommand) => GetNewFilledList(allNames, currentCommand, criteria, generalCommand);

            while (command != "Party!")
            {
                var splitCommand = command.Split();
                var commandName = splitCommand[0];
                var commandForTransformation = splitCommand[1];
                var criteria = splitCommand[2];

                names = transformList(names, commandForTransformation, criteria, commandName);

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> GetNewFilledList(List<string> allNames, string command, string criteria, string generalCommand)
        {
            var newListNames = new List<string>();

            foreach (var name in allNames)
            {
                if (generalCommand == "Remove")
                {
                    TransformWhenRemove(command, newListNames, criteria, name, generalCommand);

                    continue;
                }

                TransformWhenAdd(command, newListNames, criteria, name, generalCommand);
                newListNames.Add(name);
            }

            return newListNames;
        }

        private static void TransformWhenRemove(string command, List<string> newListNames, string criteria, string name, string generalCommand)
        {
            switch (command)
            {
                case "Length":
                    var length = int.Parse(criteria);

                    if (name.Length != length)
                    {
                        newListNames.Add(name);
                    }
                    break;
                case "StartsWith":
                    var startsWith = criteria;

                    if (!name.StartsWith(startsWith))
                    {
                        newListNames.Add(name);
                    }
                    break;
                case "EndsWith":
                    var endsWith = criteria;

                    if (!name.EndsWith(endsWith))
                    {
                        newListNames.Add(name);
                    }
                    break;
            }
        }

        private static void TransformWhenAdd(string command, List<string> newListNames, string criteria, string name, string generalCommand)
        {
            switch (command)
            {
                case "Length":
                    var length = int.Parse(criteria);

                    if (name.Length == length)
                    {
                        newListNames.Add(name);
                    }
                    break;
                case "StartsWith":
                    var startsWith = criteria;

                    if (name.StartsWith(startsWith))
                    {
                        newListNames.Add(name);
                    }
                    break;
                case "EndsWith":
                    var endsWith = criteria;

                    if (name.EndsWith(endsWith))
                    {
                        newListNames.Add(name);
                    }
                    break;
            }
        }
    }
}
