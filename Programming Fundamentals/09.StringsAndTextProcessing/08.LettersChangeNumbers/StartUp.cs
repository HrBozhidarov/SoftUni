using System;

public class StartUp
{
    public static void Main()
    {
        var sequencesFromStrings = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        var sum = 0M;

        for (int i = 0; i < sequencesFromStrings.Length; i++)
        {
            var currentString = sequencesFromStrings[i];

            var firstLetter = currentString[0];
            var secondLetter = currentString[currentString.Length - 1];
            var number = decimal.Parse(currentString.Substring(1, currentString.Length - 2));

            if (char.IsUpper(firstLetter))
            {
                var position = firstLetter - 'A' + 1;
                number = (number / position);
            }
            else
            {
                var position = firstLetter - 'a' + 1;
                number = (number * position);
            }

            if (char.IsUpper(secondLetter))
            {
                var position = secondLetter - 'A' + 1;
                number = (number - position);
            }
            else
            {
                var position = secondLetter - 'a' + 1;
                number = (number + position);
            }

            sum += number;
        }

        Console.WriteLine($"{sum:F2}");
    }
}