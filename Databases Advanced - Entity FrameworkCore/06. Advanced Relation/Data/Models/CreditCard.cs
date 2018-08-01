using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public CreditCard()
        {

        }

        public CreditCard(int creditCardId, DateTime expirationDate, decimal limit, decimal moneyOwed)
        {
            this.CreditCardId = creditCardId;
            this.ExpirationDate = expirationDate;
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
        }

        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public decimal LimitLef => this.Limit - this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Limit)
            {
                throw new InvalidOperationException($"Can not witdraw {amount} becase Your current limit is {this.Limit}!");
            }

            if (amount < 0)
            {
                throw new InvalidOperationException("You can not deposit negative amount");
            }

            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("You can not deposit negative amount");
            }

            this.MoneyOwed -= amount;
        }

        public override string ToString()
        {
            var mounth = this.ExpirationDate.Month.ToString().Length == 2 ? this.ExpirationDate.Month.ToString() : "0" + this.ExpirationDate.Month.ToString();

            return $@"-- ID: {this.CreditCardId}
--- Limit: {this.Limit:F2}
--- Money Owed: {this.MoneyOwed:F2}
--- Limit Left:: {this.LimitLef:F2}
--- Expiration Date: {this.ExpirationDate.Year}/{mounth}
";
        }
    }
}
