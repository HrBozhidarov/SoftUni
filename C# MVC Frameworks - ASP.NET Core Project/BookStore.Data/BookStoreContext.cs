using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : IdentityDbContext<User>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookAuthor> BooksAuthors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BookCategory> BooksCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderBook> OrdersBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCategory>()
                .HasKey(x => new { x.BookId, x.CategoryId });

            builder.Entity<BookCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.BooksCategories)
                .HasForeignKey(x => x.CategoryId);

            builder.Entity<BookCategory>()
               .HasOne(x => x.Book)
               .WithMany(x => x.BooksCategories)
               .HasForeignKey(x => x.BookId);

            builder.Entity<BookAuthor>()
               .HasKey(x => new { x.BookId, x.AuthorId });

            builder.Entity<BookAuthor>()
                .HasOne(x => x.Author)
                .WithMany(x => x.BooksAuthors)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<BookAuthor>()
               .HasOne(x => x.Book)
               .WithMany(x => x.BooksAuthors)
               .HasForeignKey(x => x.BookId);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
