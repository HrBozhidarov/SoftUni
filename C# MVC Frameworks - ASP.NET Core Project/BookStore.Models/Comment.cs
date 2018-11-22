using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
