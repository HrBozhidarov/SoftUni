namespace P02_PhonebookUpgrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            var dicNumber = new Dictionary<string, string>();

            while ((text = Console.ReadLine()) != "END")
            {
                var splitText = text.Split(' ');

                if (splitText[0] == "A")
                {
                    dicNumber[splitText[1]] = splitText[2];
                }
                else if (text == "ListAll")
                {
                    foreach (var item in dicNumber.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                }
                else
                {
                    if (dicNumber.ContainsKey(splitText[1]))
                    {
                        Console.WriteLine("{0} -> {1}", splitText[1], dicNumber[splitText[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", splitText[1]);
                    }
                }
            }
        }
    }
}