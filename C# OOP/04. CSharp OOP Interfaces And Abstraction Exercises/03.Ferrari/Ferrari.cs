using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private const string Model = "488-Spider";
        private readonly string driver;

        public Ferrari(string driver)
        {
            this.driver = driver;
        }

        public void Info()
        {
            Console.WriteLine($"{Model}/Brakes!/Gas!/{this.driver}");
        }
    }
}
