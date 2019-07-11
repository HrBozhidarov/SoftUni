using System;

namespace _01.BoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var heigth = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, heigth);

                Console.WriteLine(box);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
