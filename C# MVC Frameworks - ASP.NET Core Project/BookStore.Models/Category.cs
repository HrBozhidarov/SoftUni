using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class Category
    {
        public Category()
        {
            this.BooksCategories= new HashSet<BookCategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookCategory> BooksCategories { get; set; }
    }
}
