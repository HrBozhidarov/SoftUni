using System;
namespace P15_Substring_broken
{
    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var count = int.Parse(Console.ReadLine());
            var search = 'p';
            var hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == search)
                {
                    hasMatch = true;
                    var endIndex = count + 1;

                    if (endIndex >= text.Length - i)
                    {
                        endIndex = text.Length - i;
                    }

                    var matchedString = text.Substring(i, endIndex);

                    Console.WriteLine(matchedString);

                    i += count;
                }
            }

            if (!hasMatch)
                Console.WriteLine("no");
        }
    }
}
