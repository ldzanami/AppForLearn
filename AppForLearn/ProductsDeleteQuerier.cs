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

        public async Task<bool> DeleteAll()
        {
            var result = await Products.Where(p => p.Id > 0).ToListAsync();
            if (result.Count == 0) return false;
            Products.RemoveRange(result);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRangeToId(int startId,  int endId)
        {
            var products = await GetProductsArrayToId([.. Enumerable.Range(startId, endId - startId + 1)]);
            if (products.Count == 0) return false;
            Products.RemoveRange(products!);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteToId(int id)
        {
            var product = await Products.FindAsync(id);
            if (product == null) return false;
            Products.Remove(product!);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteArrayToId(int[] ids)
        {
            var products = await GetProductsArrayToId(ids);
            if (products.Count == 0) return false;
            Products.RemoveRange(products!);
            await SaveChangesAsync();
            return true;
        }
    }
}