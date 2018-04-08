namespace P07_ExchangeVariableValues
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var a = 5;
            var b = 10;

            Console.WriteLine("Before:");

            Console.WriteLine("a = "+a);

            Console.WriteLine("b = "+b);

            var oldA = 5;

            a = b;
            b = oldA;

            Console.WriteLine("After:");

            Console.WriteLine("a = " + a);

            Console.WriteLine("b = " + b);   
        }
    }
}
