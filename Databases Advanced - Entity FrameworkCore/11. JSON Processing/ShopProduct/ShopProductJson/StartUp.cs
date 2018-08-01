using AutoMapper;
using Newtonsoft.Json;
using ShopProduct.Data;
using ShopProduct.Dtos;
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
            //--1
            //var jsonString = File.ReadAllText("Input/users.json");

            //var userDtos = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            //InsertUsersInDatabase(context, userDtos, mapper);

            //--2
            //var jsonString = File.ReadAllText("Input/products.json");

            //var productDtos = JsonConvert.DeserializeObject<ProductDto[]>(jsonString);

            //InsertProductsInDatabase(context, productDtos, mapper);

            //--3
            //var jsonString = File.ReadAllText("Input/categories.json");

            //var categoryDtos = JsonConvert.DeserializeObject<CategoryDto[]>(jsonString);

            //InsertCategories(context, categoryDtos, mapper);

            //--4
            //GenerateCategoryForEachProduct(context);

            //ExportData
            //--1
           // ProductsInRange(context);

            //--2
           // SuccessfullySoldProducts(context);

            //--3
           // CategoriesByProductsCount(context);

            //4
            //UsersAndProducts(context);
        }

        private static void UsersAndProducts(ShopProductContext context)
        {
            var user = context.Users
                             .Where(x => x.SoldProducts.Any(c => c.Buyer != null))
                             .OrderByDescending(x => x.SoldProducts.Count)
                             .ThenBy(x => x.LastName)
                             .Select(x => new
                             {
                                 firstName = x.FirstName,
                                 lastName = x.LastName,
                                 age = x.Age,
                                 soldProducts = new
                                 {
                                     count = x.SoldProducts.Count,
                                     products = x.SoldProducts.Select(z => new
                                     {
                                         name = z.Name,
                                         price = z.Price
                                     }).ToArray()
                                 }
                             }).ToArray();

            var obj = new
            {
                usersCount = context.Users
                             .Where(x => x.SoldProducts.Any(c => c.Buyer != null)).Count(),
                users= user
            };

            var serializer = JsonConvert.SerializeObject(obj, Formatting.Indented);

            File.WriteAllText("Output/users-and-products.json", serializer);
        }

        private static void CategoriesByProductsCount(ShopProductContext context)
        {
            var categories = context.Categories
                                  .OrderBy(x => x.Name)
                                  .Select(x => new
                                  {
                                      name = x.Name,
                                      productsCount = x.CategoryProducts.Count,
                                      averagePrice = x.CategoryProducts.Sum(z => z.Product.Price) / x.CategoryProducts.Count,
                                      totalRevenue = x.CategoryProducts.Sum(z => z.Product.Price)
                                  });

            var serialize = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText("Output/categories-by-products.json", serialize);
        }

        private static void SuccessfullySoldProducts(ShopProductContext context)
        {
            var users = context.Users
                               .Where(x => x.SoldProducts.Any(c => c.Buyer != null))
                               .Select(x => new
                               {
                                   firstName = x.FirstName,
                                   lastName = x.LastName,
                                   soldProducts = x.SoldProducts.Where(s => s.Buyer != null)
                                                              .Select(c => new
                                                              {
                                                                  name = c.Name,
                                                                  price = c.Price,
                                                                  buyerFirstName = c.Buyer.FirstName,
                                                                  buyerLastName = c.Buyer.LastName
                                                              }).ToArray()
                               }).ToArray();

            var serialize = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("Output/users-sold-products.json", serialize);
        }

        private static void ProductsInRange(ShopProductContext context)
        {
            var products = context.Products
                                .Where(x => x.Price >= 500 && x.Price <= 1000)
                                .Select(x => new
                                {
                                    name = x.Name,
                                    price = x.Price,
                                    seller = x.Seller.FirstName + " " + x.Seller.LastName ?? x.Seller.LastName
                                })
                                .ToArray();

            var serializer = JsonConvert.SerializeObject(products, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });

            File.WriteAllText("Output/products-in-range.json", serializer);
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
