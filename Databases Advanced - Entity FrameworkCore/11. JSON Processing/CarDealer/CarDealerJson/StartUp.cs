using AutoMapper;
using CarDealer;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealerJson
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var contex = new CarDealerContext();

            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            //--1
            //var stringJson = GetXmlString("Import/suppliers.json");

            //var supplierDto = JsonConvert.DeserializeObject<SupplierImportDto[]>(stringJson);

            //InsertSupliersInDatabase(contex, supplierDto, mapper);

            //--2
            //var stringJson = GetXmlString("Import/parts.json");

            //var partDtos = JsonConvert.DeserializeObject<PartsImportDto[]>(stringJson);

            //InsertPartsInDatabase(contex, partDtos, mapper);

            //--3
            //SetSupplierToPart(contex);

            //--4
            //var stringJson = GetXmlString("Import/cars.json");

            //var carDtos = JsonConvert.DeserializeObject<CarImportDto[]>(stringJson);

            //InsertCarsInDatabase(contex, carDtos, mapper);

            //--5
            //SetPartsToCars(contex);

            //--6
            //var stringJson = GetXmlString("Import/customers.json");

            //var customerDto = JsonConvert.DeserializeObject<CustomerImportDto[]>(stringJson);

            //InsertCustomerInDatabase(contex, customerDto, mapper);

            //7
            //SetSales(contex);

            //export

            //-1
            //OrderedCustomers(contex);

            //--2
            //CarsFromMakeToyota(contex);

            //--3
            //LocalSuppliers(contex);

            //--4
            //CarsWithTheirListOfParts(contex);

            //--5
            //TotalSalesByCustomer(contex);

            //--6
            SalesWithAppliedDiscount(contex);
        }

        private static void SalesWithAppliedDiscount(CarDealerContext contex)
        {
            var sales = contex.Sales
                            .Select(x => new
                            {
                                car = new
                                {
                                    x.Car.Make,
                                    x.Car.Model,
                                    x.Car.TravelledDistance
                                },
                                x.Customer.Name,
                                Discount = x.Customer.IsYoungDriver ? x.Discount + 0.05m : x.Discount,
                                price = x.Car.PartCars.Sum(z => z.Part.Price),
                                priceWithDiscount = x.Car.PartCars.Sum(z => z.Part.Price) - (x.Car.PartCars.Sum(z => z.Part.Price) * (x.Customer.IsYoungDriver ? x.Discount + 0.05m : x.Discount))
                            })
                            .ToArray();

            var serializer = JsonConvert.SerializeObject(sales, Formatting.Indented);

            File.WriteAllText("Export/sales-discounts.json", serializer);
        }

        private static void TotalSalesByCustomer(CarDealerContext contex)
        {
            var customers = contex.Customers
                                .Where(x => x.Sales.Any())
                                .Select(x => new
                                {
                                    fullName = x.Name,
                                    boughtCars = x.Sales.Count(),
                                    spentMoney = x.Sales.Sum(z => z.Car.PartCars.Sum(c => c.Part.Price))
                                })
                                .OrderByDescending(x => x.spentMoney)
                                .ThenByDescending(x => x.boughtCars)
                                .ToArray();

            var serializer = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText("Export/customers-total-sales.json", serializer);
        }

        private static void CarsWithTheirListOfParts(CarDealerContext contex)
        {
            var carsAndParts = contex.Cars
                                   .Select(x => new
                                   {
                                       car = new
                                       {
                                           x.Make,
                                           x.Model,
                                           x.TravelledDistance
                                       },
                                       parts = x.PartCars.Select(z => new
                                       {
                                           z.Part.Name,
                                           z.Part.Price
                                       }).ToArray()

                                   })
                                   .ToArray();

            var serializer = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);

            File.WriteAllText("Export/cars-and-parts.json", serializer);
        }

        private static void LocalSuppliers(CarDealerContext contex)
        {
            var suppliers = contex.Suppliers
                                .Where(x => x.IsImporter == false)
                                .Select(x => new
                                {
                                    x.Id,
                                    x.Name,
                                    x.Parts.Count
                                })
                                .ToArray();

            var serializer = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            File.WriteAllText("Export/local-suppliers.json", serializer);
        }

        private static void CarsFromMakeToyota(CarDealerContext contex)
        {
            var cars = contex.Cars
                             .Where(x => x.Make == "Toyota")
                             .OrderBy(x => x.Model)
                             .ThenByDescending(x => x.TravelledDistance)
                             .Select(x => new
                             {
                                 x.Id,
                                 x.Make,
                                 x.Model,
                                 x.TravelledDistance
                             })
                             .ToArray();

            var serializer = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText("Export/toyota-cars.json", serializer);
        }

        private static void OrderedCustomers(CarDealerContext contex)
        {
            var customers = contex.Customers
                                .OrderBy(x => x.BirthDate)
                                .ThenBy(x => x.IsYoungDriver)
                                .Select(x => new
                                {
                                    x.Id,
                                    x.Name,
                                    x.BirthDate,
                                    x.IsYoungDriver,
                                    Sales = x.Sales.ToArray()
                                }).ToArray();

            var serializer = JsonConvert.SerializeObject(customers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            File.WriteAllText("Export/ordered-customers.json", serializer);

        }

        private static void SetSales(CarDealerContext contex)
        {
            var rnd = new Random();
            var customerIds = contex.Customers.Select(x => x.Id).ToArray();
            var lengthCustomerIds = customerIds.Length;
            var carIds = contex.Cars.Select(x => x.Id).ToArray();
            var lengthCarIds = carIds.Length;
            var discounts = new decimal[] { 0, 0.05m, 0.1m, 0.15m, 0.2m, 0.3m, 0.4m, 0.5m };
            var lengthDiscounts = discounts.Length;
            var saveCarIds = new HashSet<int>();
            var saveCustomerIds = new HashSet<int>();

            var sales = new List<Sale>();

            for (int i = 0; i < 100; i++)
            {
                while (true)
                {
                    var currentCustomerId = customerIds[rnd.Next(0, lengthCustomerIds)];
                    var currentCarId = carIds[rnd.Next(0, lengthCarIds)];
                    var currentDiscount = discounts[rnd.Next(0, lengthDiscounts)];

                    if (!(saveCustomerIds.Contains(currentCustomerId) && saveCarIds.Contains(currentCarId)))
                    {
                        saveCarIds.Add(currentCarId);
                        saveCustomerIds.Add(currentCustomerId);

                        //var customer = contex.Customers.Find(currentCustomerId);

                        //if (customer.IsYoungDriver)
                        //{
                        //    currentDiscount += 0.05;
                        //}

                        sales.Add(new Sale
                        {
                            CarId = currentCarId,
                            CustomerId = currentCustomerId,
                            Discount = currentDiscount
                        });

                        break;
                    }
                }
            }

            contex.Sales.AddRange(sales);

            contex.SaveChanges();
        }

        private static void InsertCustomerInDatabase(CarDealerContext contex, CustomerImportDto[] customerDtos, IMapper mapper)
        {
            var customers = mapper.Map<Customer[]>(customerDtos);

            contex.AddRange(customers);

            contex.SaveChanges();
        }

        private static void SetPartsToCars(CarDealerContext context)
        {
            var cars = context.Cars.ToArray();
            var listOfPartCarts = new List<PartCar>();
            var parts = context.Parts.Select(x => x.Id).ToArray();

            var rnd = new Random();

            var counter = rnd.Next(10, 21);

            foreach (var car in cars)
            {
                var listOfIndex = new List<int>();

                while (counter >= 0)
                {
                    var partId = parts[rnd.Next(0, parts.Length)];

                    if (!listOfIndex.Contains(partId))
                    {
                        listOfIndex.Add(partId);

                        listOfPartCarts.Add(new PartCar
                        {
                            CarId = car.Id,
                            PartId = partId
                        });

                        counter--;
                    }
                }

                counter = rnd.Next(10, 21);
            }

            context.PartCars.AddRange(listOfPartCarts);

            context.SaveChanges();
        }

        private static void InsertCarsInDatabase(CarDealerContext context, CarImportDto[] carsImportDto, IMapper mapper)
        {
            var cars = mapper.Map<Car[]>(carsImportDto);

            context.AddRange(cars);

            context.SaveChanges();
        }

        private static void SetSupplierToPart(CarDealerContext context)
        {
            var supplierIds = context.Suppliers.Select(x => x.Id).ToArray();
            var parts = context.Parts.ToArray();
            var rnd = new Random();

            foreach (var part in parts)
            {
                var index = rnd.Next(0, supplierIds.Length);

                part.SupplierId = supplierIds[index];
            }

            context.SaveChanges();
        }

        private static void InsertPartsInDatabase(CarDealerContext context, PartsImportDto[] partsImportDto, IMapper mapper)
        {
            var parts = mapper.Map<Part[]>(partsImportDto);

            context.Parts.AddRange(parts);

            context.SaveChanges();
        }

        private static void InsertSupliersInDatabase(CarDealerContext context, SupplierImportDto[] supplierDtos, IMapper mapper)
        {
            var suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();
        }

        private static string GetXmlString(string path)
        {
            var reader = File.ReadAllText(path);

            return reader;
        }
    }
}
