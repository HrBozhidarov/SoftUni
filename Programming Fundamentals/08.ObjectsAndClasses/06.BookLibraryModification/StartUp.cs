﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }
        public decimal Price { get; set; }
    }

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var library = new Library();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var date = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var price = decimal.Parse(input[input.Length - 1]);
            var book = new Book();
            book.Title = input[0];
            book.Author = input[1];
            book.Publisher = input[2];
            book.ReleaseDate = date;
            book.IsbnNumber = input[4];
            book.Price = price;

            library.Books.Add(book);
        }

        var dateCompare = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

        var res = library.Books.Where(x => x.ReleaseDate > dateCompare).OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title).ToList();

        foreach (var item in res)
        {
            Console.WriteLine($"{item.Title} -> {item.ReleaseDate.ToString("dd.MM.yyyy")}");
        }
    }
}