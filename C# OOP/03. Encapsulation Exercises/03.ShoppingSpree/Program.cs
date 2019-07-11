using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();
            var peopleInput = Console.ReadLine();
            var splitPeople = peopleInput.Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            var productInput = Console.ReadLine();
            var splitProducts = productInput.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                FillUpListWithPeople(people, splitPeople);

                FillUpListWithProducts(products, splitProducts);

                var input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    var names = input.Split();
                    var personName = names[0];
                    var productName = names[1];

                    var person = people.FirstOrDefault(x => x.Name == personName);
                    var product = products.FirstOrDefault(x => x.Name == productName);

                    Console.WriteLine(person.BuyProduct(product));
                }

                foreach (var currentPerson in people)
                {
                    Console.WriteLine(currentPerson);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FillUpListWithPeople(List<Person> people, string[] splitPeople)
        {
            foreach (var currentPerson in splitPeople)
            {
                var splitCurrentPerson = currentPerson.Split('=');
                var name = splitCurrentPerson[0];
                var money = decimal.Parse(splitCurrentPerson[1]);

                var person = new Person(name, money);

                people.Add(person);
            }
        }

        private static void FillUpListWithProducts(List<Product> products, string[] splitProducts)
        {
            foreach (var currentProduct in splitProducts)
            {
                var splitCurrentPerson = currentProduct.Split('=');
                var name = splitCurrentPerson[0];
                var cost = decimal.Parse(splitCurrentPerson[1]);

                var product = new Product(name, cost);

                products.Add(product);
            }
        }
    }
}
