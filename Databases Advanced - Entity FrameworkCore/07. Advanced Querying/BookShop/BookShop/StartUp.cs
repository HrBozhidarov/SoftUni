namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // DbInitializer.ResetDatabase(db);

                //--1
                //var command = Console.ReadLine();
                //
                //Console.WriteLine(GetBooksByAgeRestriction(db, command));

                //--2
                //Console.WriteLine(GetGoldenBooks(db));

                //--3
                //Console.WriteLine(GetBooksByPrice(db));

                //--4
                //var year = int.Parse(Console.ReadLine());
                //
                //Console.WriteLine(GetBooksNotRealeasedIn(db, year));

                //--5
                var input = Console.ReadLine();
                
                Console.WriteLine(GetBooksByCategory(db, input));

                //--6
                //var date = Console.ReadLine();
                //
                //Console.WriteLine(GetBooksReleasedBefore(db, date));

                //--7
                //var input = Console.ReadLine();
                //
                //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                //--8
                //var input = Console.ReadLine();
                //
                //Console.WriteLine(GetBookTitlesContaining(db, input));

                //--9
                //var input = Console.ReadLine();
                //
                //Console.WriteLine(GetBooksByAuthor(db, input));

                //--10
                //var lengthCheck = int.Parse(Console.ReadLine());
                //
                //Console.WriteLine(CountBooks(db, lengthCheck));

                //--11
                //Console.WriteLine(CountCopiesByAuthor(db));

                //--12
                //Console.WriteLine(GetTotalProfitByCategory(db));

                //--13
                //Console.WriteLine(GetMostRecentBooks(db));

                //--14
                //IncreasePrices(db);

                //--15
                //Console.WriteLine($"{RemoveBooks(db)} books were deleted");
            }
        }

        //--1
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var currentRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                            .Where(x => x.AgeRestriction == currentRestriction)
                            .Select(x => x.Title)
                            .OrderBy(x => x)
                            .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //--2
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                               .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                               .OrderBy(x => x.BookId)
                               .Select(x => x.Title)
                               .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //--3
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                              .Where(x => x.Price > 40)
                              .OrderByDescending(x => x.Price)
                              .Select(x => $"{x.Title} - ${x.Price:F2}")
                              .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //--4
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                               .Where(x => x.ReleaseDate.Value.Year != year)
                               .OrderBy(x => x.BookId)
                               .Select(x => x.Title)
                               .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //--5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => x.ToLower())
                                  .ToArray();

            //var books1 = context.Books
            //                 .Include(x => x.BookCategories)
            //                 .ThenInclude(x => x.Category)
            //                 .Where(x => x.BookCategories.Any(z => categories.Contains(z.Category.Name.ToLower())))
            //                 .ToArray();

            //why work withouth include
            var books = context.Books
                             .Where(x => x.BookCategories.Any(z => categories.Contains(z.Category.Name.ToLower())))
                             .Select(x => x.Title)
                             .OrderBy(x => x)
                             .ToArray();

            return string.Join(Environment.NewLine, books);

            //var categoryBooks = context.Categories
            //                         .Include(x => x.CategoryBooks)
            //                         .ThenInclude(x => x.Book)
            //                         .Where(x => categories.Contains(x.Name.ToLower()))
            //                         .Select(x => x.CategoryBooks.Select(z => z.Book.Title))
            //                         .ToArray();

            //var listRes = new List<string>();

            //foreach (var collection in categoryBooks)
            //{
            //    foreach (var item in collection)
            //    {
            //        listRes.Add(item);
            //    }
            //}

            //return string.Join(Environment.NewLine, listRes.OrderBy(x => x));
        }

        //--6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var compareDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                               .Where(x => x.ReleaseDate < compareDate)
                               .OrderByDescending(x => x.ReleaseDate)
                               .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}")
                               .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //--7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                               .Where(x => x.FirstName.EndsWith(input))
                               .Select(x => $"{x.FirstName} {x.LastName}")
                               .OrderBy(x => x)
                               .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        //--8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                              .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                              .Select(x => x.Title)
                              .OrderBy(x => x)
                              .ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        //--9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titlesAndThereAuthors = context.Books
                               .Include(x => x.Author)
                               .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                               .OrderBy(x => x.BookId)
                               .Select(x => $"{x.Title} ({x.Author.FirstName + " " + x.Author.LastName})")
                               .ToArray();

            return string.Join(Environment.NewLine, titlesAndThereAuthors);
        }

        //--10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                                  .Where(x => x.Title.Length > lengthCheck)
                                  .ToArray();

            return booksCount.Count();
        }

        //--11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                               .Include(x => x.Books)
                               .OrderByDescending(x => x.Books.Select(z => z.Copies).Sum())
                               .Select(x => $"{x.FirstName} {x.LastName} - {x.Books.Select(z => z.Copies).Sum()}");


            return string.Join(Environment.NewLine, authors);
        }

        //--12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                               .Select(x => new
                               {
                                   x.Name,
                                   Sum = x.CategoryBooks.Select(z => z.Book.Copies * z.Book.Price).Sum()
                               })
                               .OrderByDescending(x => x.Sum)
                               .ThenBy(x => x.Name)
                               .ToArray();

            return string.Join(Environment.NewLine, result.Select(x => $"{x.Name} ${x.Sum:F2}"));
        }

        //--13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryAndThereBooks = context.Categories
                                             .Select(x => new
                                             {
                                                 x.Name,
                                                 Books = x.CategoryBooks.Select(z => new
                                                 {
                                                     z.Book.Title,
                                                     z.Book.ReleaseDate
                                                 })
                                                 .OrderByDescending(z => z.ReleaseDate)
                                                 .Take(3)
                                             })
                                             .OrderBy(x => x.Name)
                                             .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categoryAndThereBooks)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        //--14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                             .Where(x => x.ReleaseDate.Value.Year < 2010)
                             .ToArray();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //--15
        public static int RemoveBooks(BookShopContext context)
        {
            var initialCount = context.Books.Count();

            var removeBooks = context.Books.Where(x => x.Copies < 4200).ToArray();

            context.Books.RemoveRange(removeBooks);

            context.SaveChanges();

            var countAfter = initialCount - (context.Books.Count());

            return countAfter;
        }
    }
}
