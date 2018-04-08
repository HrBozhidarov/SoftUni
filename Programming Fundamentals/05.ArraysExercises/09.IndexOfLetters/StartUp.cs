namespace P09_IndexOfLetters
{
    using System;

   public class StartUp
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var letter = new char[word.Length];
            var count = 0;

            foreach (var element in word)
            {
                letter[count] = element;
                count++;
            }

            for (int i = 0; i < letter.Length; i++)
            {
                count = 0;

                for (char j = 'a'; j <= 'z'; j++)
                {
                    if (letter[i] == j)
                    {
                        Console.WriteLine($"{letter[i]} -> {count}");
                    }

                    count++;
                }
            }
        }
    }
}
