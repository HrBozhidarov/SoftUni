using System;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var firstNumber = Console.ReadLine();
        firstNumber = firstNumber.TrimStart('0');
        var secondNumber = Console.ReadLine();
        secondNumber = secondNumber.TrimStart('0');

        Console.WriteLine(Sum(firstNumber, secondNumber));
    }

    private static string Sum(string firstNumber, string secondNumber)
    {
        var maxLength = Math.Max(firstNumber.Length, secondNumber.Length);

        firstNumber = firstNumber.PadLeft(maxLength, '0');
        secondNumber = secondNumber.PadLeft(maxLength, '0');

        var result = new StringBuilder();
        var residue = 0;

        for (int i = maxLength - 1; i >= 0; i--)
        {
            var number = (firstNumber[i] - '0') + (secondNumber[i] - '0') + residue;

            var append = number.ToString();

            if (append.Length > 1)
            {
                result.Append(append[1] - '0');
                residue = append[0] - '0';
            }
            else
            {
                residue = 0;
                result.Append(append[0] - '0');
            }
        }

        if (residue != 0)
        {
            result.Append(residue);
        }

        var res = result.ToString();

        result = new StringBuilder();

        for (int i = res.Length - 1; i >= 0; i--)
        {
            result.Append(res[i]);
        }

        return result.ToString();
    }
}