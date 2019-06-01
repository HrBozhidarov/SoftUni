using System;
using System.Collections.Generic;
using System.IO;

namespace _02._Line_Numbers
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
                var lineCount = 1;
                var lines = File.ReadAllLines(path);
                var result = new List<string>();
                var marsk = new List<char>() { '-', ',', '.', '!', '?' };

                foreach (var line in lines)
                {
                    var preSuffix = $"Line {lineCount}: ";
                    var countCharacters = 0;
                    var countPunctuationMarks = 0;

                    foreach (var ch in line)
                    {
                        if (char.IsPunctuation(ch))
                        {
                            countPunctuationMarks++;
                        }
                        else if (char.IsLetter(ch))
                        {
                            countCharacters++;
                        }
                    }

                    result.Add(preSuffix + line + $" ({countCharacters})({countPunctuationMarks})");

                    lineCount++;
                }


                File.WriteAllText(startupPath + "/Resources/output.txt", string.Join("\n", result));

                Console.WriteLine("File was created successfuly!");
            }
        }
    }
}
