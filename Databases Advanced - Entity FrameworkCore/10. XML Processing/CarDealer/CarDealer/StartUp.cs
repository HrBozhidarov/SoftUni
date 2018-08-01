using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
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
            //var stringXml = GetXmlString("Import/suppliers.xml");

            //var serializer = new XmlSerializer(typeof(SupplierImportDto[]), new XmlRootAttribute("suppliers"));

            //var supplierDto = (SupplierImportDto[])serializer.Deserialize(new StringReader(stringXml));

            //InsertSupliersInDatabase(contex, supplierDto, mapper);

            //--2
            //var stringXml = GetXmlString("Import/parts.xml");
            //
            //var serializer = new XmlSerializer(typeof(PartsImportDto[]), new XmlRootAttribute("parts"));
            //
            //var partsImportDtos = (PartsImportDto[])serializer.Deserialize(new StringReader(stringXml));
            //
            //InsertPartsInDatabase(contex, partsImportDtos, mapper);

            //--3
            //SetSupplierToPart(contex);

            //--4
            //var stringXml = GetXmlString("Import/cars.xml");

            //var serialize = new XmlSerializer(typeof(CarImportDto[]),new XmlRootAttribute("cars"));

            //var carDtos = (CarImportDto[])serialize.Deserialize(new StringReader(stringXml));

            //InsertCarsInDatabase(contex, carDtos, mapper);

            //--5
            //SetPartsToCars(contex);

            //--6
            //var stringXml = GetXmlString("Import/customers.xml");

            //var serialize = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("customers"));

            //var customerDtos = (CustomerImportDto[])serialize.Deserialize(new StringReader(stringXml));

            //InsertCustomerInDatabase(contex, customerDtos, mapper);

            //7
            //SetSales(contex);

            //--export
            //--1
            //var sb = new StringBuilder();
            //var carDtos = GetCarsInRange(contex);

            //var serializer = new XmlSerializer(typeof(CarImportDto[]), new XmlRootAttribute("cars"));

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //serializer.Serialize(new StringWriter(sb), carDtos, ns);

            //File.WriteAllText("Export/cars.xml", sb.ToString());

            //--2
            //var sb = new StringBuilder();
            //var carDtos = GetCarByModel(contex);

            //var serializer = new XmlSerializer(typeof(CarExportDto[]), new XmlRootAttribute("cars"));

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //serializer.Serialize(new StringWriter(sb), carDtos, ns);

            //File.WriteAllText("Export/ferrari-cars.xml", sb.ToString());

            //--3
            //var sb = new StringBuilder();
            //var supplierDtos = GetSupplierAndThereCountPart(contex);

            //var serializer = new XmlSerializer(typeof(SupplierExportDto[]), new XmlRootAttribute("suppliers"));

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //serializer.Serialize(new StringWriter(sb), supplierDtos, ns);

            //File.WriteAllText("Export/local-suppliers.xml", sb.ToString());

            //--4
            //var sb = new StringBuilder();
            //var carExportPartDto = GetAllCarsAndThereParts(contex);

            //var serializer = new XmlSerializer(typeof(CarExportPartDto[]), new XmlRootAttribute("cars"));

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //serializer.Serialize(new StringWriter(sb), carExportPartDto, ns);

            //File.WriteAllText("Export/cars-and-parts.xml", sb.ToString());

            //--5
            //var sb = new StringBuilder();
            //var customerDtos = TotalSalesByCustomer(contex);

            //var serializer = new XmlSerializer(typeof(CustomerExcercice5Dto[]), new XmlRootAttribute("customers"));

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //serializer.Serialize(new StringWriter(sb), customerDtos, ns);

            //File.WriteAllText("Export/customers-total-sales.xml", sb.ToString());

            //--6

            var sb = new StringBuilder();
            var salesDtos = SalesWhithApplyedDiscount(contex);

            var serializer = new XmlSerializer(typeof(SaleExercice6Dto[]), new XmlRootAttribute("sales"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), salesDtos, ns);

            File.WriteAllText("Export/sales-discounts.xml", sb.ToString());
        }

        private static SaleExercice6Dto[] SalesWhithApplyedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                             .Select(s => new SaleExercice6Dto
                             {
                                 Car = new CarExercice6Dto
                                 {
                                     Make = s.Car.Make,
                                     Model = s.Car.Model,
                                     TravelledDistance = s.Car.TravelledDistance
                                 },
                                 CustomerName = s.Customer.Name,
                                 Discount = (s.Customer.IsYoungDriver ? (decimal)s.Discount + 0.05M : (decimal)s.Discount),
                                 Price = s.Car.PartCars.Sum(x => x.Part.Price),
                                 PriceWhitDiscount = s.Car.PartCars.Sum(x => x.Part.Price) -
                                 (s.Car.PartCars.Sum(x => x.Part.Price) * (s.Customer.IsYoungDriver ? ((decimal)s.Discount + 0.05m) : (decimal)s.Discount))
                             })
                             .ToArray();

            return sales;
        }

        private static CustomerExcercice5Dto[] TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                                  .Where(x => x.Sales.Count > 0)
                                  .Select(x => new CustomerExcercice5Dto
                                  {
                                      FullName = x.Name,
                                      BoughtCars = x.Sales.Count,
                                      SpendMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(cp => cp.Part.Price))
                                  })
                                  .OrderByDescending(x => x.SpendMoney)
                                  .ThenByDescending(x => x.BoughtCars)
                                  .ToArray();

            return customers;
        }

        private static CarExportPartDto[] GetAllCarsAndThereParts(CarDealerContext context)
        {
            var cars = context.Cars
                             .Select(x => new CarExportPartDto
                             {
                                 Make = x.Make,
                                 Model = x.Model,
                                 TravelledDistance = x.TravelledDistance,
                                 Parts = x.PartCars.Select(z => new PartExportDto
                                 {
                                     Name = z.Part.Name,
                                     Price = z.Part.Price
                                 }).ToArray()
                             })
                             .ToArray();

            return cars;
        }

        private static SupplierExportDto[] GetSupplierAndThereCountPart(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                 .Where(x => x.IsImporter == false)
                                 .Select(x => new SupplierExportDto
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     PartsCount = x.Parts.Count
                                 })
                                 .ToArray();

            return suppliers;
        }

        private static CarExportDto[] GetCarByModel(CarDealerContext context)
        {
            var cars = context.Cars
                             .Where(x => x.Make == "Ferrari")
                             .OrderBy(x => x.Model)
                             .ThenByDescending(x => x.TravelledDistance)
                             .Select(x => new CarExportDto
                             {
                                 Id = x.Id,
                                 Model = x.Model,
                                 TravelledDistance = x.TravelledDistance
                             })
                             .ToArray();

            return cars;
        }

        private static CarImportDto[] GetCarsInRange(CarDealerContext context)
        {
            var cars = context.Cars
                               .Where(x => x.TravelledDistance > 2000000)
                               .OrderBy(x => x.Make)
                               .ThenBy(x => x.Model)
                               .Select(x => new CarImportDto
                               {
                                   Make = x.Make,
                                   Model = x.Model,
                                   TravelledDistance = x.TravelledDistance
                               })
                               .ToArray();

            return cars;
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
