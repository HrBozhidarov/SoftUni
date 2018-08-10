using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessMessageXml = "Order for {0} on {1} added";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var sb = new StringBuilder();

            var listOfEmployees = new List<Employee>();

            var listOfPosition = new List<Position>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                var position = listOfPosition.FirstOrDefault(x => x.Name == userDto.Position);

                if (position == null)
                {
                    var currentPosition = new Position
                    {
                        Name = userDto.Position
                    };

                    listOfEmployees.Add(new Employee
                    {
                        Name = userDto.Name,
                        Age = userDto.Age.Value,
                        Position = currentPosition
                    });

                    listOfPosition.Add(currentPosition);
                }
                else
                {
                    listOfEmployees.Add(new Employee
                    {
                        Name = userDto.Name,
                        Age = userDto.Age.Value,
                        Position = position
                    });
                }

                sb.AppendLine(string.Format(SuccessMessage, userDto.Name));
            }

            context.Employees.AddRange(listOfEmployees);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var itemDtos = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var sb = new StringBuilder();

            var listOfItems = new List<Item>();

            var listOfCategories = new List<Category>();

            foreach (var itemDto in itemDtos)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                if (listOfItems.Any(x => x.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                var category = listOfCategories.FirstOrDefault(x => x.Name == itemDto.Category);

                if (category == null)
                {
                    var currentCategory = new Category
                    {
                        Name = itemDto.Category
                    };

                    listOfItems.Add(new Item
                    {
                        Name = itemDto.Name,
                        Price = itemDto.Price,
                        Category = currentCategory
                    });

                    listOfCategories.Add(currentCategory);
                }
                else
                {
                    listOfItems.Add(new Item
                    {
                        Name = itemDto.Name,
                        Price = itemDto.Price,
                        Category = category
                    });
                }

                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }

            context.Items.AddRange(listOfItems);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var ser = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));

            var orderDtos = (OrderDto[])ser.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var listOfOrdetItems = new List<OrderItem>();

            foreach (var orderDto in orderDtos)
            {
                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                //var ifOrdersItemAreValid = orderDto.OrderItems.All(x => IsValid(x));

                if (!IsValid(orderDto.OrderItems))
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                var employee = context.Employees.FirstOrDefault(x => x.Name == orderDto.Employee);

                var ifItemsAreValid = IfItemsAreValid(orderDto.OrderItems, context);

                if (!ifItemsAreValid || employee == null)
                {
                    sb.AppendLine(FailureMessage);

                    continue;
                }

                var dateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var type = Enum.Parse<OrderType>(orderDto.Type);

                var order = new Order
                {
                    Customer = orderDto.Customer,
                    DateTime = dateTime,
                    Type = type,
                    Employee = employee
                };

                foreach (var item in orderDto.OrderItems)
                {
                    var currentItem = context.Items.First(x => x.Name == item.Name);

                    listOfOrdetItems.Add(new OrderItem
                    {
                        Order = order,
                        Item = currentItem,
                        Quantity = item.Quantity
                    });
                }

                sb.AppendLine(string.Format(SuccessMessageXml, orderDto.Customer, dateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.OrderItems.AddRange(listOfOrdetItems);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IfItemsAreValid(OrderItemDto[] orderItems, FastFoodDbContext context)
        {
            foreach (var orderItem in orderItems)
            {
                if (!context.Items.Any(x => x.Name == orderItem.Name))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            ICollection<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            return isValid;
        }
    }
}