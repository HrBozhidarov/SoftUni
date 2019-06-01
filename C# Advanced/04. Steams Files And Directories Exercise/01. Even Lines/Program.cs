using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var startupPath = Directory.GetParent(@"../../../").FullName;
            var resourcePath = "/Resources/text.txt";
            var path = startupPath + resourcePath;

            if (!File.Exists(path))
            {
                Console.WriteLine("File was not found!");
            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    var count = 0;

                    while (sr.Peek() >= 0)
                    {
                        count++;
                        var resultLine = new List<string>();
                        var line = sr.ReadLine();

                        if (count % 2 == 0)
                        {
                            continue;
                        }

                        var lineSplit = line.Split();

                        for (var i = lineSplit.Length - 1; i >= 0; i--)
                        {
                            var currentLineResult = "";

                            foreach (var ch in lineSplit[i])
                            {
                                var currentCharacter = "";

                                if (ch == '-' || ch == ',' || ch == '.' || ch == '!' || ch == '?')
                                {
                                    currentCharacter += '@';
                                }
                                else
                                {
                                    currentCharacter += ch;
                                }

                                currentLineResult += currentCharacter;
                            }

                            resultLine.Add(currentLineResult);
                        }

                        Console.WriteLine(string.Join(" ", resultLine));
                    }

                    count++;
                }
            }
        }
    }
}
