namespace P18_DifferentIntegersSize
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            try
            {
                var tryToDig = Convert.ToInt64(input);
                Console.WriteLine($"{tryToDig} can fit in: ");

                if (tryToDig >= sbyte.MinValue && tryToDig <= sbyte.MaxValue)
                    Console.WriteLine("* sbyte");

                if (tryToDig >= byte.MinValue && tryToDig <= byte.MaxValue)
                    Console.WriteLine("* byte");

                if (tryToDig >= short.MinValue && tryToDig <= short.MaxValue)
                    Console.WriteLine("* short");

                if (tryToDig >= ushort.MinValue && tryToDig <= ushort.MaxValue)
                    Console.WriteLine("* ushort");

                if (tryToDig >= int.MinValue && tryToDig <= int.MaxValue)
                    Console.WriteLine("* int");

                if (tryToDig >= uint.MinValue && tryToDig <= uint.MaxValue)
                    Console.WriteLine("* uint");

                if (tryToDig >= long.MinValue && tryToDig <= long.MaxValue)
                    Console.WriteLine("* long");
            }
            catch
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}
