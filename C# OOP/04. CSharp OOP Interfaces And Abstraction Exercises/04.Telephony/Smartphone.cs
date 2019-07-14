using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        private const string InvalidUrl = "Invalid URL!";
        private const string InvalidNumber = "Invalid number!";

        private IList<string> phones;
        private IList<string> browesInWordWideWeb;
        public Smartphone(IList<string> phones, IList<string> browesInWordWideWeb)
        {
            this.phones = phones;
            this.browesInWordWideWeb = browesInWordWideWeb;
        }

        public void PrintBrowsing()
        {
            foreach (var browse in this.browesInWordWideWeb)
            {
                if (IfValidBrowse(browse))
                {
                    Console.WriteLine($"Browsing: {browse}!");
                }
                else
                {
                    Console.WriteLine(InvalidUrl);
                }
            }
        }

        public void PrintCalling()
        {
            foreach (var phone in this.phones)
            {
                if (IfValidNumber(phone))
                {
                    Console.WriteLine($"Calling... {phone}");
                }
                else
                {
                    Console.WriteLine(InvalidNumber);
                }
            }
        }

        private bool IfValidNumber(string number)
        {
            foreach (var ch in number)
            {
                if (!char.IsNumber(ch))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IfValidBrowse(string browse)
        {
            foreach (var ch in browse)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
