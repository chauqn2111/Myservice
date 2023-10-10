using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDao
    {
        public static List<Category> GetCategorys()
        {
            var listCategorys = new List<Category>();
            try
            {
                using (var context = new MyDBContext())
                {
                    listCategorys = context.Categorys.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCategorys;
        }
        public static Category FindCategoryById(int cateId)
        {
            Category p = new Category();
            try
            {
                using (var context = new MyDBContext())
                {
                    p = context.Categorys.SingleOrDefault(x => x.CategoryId == cateId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
        public static void SaveCategory(Category c)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Categorys.Add(c);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateCategory(Category c)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    context.Entry<Category>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteCategory(Category c)
        {
            try
            {
                using (var context = new MyDBContext())
                {
                    var c1 = context.Categorys.SingleOrDefault(a => a.CategoryId == c.CategoryId);
                    context.Categorys.Remove(c1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
