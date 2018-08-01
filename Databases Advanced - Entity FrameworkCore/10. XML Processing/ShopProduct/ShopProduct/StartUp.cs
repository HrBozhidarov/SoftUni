using AutoMapper;
using ShopProduct.Data;
using ShopProduct.Dtos;
using ShopProduct.Dtos.Export;
using ShopProduct.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ShopProductContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ShopPorductProfile>();
            });

            var mapper = config.CreateMapper();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //ImportDate
            //var xmlString = GetXmlLikeString("Input/users.xml");
            //
            //var ser = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            //
            //var userDtos = (UserDto[])ser.Deserialize(new StringReader(xmlString));
            //
            //InsertUsersInDatabase(context, userDtos, mapper);

            //var xmlString = GetXmlLikeString("Input/products.xml");
            //var ser = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            //var productDtos = (ProductDto[])ser.Deserialize(new StringReader(xmlString));
            //InsertProductsInDatabase(context, productDtos, mapper);

            //var xmlString = GetXmlLikeString("Input/categories.xml");
            //var ser = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            //var categoryDtos = (CategoryDto[])ser.Deserialize(new StringReader(xmlString));
            //InsertCategories(context, categoryDtos, mapper);

            //GenerateCategoryForEachProduct(context);

            //ExportData

            //--1
            //var sb = new StringBuilder();
            //var products = ProductsInRange(context);
            //
            //var serializer = new XmlSerializer(typeof(ProductExportDto[]), new XmlRootAttribute("products"));
            //
            //var removeNamespace = new XmlSerializerNamespaces();
            //removeNamespace.Add("", "");
            //
            //serializer.Serialize(new StringWriter(sb), products, removeNamespace);
            //
            //File.WriteAllText("Output/productsInRange.xml", sb.ToString());

            //--2
            //var sb = new StringBuilder();
            //var users = GetUsersThatHaveAtLeastASoldItem(context);
            //
            //var serializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("users"));
            //
            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");
            //
            //serializer.Serialize(new StringWriter(sb), users, ns);
            //
            //File.WriteAllText("Output/userSoldProducts.xml", sb.ToString());

            //--3
            //var sb = new StringBuilder();
            //var categories = GetCategoriesByProductsCount(context);

            //var serializer = new XmlSerializer(typeof(CategoryExmportDto[]), new XmlRootAttribute("categories"));

            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //serializer.Serialize(new StringWriter(sb), categories, ns);

            //File.WriteAllText("Output/categoryByProductCount.xml", sb.ToString());

            //--4
            var sb = new StringBuilder();
            var userRoot = GetQueryUsersAndProducts(context);

            var serializer = new XmlSerializer(typeof(UserRootDto));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), userRoot, ns);

            File.WriteAllText("Output/userAndProducts.xml", sb.ToString());
        }

        private static UserRootDto GetQueryUsersAndProducts(ShopProductContext context)
        {
            var userRoot = new UserRootDto
            {
                Count = context.Users.Where(x => x.SoldProducts.Count > 0).Count(),
                Users = context.Users.Where(x => x.SoldProducts.Count > 0)
                                   .Select(x => new UserExportXmlDto
                                   {
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       Age = x.Age.ToString(),
                                       SoldProduct =  new SoldProductDto
                                       {
                                           Count = x.SoldProducts.Count,
                                           Products = x.SoldProducts.Select(a=> new ProductExportDto
                                           {
                                               Name=a.Name,
                                               Price=a.Price,
                                           }).ToArray()
                                        }
                                   }).ToArray()};

            return userRoot;
        }

        private static CategoryExmportDto[] GetCategoriesByProductsCount(ShopProductContext context)
        {
            var categories = context.Categories
                                   .Select(x => new CategoryExmportDto
                                   {
                                       Name = x.Name,
                                       CountProduct = x.CategoryProducts.Count,
                                       AveragePrice = x.CategoryProducts.Average(z => z.Product.Price),
                                       TotalPrice = x.CategoryProducts.Sum(z => z.Product.Price).ToString("F2")
                                   }).OrderBy(x => x.CountProduct).ToArray();
            return categories;
        }

        private static UserExportDto[] GetUsersThatHaveAtLeastASoldItem(ShopProductContext context)
        {
            var users = context.Users
                             .Where(x => x.SoldProducts.Count > 0)
                             .Select(x => new UserExportDto
                             {
                                 FirstName = x.FirstName,
                                 LastName = x.LastName,
                                 Products = x.SoldProducts.Select(z => new ProductDto
                                 {
                                     Name = z.Name,
                                     Price = z.Price
                                 }).ToArray()
                             }).OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToArray();

            return users;
        }

        private static ProductExportDto[] ProductsInRange(ShopProductContext context)
        {
            var products = context.Products
                                  .Where(x => x.Price >= 1000 && x.Price <= 2000)
                                  .Select(x => new ProductExportDto
                                  {
                                      Name = x.Name,
                                      Price = x.Price,
                                      Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                                  })
                                  .OrderBy(X => X.Price)
                                  .ToArray();

            return products;
        }

        private static void GenerateCategoryForEachProduct(ShopProductContext context)
        {
            var prducts = context.Products.ToArray();

            var categoriesIds = context.Categories.Select(x => x.Id).ToArray();

            var categoryProducts = new List<CategoryProduct>();

            var rnd = new Random();

            var categoryLength = categoriesIds.Length;

            foreach (var prduct in prducts)
            {
                var categoryId = categoriesIds[rnd.Next(0, categoryLength)];

                categoryProducts.Add(new CategoryProduct
                {
                    CategoryId = categoryId,
                    ProductId = prduct.Id
                });
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void InsertCategories(ShopProductContext context, CategoryDto[] categoryDtos, IMapper mapper)
        {
            var categories = mapper.Map<Category[]>(categoryDtos);

            var listOfCategories = new List<Category>();

            foreach (var category in categories)
            {
                if (!IsValid(category))
                {
                    continue;
                }

                listOfCategories.Add(category);
            }

            context.Categories.AddRange(listOfCategories);

            context.SaveChanges();
        }

        private static void InsertProductsInDatabase(ShopProductContext context, ProductDto[] productDtos, IMapper mapper)
        {
            var userIds = context.Users.Select(x => x.Id).ToArray();
            var rnd = new Random();
            var products = mapper.Map<Product[]>(productDtos).ToArray();
            var listOfProducts = new List<Product>();
            var count = 0;

            foreach (var product in products)
            {
                if (!IsValid(product))
                {
                    continue;
                }

                var sellerId = userIds[rnd.Next(0, userIds.Length)];

                int? buyerId = sellerId;

                while (buyerId == sellerId)
                {
                    var currentByerId = userIds[rnd.Next(0, userIds.Length)];

                    buyerId = currentByerId;
                }

                if (count == 3)
                {
                    count = 0;

                    buyerId = null;
                }

                product.SellerId = sellerId;
                product.BuyerId = buyerId;

                count++;
            }

            context.Products.AddRange(products);

            context.SaveChanges();
        }

        private static string GetXmlLikeString(string path)
        {
            var xmlString = File.ReadAllText(path);

            return xmlString;
        }

        private static void InsertUsersInDatabase(ShopProductContext context, UserDto[] userDtos, IMapper mapper)
        {
            var users = mapper.Map<User[]>(userDtos);

            foreach (var user in users)
            {
                if (!IsValid(user))
                {
                    continue;
                }

                context.Users.Add(user);
            }

            context.SaveChanges();
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
