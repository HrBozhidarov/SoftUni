using System;
using System.Linq;

namespace _05.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            var city = new City();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var data = input.Split();
                ICitizen citizen;

                if (data.Length == 2)
                {
                    citizen = new Robbot(data[0], data[1]);
                }
                else
                {
                    citizen = new Person(data[0], int.Parse(data[1]), data[2]);
                }

                city.AddCitizen(citizen);
            }

            var lastPartFromId = Console.ReadLine();

            city.DentaineCitizens(lastPartFromId);
            city.PrintAllFakeCitizens();
        }
    }
}
