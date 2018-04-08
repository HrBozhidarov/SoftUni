namespace P14_IntegerToHexAndBinary
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var hexaFormat = Convert.ToString(number, 16).ToUpper();
            var binFormat = Convert.ToString(number, 2);

            Console.WriteLine(hexaFormat);

            Console.WriteLine(binFormat);
        }
    }
}
