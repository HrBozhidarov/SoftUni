using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var startupPath = Directory.GetParent(@"../../../").FullName;
            var resourcePathText = "/Resources/text.txt";
            var resourcePathWords = "/Resources/words.txt";
            var resourceExpectedResult = "/Resources/expectedResult.txt";
            var expectedResultPath = startupPath + resourceExpectedResult;
            var textFilePath = startupPath + resourcePathText;
            var wordsFilePath = startupPath + resourcePathWords;

            if (!File.Exists(textFilePath) || !File.Exists(expectedResultPath) || !File.Exists(wordsFilePath))
            {
                Console.WriteLine("Invalid path name...");
            }
            else
            {
                var words = File.ReadAllLines(wordsFilePath);
                var dictionary = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    dictionary[word.ToLower()] = 0;
                }

                var lines = File.ReadAllLines(textFilePath);

                foreach (var line in lines)
                {
                    var lineWords = line.Split(new char[] { '.', '!', '?', '-', ' ', ',' }).Select(x => x.ToLower()).ToArray();

                    foreach (var currentWord in lineWords)
                    {
                        if (dictionary.ContainsKey(currentWord))
                        {
                            dictionary[currentWord]++;
                        }
                    }
                }

                var result = dictionary.OrderByDescending(x => x.Value).Select(x => $"{x.Key} - {x.Value}");

                File.WriteAllText(startupPath + "/Resources/actualResult.txt", string.Join("\n", result));

                Console.WriteLine("File was created successfuly!");
            }
        }
    }
}
