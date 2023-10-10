using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository:IProductRepository
    {
        public void DeleteProduct(Product p) => ProductDao.DeleteProduct(p);
        public void SaveProduct(Product p) => ProductDao.SaveProduct(p);
        public void UpdateProduct(Product p) => ProductDao.UpdateProduct(p);
        public List<Category> GetCategorys() => CategoryDao.GetCategorys();
        public List<Product> GetProducts() => ProductDao.GetProducts();
        public Product GetProductById(int id) => ProductDao.FindProductById(id);
    }
}
