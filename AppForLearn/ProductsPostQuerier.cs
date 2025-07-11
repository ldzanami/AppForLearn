using Microsoft.EntityFrameworkCore;

namespace AppForLearn
{
    public class ProductsPostQuerier : DbContext, IDatabasePostQuerier<Product>
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=a;Database=postgres;");
        }

        public async Task AddItem(Product product)
        {
            await Products.AddAsync(product);
            await SaveChangesAsync();
        }

        public async Task AddItems(Product[] products)
        {
            await Products.AddRangeAsync(products);
            await SaveChangesAsync();
        }

    }
}
