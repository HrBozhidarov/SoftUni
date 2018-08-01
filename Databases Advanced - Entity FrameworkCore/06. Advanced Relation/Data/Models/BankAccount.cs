using System;
using System.Collections.Generic;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public BankAccount()
        {

        }

        public BankAccount(int bankAccountId, decimal balance, string bankName, string swiftCode)
        {
            this.BankAccountId = bankAccountId;
            this.Balance = balance;
            this.BankName = bankName;
            this.SwiftCode = swiftCode;
        }

        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new InvalidOperationException($"Can not witdraw {amount} becase Your balance is {this.Balance}!");
            }

            if (amount < 0)
            {
                throw new InvalidOperationException("You can not deposit negative amount");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("You can not deposit negative amount");
            }

            this.Balance += amount;
        }

        public override string ToString()
        {
            return $@"-- ID: {this.BankAccountId}
--- Balance: {this.Balance:F2}
--- Bank: {this.BankName}
--- SWIFT: {this.SwiftCode}";
        }
    }
}
