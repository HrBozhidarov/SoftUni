using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.DataSeed
{
    public class BankAccountSeed
    {
        public BankAccount[] Seed()
        {
            var bankAccounts = new[]
            {
                new BankAccount(1, 2455m, "SG Expresbank", "TGBHJKL"),
                new BankAccount(2, 12000m, "Investbank", "TBGINKFL"),
                new BankAccount(3, 14000m, "DSK", "TBGDSK"),
                new BankAccount(4, 8500m, "Raiffensen bank", "TBGFRF")
            };

            return bankAccounts;
        }
    }
}
