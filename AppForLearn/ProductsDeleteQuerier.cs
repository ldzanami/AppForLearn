using Microsoft.EntityFrameworkCore;

namespace AppForLearn
{
    public class ProductsDeleteQuerier : DbContext, IDatabaseDeleteQuerier
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=a;Database=postgres;");
        }

        private async Task<List<Product>> GetProductsArrayToId(int[] ids) => await Products.Where(p => ids.Contains(p.Id)).ToListAsync();

        public async Task DeleteAll() => await Database.ExecuteSqlRawAsync("delete from \"Products\"");

        public async Task DeleteRangeToId(int startId,  int endId)
        {
            var products = await GetProductsArrayToId([.. Enumerable.Range(startId, endId)]);
            if (products.Count == 0) return;
            Products.RemoveRange(products!);
            await SaveChangesAsync();
        }

        public async Task DeleteToId(int id)
        {
            var product = await Products.FindAsync(id);
            if (product == null) return;
            Products.Remove(product!);
            await SaveChangesAsync();
        }

        public async Task DeleteArrayToId(int[] ids)
        {
            var products = await GetProductsArrayToId(ids);
            if (products.Count == 0) return;
            Products.RemoveRange(products!);
            await SaveChangesAsync();
        }
    }
}