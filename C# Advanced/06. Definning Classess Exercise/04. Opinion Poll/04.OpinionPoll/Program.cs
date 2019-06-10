using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var name = line[0];
                var age = int.Parse(line[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            foreach (var person in family.AllPeopleWhoAreBiggerThenThirty())
            {
                Console.WriteLine(person);
            }
        }
    }
}
