namespace P13_VowelOrDigit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var c = char.Parse(Console.ReadLine());
            var isDigit = char.IsDigit(c);
            var vowel = c == 'a' || c == 'o' || c == 'u' || c == 'e' || c == 'i';

            if (isDigit == true)
                Console.WriteLine("digit");
            else if (vowel)
                Console.WriteLine("vowel");
            else
                Console.WriteLine("other");
        }
    }
}
