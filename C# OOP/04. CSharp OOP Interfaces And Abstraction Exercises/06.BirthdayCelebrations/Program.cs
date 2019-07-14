using System;

namespace _06.BirthdayCelebrations
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
                ILiveCitizen liveCitizen = null;

                if (data[0] == "Citizen")
                {
                    liveCitizen = new Person(data[1], int.Parse(data[2]), data[3], data[4]);
                    city.AddLiveCitizents(liveCitizen);
                }
                else if(data[0] == "Pet")
                {
                    liveCitizen = new Pet(data[1], data[2]);
                    city.AddLiveCitizents(liveCitizen);
                }
            }

            var birthDay = Console.ReadLine();

            city.PrintAllBirthdaysWhichConincides(birthDay);
        }
    }
}
