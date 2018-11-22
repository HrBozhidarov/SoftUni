using BookStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class Book
    {
        public Book()
        {
            this.BooksCategories = new HashSet<BookCategory>();
            this.Comments = new HashSet<Comment>();
            this.OrderBooks = new HashSet<OrderBook>();
            this.BooksAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Img { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<OrderBook> OrderBooks { get; set; }

        public ICollection<BookCategory> BooksCategories { get; set; }

        public ICollection<BookAuthor> BooksAuthors { get; set; }
    }
}
