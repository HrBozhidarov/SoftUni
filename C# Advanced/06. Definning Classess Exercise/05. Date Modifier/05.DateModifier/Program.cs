using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dateModifier = new DateModifier();
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            Console.WriteLine(dateModifier.CalculateDiffrenceBetweenTwoDates(firstDate, secondDate));
        }
    }
}
