using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillsPaymentSystem.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "BankAccountId", "Balance", "BankName", "SwiftCode" },
                values: new object[,]
                {
                    { 1, 2455m, "SG Expresbank", "TGBHJKL" },
                    { 2, 12000m, "Investbank", "TBGINKFL" },
                    { 3, 14000m, "DSK", "TBGDSK" },
                    { 4, 8500m, "Raiffensen bank", "TBGFRF" }
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CreditCardId", "ExpirationDate", "Limit", "MoneyOwed" },
                values: new object[,]
                {
                    { 1, new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000.00m, 1500.00m },
                    { 2, new DateTime(2018, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m, 1800m },
                    { 3, new DateTime(2016, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, 14000m },
                    { 4, new DateTime(2011, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000m, 4500m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "pinko@abv.bg", "Pinko", "Ivanov", "123" },
                    { 2, "Sedefcho@gmail.com", "Sedefcho", "Petrov", "234" },
                    { 3, "Trendafil@yahoo.com", "Trendafil", "Todorov", "345" },
                    { 4, "dragana@bnr.bg", "Dragana", "Borisova", "456" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "BankAccountId", "CreditCardId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, "BankAccount", 1 },
                    { 2, 2, null, "BankAccount", 1 },
                    { 3, null, 1, "CreditCard", 1 },
                    { 4, null, 2, "CreditCard", 2 },
                    { 5, 3, null, "BankAccount", 3 },
                    { 6, null, 3, "CreditCard", 3 },
                    { 7, null, 4, "CreditCard", 3 },
                    { 8, 4, null, "BankAccount", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankAccountId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankAccountId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankAccountId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankAccountId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);
        }
    }
}
