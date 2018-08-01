using System;
using System.Linq;

namespace P01_BillsPaymentSystem.Data
{
    public class Engine
    {
        public void Run(BillsPaymentSystemContext context)
        {
            while (true)
            {
                Console.WriteLine("Please, write a number to find user.");

                var userId = int.Parse(Console.ReadLine());

                var user = context.Users
                    .Where(x => x.UserId == userId)
                    .Select(x =>
                    new
                    {
                        x.FirstName,
                        x.LastName,
                        BankAccounts = x.PaymentMethods
                                        .Where(z => z.Type == Data.Models.Type.BankAccount)
                                        .Select(c => c.BankAccount)
                                        .ToArray(),
                        CreditCards = x.PaymentMethods
                                       .Where(z => z.Type == Data.Models.Type.CreditCard)
                                       .Select(c => c.CreditCard).ToArray()
                    })
                    .FirstOrDefault();

                if (user == null)
                {
                    Console.WriteLine($"User with id {userId} not found!");

                    continue;
                }

                Console.WriteLine($"User: {user.FirstName} {user.LastName}");

                Console.WriteLine("Bank Accounts:");

                var bankAccounts = user.BankAccounts;

                foreach (var bankAccount in bankAccounts)
                {
                    Console.WriteLine(bankAccount);
                }

                var creditCards = user.CreditCards;

                Console.WriteLine("Credit Cards:");

                foreach (var creditCard in creditCards)
                {
                    Console.Write(creditCard);
                }

                break;
            }
        }
    }
}
