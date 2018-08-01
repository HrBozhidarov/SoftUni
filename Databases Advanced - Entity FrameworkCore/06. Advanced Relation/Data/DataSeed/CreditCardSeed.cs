using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.DataSeed
{
    public class CreditCardSeed
    {
        public CreditCard[] Seed()
        {
            var creditCards = new[]
           {
                new CreditCard(1, new DateTime(2017, 5, 1), 15000.00m, 1500.00m),
                new CreditCard(2, new DateTime(2018, 4, 8), 20000m, 1800m),
                new CreditCard(3, new DateTime(2016, 7, 17), 15000m, 14000m),
                new CreditCard(4, new DateTime(2011, 12, 25), 16000m, 4500m)
            };

            return creditCards;
        }
    }
}
