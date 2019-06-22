using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        public class Reservetion
        {
            public int Sum { get; set; }

            public string Name { get; set; }

            public List<string> Reservetions { get; set; }
        }

        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());

            var str = Console.ReadLine().Split().ToArray();
            var queue = new Queue<Reservetion>();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                var number = 0;

                if (int.TryParse(str[i], out number))
                {
                    if (queue.Count > 0)
                    {

                        var peak = queue.Peek();

                        if (peak.Sum + number <= capacity)
                        {
                            peak.Sum += number;
                            peak.Reservetions.Add(number.ToString());
                        }
                        else
                        {
                            Reservetion hall = null;

                            while (queue.Count > 0)
                            {
                                var currentHall = queue.Dequeue();
                                Console.WriteLine($"{currentHall.Name} -> {string.Join(", ", currentHall.Reservetions)}");

                                if (queue.Count > 0 && queue.Peek().Sum + number <= capacity)
                                {
                                    hall = queue.Peek();

                                    hall.Sum += number;
                                    hall.Reservetions.Add(number.ToString());

                                    break;
                                }
                            }
                        }
                    }
                }
                else if (number == 0)
                {
                    queue.Enqueue(new Reservetion()
                    {
                        Name = str[i].ToString(),
                        Reservetions = new List<string>()
                    });
                }
            }
        }
    }
}