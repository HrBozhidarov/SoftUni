using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ProductsAndQuontity { get; set; }
        public decimal Bill { get; set; }
    }

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var shop = new Dictionary<string, decimal>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split('-');

            shop[input[0]] = decimal.Parse(input[1]);
        }

        var clients = string.Empty;

        var listOfClients = new List<Customer>();

        while ((clients = Console.ReadLine()) != "end of clients")
        {
            var parts = clients.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var nameOfClient = parts[0];
            var product = parts[1];
            var quantity = int.Parse(parts[2]);

            if (!shop.ContainsKey(product))
            {
                continue;
            }

            var customer = new Customer();
            customer.Name = nameOfClient;
            customer.ProductsAndQuontity = new Dictionary<string, int>();
            customer.ProductsAndQuontity[product] = quantity;

            if (listOfClients.Any(x => x.Name == nameOfClient))
            {
                Customer existingCustomer = listOfClients.First(c => c.Name == nameOfClient);

                if (existingCustomer.ProductsAndQuontity.ContainsKey(product))
                {
                    existingCustomer.ProductsAndQuontity[product] += quantity;
                }
                else
                {
                    existingCustomer.ProductsAndQuontity[product] = quantity;
                }
            }
            else
            {
                listOfClients.Add(customer);
            }
        }

        foreach (var item in listOfClients)
        {
            foreach (var val in item.ProductsAndQuontity)
            {
                item.Bill += val.Value * shop[val.Key];
            }
        }

        var res = listOfClients.OrderBy(x => x.Name).ToList();
        var totalBill = 0M;

        foreach (var item in res)
        {
            Console.WriteLine(item.Name);

            foreach (var c in item.ProductsAndQuontity)
            {
                Console.WriteLine($"-- {c.Key} - {c.Value}");
            }

            Console.WriteLine($"Bill: {item.Bill:F2}");
            totalBill += item.Bill;
        }

        Console.WriteLine($"Total bill: {totalBill:F2}");
    }
}