using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var type = Enum.Parse<OrderType>(orderType);

            var orders = context.Orders
                .Where(o => o.Employee.Name == employeeName)
                .Select(o => new
                {
                    o.Customer,
                    Items = o.OrderItems.Where(x => x.Order.Type == type)
                        .Select(oi => new
                        {
                            oi.Item.Name,
                            oi.Item.Price,
                            oi.Quantity
                        }).ToArray(),
                    TotalPrice = o.OrderItems
                        .Sum(oi => oi.Quantity * oi.Item.Price)
                }).ToArray()
                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Count())
                .ToList();

            var result = new
            {
                Name = employeeName,
                Orders = orders,
                TotalMade = orders.Sum(o => o.TotalPrice)
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoires = categoriesString.Split(',');

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CategoryExportDto[]), new XmlRootAttribute("Categories"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var categoriesResult = context.Categories.Where(x => categoires.Contains(x.Name))
                                        .Select(x => new CategoryExportDto
                                        {
                                            Name = x.Name,
                                            MostPopularItem = x.Items.Select(s => new ItemExportDto
                                            {
                                                Name = s.OrderItems.Where(w=>x.Items.Where(q=>q.Id==w.ItemId).FirstOrDefault()!=null).Select(w=>w.Item.Name).FirstOrDefault(),
                                                TotalMade = s.OrderItems.Sum(q => q.Quantity) * s.Price,
                                                TimesSold = s.OrderItems.Sum(q => q.Quantity)
                                            }).OrderByDescending(o => o.TotalMade).FirstOrDefault()
                                        }).OrderByDescending(l => l.MostPopularItem.TotalMade).ThenByDescending(l => l.MostPopularItem.TimesSold).ToArray();

            serializer.Serialize(new StringWriter(sb), categoriesResult, ns);

            return sb.ToString().Trim();
        }
    }
}