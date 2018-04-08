using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }

    public static void Main()
    {
        var towns = ReadTownsAndStudents();

        List<Group> groups = DistributeStudentsIntoGroups(towns);

        Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

        foreach (var group in groups.OrderBy(x => x.Town.Name))
        {
            Console.Write($"{group.Town.Name}=> ");

            var students = new List<string>();

            foreach (var student in group.Students)
            {
                students.Add(student.Email);
            }

            Console.WriteLine(string.Join(", ", students));
        }
    }

    private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
    {
        var groups = new List<Group>();

        foreach (var town in towns.OrderBy(x => x.Name))
        {
            IEnumerable<Student> students = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email);

            while (students.Any())
            {
                var group = new Group();

                group.Town = town;
                group.Students = students.Take(group.Town.SeatsCount).ToList();
                students = students.Skip(group.Town.SeatsCount);
                groups.Add(group);
            }
        }

        return groups;
    }

    private static List<Town> ReadTownsAndStudents()
    {
        var towns = new List<Town>();
        var index = -1;
        var input = "";

        while ((input = Console.ReadLine()) != "End")
        {
            if (input.IndexOf("=>") > 0)
            {
                index++;
                var town = new Town();
                var parameters = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var seatsCount = int.Parse(parameters[1].Trim().Split(' ')[0]);
                town.Name = parameters[0];
                town.SeatsCount = seatsCount;
                town.Students = new List<Student>();
                towns.Add(town);
                continue;
            }

            var studentFeature = input.Split('|');
            var name = studentFeature[0].Trim();
            var email = studentFeature[1].Trim();
            var date = DateTime.ParseExact(studentFeature[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

            var student = new Student
            {
                Name = name,
                Email = email,
                RegistrationDate = date
            };

            towns[index].Students.Add(student);
        }

        return towns;
    }
}
