using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.DataSeed
{
    public class PaymentMethodSeed
    {
        public PaymentMethod[] Seed()
        {
            var paymentMethods = new[]
            {
                new PaymentMethod
                {
                    Id = 1,
                    UserId = 1,
                    Type = Data.Models.Type.BankAccount,
                    BankAccountId = 1
                },

                new PaymentMethod
                {
                    Id = 2,
                    UserId = 1,
                    Type = Data.Models.Type.BankAccount,
                    BankAccountId = 2
                },

                new PaymentMethod
                {
                    Id = 3,
                    UserId = 1,
                    Type = Data.Models.Type.CreditCard,
                    CreditCardId = 1
                },

                new PaymentMethod
                {
                    Id = 4,
                    UserId = 2,
                    Type = Data.Models.Type.CreditCard,
                    CreditCardId = 2
                },

                new PaymentMethod
                {
                    Id = 5,
                    UserId = 3,
                    Type = Data.Models.Type.BankAccount,
                    BankAccountId = 3
                },

                new PaymentMethod
                {
                    Id = 6,
                    UserId = 3,
                    Type = Data.Models.Type.CreditCard,
                    CreditCardId = 3
                },

                new PaymentMethod
                {
                    Id = 7,
                    UserId = 3,
                    Type = Data.Models.Type.CreditCard,
                    CreditCardId = 4
                },

                new PaymentMethod
                {
                    Id = 8,
                    UserId = 4,
                    Type = Data.Models.Type.BankAccount,
                    BankAccountId = 4
                }
            };

            return paymentMethods;
        }
    }
}
