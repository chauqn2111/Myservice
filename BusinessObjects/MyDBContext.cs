using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDBContext: DbContext
    {
        public MyDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MystockDB"));
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                new Category { CategoryId = 1, CategoryName = "Beverages"},
                new Category { CategoryId = 2, CategoryName = "Condiment" },
                new Category { CategoryId = 3, CategoryName = "Confection" },
                new Category { CategoryId = 4, CategoryName = "Dairi Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Gereals" },
                new Category { CategoryId = 6, CategoryName = "Meal/Poultry" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "Seafood" },
                new Category { CategoryId = 9, CategoryName = "Bedfood" }
                );
            modelBuilder.Entity<Product>().HasData
                (
                new Product {ProductId = 1, ProductName = "Quang Le", CategoryId = 1,UnitsInStock = 20, UnitPrice = 67333000 },
                new Product {ProductId = 2, ProductName = "Bao An", CategoryId = 2, UnitsInStock = 20, UnitPrice = 223230 },
                new Product {ProductId = 3, ProductName = "Truong Vinh", CategoryId = 3, UnitsInStock = 456, UnitPrice = 42333 },
                new Product {ProductId = 4, ProductName = "Hoa Khanh", CategoryId = 4, UnitsInStock = 300, UnitPrice = 543322 },
                new Product {ProductId = 5, ProductName = "Le Thien", CategoryId = 5, UnitsInStock = 250, UnitPrice = 3215556 },
                new Product {ProductId = 6, ProductName = "Bao Quoc", CategoryId = 6, UnitsInStock = 15, UnitPrice = 1500000 },
                new Product {ProductId = 7, ProductName = "Truong Phi", CategoryId = 7, UnitsInStock = 1, UnitPrice = 222222 },
                new Product {ProductId = 8, ProductName = "QuanVu", CategoryId = 8, UnitsInStock = 1, UnitPrice = 12345 },
                new Product {ProductId = 9, ProductName = "Luu Bi", CategoryId = 9, UnitsInStock = 1, UnitPrice = 54321 }
                );
        }
    }
}
