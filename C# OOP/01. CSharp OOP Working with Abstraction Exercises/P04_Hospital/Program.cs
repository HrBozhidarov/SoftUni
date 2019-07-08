using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doktors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] info = command.Split();
                var departament = info[0];
                var firstName = info[1];
                var secondName = info[2];
                var pacient = info[3];
                var fullName = firstName + secondName;

                if (!doktors.ContainsKey(firstName + secondName))
                {
                    doktors[fullName] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (int i = 0; i < 20; i++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool ifHavePlace = departments[departament].SelectMany(x => x).Count() < 60;

                if (ifHavePlace)
                {
                    int room = 0;
                    doktors[fullName].Add(pacient);

                    for (int i = 0; i < departments[departament].Count; i++)
                    {
                        if (departments[departament][i].Count < 3)
                        {
                            room = i;
                            break;
                        }
                    }

                    departments[departament][room].Add(pacient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commands = command.Split();

                if (commands.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[commands[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (commands.Length == 2 && int.TryParse(commands[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[commands[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doktors[commands[0] + commands[1]].OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }
    }
}
