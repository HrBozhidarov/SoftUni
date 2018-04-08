using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public class Student
    {
        public List<string> Comments { get; set; }
        public List<DateTime> AttendanceDates { get; set; }
        public string Name { get; set; }
    }

    public static void Main()
    {
        var input = "";

        var students = new List<Student>();

        while ((input = Console.ReadLine()) != "end of dates")
        {
            var data = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var name = data[0];

            var listOfDates = data.Skip(1).Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();

            if (students.Any(s => s.Name == name))
            {
                var currentStudent = students.Where(s => s.Name == name).First();

                for (int i = 0; i < listOfDates.Count; i++)
                {
                    currentStudent.AttendanceDates.Add(listOfDates[i]);
                }
            }
            else
            {
                var newStudent = new Student();

                newStudent.Name = name;
                newStudent.AttendanceDates = new List<DateTime>();
                newStudent.AttendanceDates = listOfDates;

                students.Add(newStudent);
            }
        }

        while ((input = Console.ReadLine()) != "end of comments")
        {
            var data = input.Split('-');
            var name = data[0];

            if (students.Any(s => s.Name == name))
            {
                var currentStudent = students.Where(x => x.Name == name).First();

                if (currentStudent.Comments == null)
                {
                    currentStudent.Comments = new List<string>();
                }


                currentStudent.Comments.Add(data[1]);


            }
        }

        var result = students.OrderBy(s => s.Name);

        foreach (var item in result)
        {
            Console.WriteLine(item.Name);
            Console.WriteLine("Comments:");

            if (item.Comments != null)
            {
                foreach (var comment in item.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
            }

            Console.WriteLine("Dates attended:");

            foreach (var date in item.AttendanceDates.OrderBy(x => x.Date))
            {
                Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
            }
        }
    }
}