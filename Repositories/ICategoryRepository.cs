using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        void SaveCategory(Category c);
        Category GetCategoryById(int id);
        void DeleteCategory(Category c);
        void UpdateCategory(Category c);
        List<Category> GetCategorys();
        List<Product> GetProducts();
    }
}
