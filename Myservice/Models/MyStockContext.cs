using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public class MyStockContext:DbContext
    {
        public MyStockContext(DbContextOptions<MyStockContext> options) : base(options) { }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MystockDBContext"));
        }
    }
}
