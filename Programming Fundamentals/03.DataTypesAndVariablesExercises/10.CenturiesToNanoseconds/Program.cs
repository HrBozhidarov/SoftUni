namespace P10_CenturiesToNanoseconds
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var centuries = byte.Parse(Console.ReadLine());
            var years = (short)(centuries * 100);
            var days = (int)(years * 365.2422);
            var hours = days * 24;
            var minutes = hours * 60L;
            var seconds = minutes * 60M;
            var miliseconds = seconds * 1000M;
            var microsends = miliseconds * 1000M;
            var nanoseconds = microsends * 1000M;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = {microsends} microseconds = {nanoseconds} nanoseconds");

        }
    }
}
