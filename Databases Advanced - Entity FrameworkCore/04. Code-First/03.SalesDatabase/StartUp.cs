using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var product = new Product
            {
                Name = "sfd",
                Description = "sfdasfasf",
                Price = 1.2m,
                Quantity = 1,
            };

            var store = new Store
            {
                Name = "ffs",
            };

            var customer = new Customer
            {
                Name = "aa",
                CreditCardNumber = "03142",
                Email = "fsdfgs",
            };

            var sale = new Sale
            {
                Customer=customer,
                Product=product,
                Store=store
            };

            var contex = new SalesContext();

            contex.Sales.Add(sale);

            contex.SaveChanges();
        }
    }
}
