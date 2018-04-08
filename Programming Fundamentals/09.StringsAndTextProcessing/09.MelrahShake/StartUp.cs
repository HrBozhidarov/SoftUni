using System;

namespace _09.Melrah_Shake
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var patern = Console.ReadLine();

            while (true)
            {
                var first = text.IndexOf(patern);
                var last = text.LastIndexOf(patern);

                if (first != last &&
                    first != -1 &&
                    last != -1 &&
                    patern.Length > 0)
                {
                    text = text.Remove(last, patern.Length);
                    text = text.Remove(first, patern.Length);
                    Console.WriteLine("Shaked it.");
                    patern = patern.Remove(patern.Length / 2, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(text);
                    break;
                }
            }
        }
    }
}