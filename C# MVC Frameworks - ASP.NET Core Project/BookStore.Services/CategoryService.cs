using BookStore.Data;
using BookStore.Models;
using BookStore.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookStoreContext db;

        public CategoryService(BookStoreContext db)
        {
            this.db = db;
        }

        public void Create(string categoryName)
        {
            if (!this.db.Categories.Any(c => c.Name == categoryName))
            {
                this.db.Categories.Add(new Category
                {
                    Name = categoryName
                });

                this.db.SaveChanges();
            }
        }

        public bool IfCategoryExists(string categoryName)
        {
            if (this.db.Categories.Any(x => x.Name == categoryName))
            {
                return true;
            }

            return false;
        }
    }
}
