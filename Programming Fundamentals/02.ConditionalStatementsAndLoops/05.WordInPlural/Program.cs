using System;

namespace P05_WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = Console.ReadLine();
            var worldInPlural = string.Empty;

            if (world.EndsWith("y"))
            {
                worldInPlural = world.Substring(0,world.Length-1) + "ies";
            }
            else if (world.EndsWith("o") || world.EndsWith("ch") || world.EndsWith("sh")
                     || world.EndsWith("x") || world.EndsWith("z") || world.EndsWith("s"))
            {
                worldInPlural = world + "es";
            }
            else
            {
                worldInPlural = world + "s";
            }

            Console.WriteLine(worldInPlural);
        }
    }
}
