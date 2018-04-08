namespace P01_Phonebook
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            var dicNumber = new Dictionary<string, string>();

            while ((text = Console.ReadLine()) != "END")
            {
                var splitText = text.Split(' ');

                if (splitText[0] == "S")
                {
                    if (dicNumber.ContainsKey(splitText[1]))
                    {
                        Console.WriteLine($"{splitText[1]} -> {dicNumber[splitText[1]]}");
                        continue;
                    }

                    Console.WriteLine($"Contact {splitText[1]} does not exist.");
                }
                else
                {
                    dicNumber[splitText[1]] = splitText[2];
                }
            }
        }
    }
}