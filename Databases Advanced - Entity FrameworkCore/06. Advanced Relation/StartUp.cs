using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //var context = new BillsPaymentSystemContext();

            //context.Database.EnsureDeleted();
            //context.Database.Migrate();

            //var engine = new Engine();

            // engine.Run(context);

            PayBills();
        }

        public static void PayBills()
        {
            var context = new BillsPaymentSystemContext();

            try
            {
                Console.WriteLine("Enter user id");
                var userId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter amount");
                var amount = decimal.Parse(Console.ReadLine());

                var bankAccounts = context.PaymentMethods
                                        .Include(x => x.BankAccount)
                                        .Where(x => x.UserId == userId && x.Type == Data.Models.Type.BankAccount)
                                        .ToList();

                var creditCards = context.PaymentMethods
                                        .Include(x => x.CreditCard)
                                        .Where(x => x.UserId == userId && x.Type == Data.Models.Type.CreditCard)
                                        .ToList();

                var totalMoney = bankAccounts.Sum(x => x.BankAccount.Balance) + creditCards.Sum(x => x.CreditCard.LimitLef);

                if (totalMoney < amount)
                {
                    throw new Exception();
                }

                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.BankAccount.Balance - amount < 0)
                    {
                        amount -= bankAccount.BankAccount.Balance;
                        bankAccount.BankAccount.Withdraw(bankAccount.BankAccount.Balance);
                    }
                    else
                    {
                        bankAccount.BankAccount.Withdraw(amount);

                        context.SaveChanges();

                        return;
                    }
                }

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.CreditCard.LimitLef - amount < 0)
                    {
                        amount -= creditCard.CreditCard.LimitLef;
                        creditCard.CreditCard.Withdraw(creditCard.CreditCard.LimitLef);
                    }
                    else
                    {
                        creditCard.CreditCard.Withdraw(amount);

                        context.SaveChanges();

                        return;
                    }
                }
            } //Another exception .. ..
            catch (Exception)
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
    }
}
