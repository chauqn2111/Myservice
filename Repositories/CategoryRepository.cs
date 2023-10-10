using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        public void DeleteCategory(Category c) => CategoryDao.DeleteCategory(c);
        public void SaveCategory(Category c) => CategoryDao.SaveCategory(c);
        public void UpdateCategory(Category c) => CategoryDao.UpdateCategory(c);
        public List<Category> GetCategorys() => CategoryDao.GetCategorys();
        public List<Product> GetProducts() => ProductDao.GetProducts();
        public Category GetCategoryById(int id) => CategoryDao.FindCategoryById(id);
    }
}
