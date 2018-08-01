using AutoMappingObjectsExercice.Data;
using System;
using System.Linq;

namespace AutoMappingObjectsExercice.App
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    var commandLine = Console.ReadLine().Split(' ');

                    var command = commandLine[0];
                    var args = commandLine.Skip(1).ToArray();

                    var commandInterpretator = new CommanderInterpretator();

                    using (var context = new EmployeeContext())
                    {
                        commandInterpretator.ReturnCommand(command).Execute(context, args);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
