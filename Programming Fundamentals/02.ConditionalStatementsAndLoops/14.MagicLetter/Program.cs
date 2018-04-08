using System;

namespace P14_MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            string skip = Console.ReadLine();

            for (char i = a; i <= b; i++)
            {
                for (char j = a; j <= b; j++)
                {
                    for (char h = a; h <= b; h++)
                    {
                        string result = $"{i}{j}{h} ";

                        if (!result.Contains(skip))
                        {
                            Console.Write(result);
                        }
                    }
                }
            }
        }
    }
}
