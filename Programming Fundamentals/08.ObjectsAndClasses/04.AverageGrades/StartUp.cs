using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public class Student
    {
        public Student(string name, List<double> grades)
        {
            this.Name = name;
            this.Grades = new List<double>(grades);
            this.AverageGrade = this.Grades.Sum() / this.Grades.Count;
        }

        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade { get; private set; }
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var result = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();

            var grades = input.Skip(1).Select(double.Parse).ToList();
            var name = input[0];

            var student = new Student(name, grades);

            if (student.AverageGrade >= 5.00)
            {
                result.Add(student);
            }
        }

        var r = result.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

        foreach (var item in r)
        {
            Console.WriteLine($"{item.Name} -> {item.AverageGrade:F2}");
        }
    }
}