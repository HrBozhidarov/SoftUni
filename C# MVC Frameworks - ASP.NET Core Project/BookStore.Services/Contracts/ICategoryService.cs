using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Services.Contracts
{
    public interface ICategoryService
    {
        void Create(string categoryName);

        bool IfCategoryExists(string categoryName);
    }
}
