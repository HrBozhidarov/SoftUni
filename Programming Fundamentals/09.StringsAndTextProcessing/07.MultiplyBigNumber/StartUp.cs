using System;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var firstNumber = Console.ReadLine().TrimStart('0');
        var secondNumber = int.Parse(Console.ReadLine());

        if (firstNumber == "0" || secondNumber == 0 || firstNumber == "")
        {
            Console.WriteLine(0);
            return;
        }

        var product = 0;
        var numberInMind = 0;
        var remainder = 0;
        StringBuilder res = new StringBuilder();

        for (int i = firstNumber.Length - 1; i >= 0; i--)
        {
            var currentNumFromFirstNumber = int.Parse(firstNumber[i].ToString());
            product = (currentNumFromFirstNumber * secondNumber) + numberInMind;
            numberInMind = product / 10;
            remainder = product % 10;
            res.Append(remainder);
            if (i == 0 && numberInMind != 0)
            {
                res.Append(numberInMind);
            }
        }

        var result = res.ToString().ToCharArray();
        Array.Reverse(result);
        Console.WriteLine(string.Join("", result));
    }
}