namespace P08_EmployeeData
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstName = Console.ReadLine();
            var lastName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long persIdNumber = long.Parse(Console.ReadLine());
            decimal uniqEmployeeNum = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstName}");

            Console.WriteLine($"Last name: {lastName}");

            Console.WriteLine($"Age: {age}");

            Console.WriteLine($"Gender: {gender}");

            Console.WriteLine($"Personal ID: {persIdNumber}");

            Console.WriteLine($"Unique Employee number: {uniqEmployeeNum}");
        }
    }
}
