using System;

namespace _04.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var phones = Console.ReadLine().Split();
            var browsers = Console.ReadLine().Split();

            var phone = new Smartphone(phones, browsers);

            phone.PrintCalling();
            phone.PrintBrowsing();
        }
    }
}
