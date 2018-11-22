using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class Author
    {
        public Author()
        {
            this.BooksAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public ICollection<BookAuthor> BooksAuthors { get; set; }
    }
}
