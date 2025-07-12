using Microsoft.EntityFrameworkCore;

namespace AppForLearn
{
    public class ProductsPatchQuerier : DbContext, IDatabasePatchQuerier<List<Product>, Product>
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=a;Database=postgres;");
        }

        public async Task<List<Product>> FindItemsFromDB(int[] ids) => await Products.Where(p => ids.Contains(p.Id)).ToListAsync();

        public async Task SaveDBChanges() => await SaveChangesAsync();

        public async Task<Product> FindItemFromDB(int id) => await Products.FindAsync(id);

        public async Task ReplaceItemInDB(Product product)
        {
            Products.Remove((await Products.FindAsync(product.Id))!);
            await SaveChangesAsync();
            await Products.AddAsync(product);
            await SaveChangesAsync();
        }
    }
}
