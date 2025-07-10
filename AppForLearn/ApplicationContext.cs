using Microsoft.EntityFrameworkCore;

namespace AppForLearn
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=a;Database=postgres;");
        }

        public List<Product> SelectAllFromDataBase() => [.. from Product in Products select Product];

        public List<Product> SelectIdFromDatabase(int id) => [.. from Product in Products where Product.Id == id select Product];

        public List<Product> SelectNameFromDatabase(string name) => [.. from Product in Products where Product.Name == name select Product];

        public List<Product> SelectAllSortedToIdFromDatabase() => [.. from Product in Products orderby Product.Id select Product];

        public List<Product> SelectAllSortedToIdDescFromDatabase() => [.. from Product in Products orderby Product.Id descending select Product];

        public List<Product> SelectAllSortedToNameFromDatabase() => [.. from Product in Products orderby Product.Name select Product];

        public List<Product> SelectAllSortedToNameDescFromDatabase() => [.. from Product in Products orderby Product.Name descending select Product];

        public List<Product> SelectRangeToIdFromDatabase(int startId, int endId) => [.. from Product in Products where Product.Id >= startId && Product.Id <= endId select Product];

        public List<Product> SelectRangeToIdDescFromDatabase(int startId, int endId) => [.. from Product in Products where Product.Id >= startId && Product.Id <= endId orderby Product.Id descending select Product];

        public List<Product> SelectCostFromDatabase(float cost) => [.. from Product in Products where Product.Cost == cost select Product];

        public List<Product> SelectAllSortedToCostFromDatabase() => [.. from Product in Products orderby Product.Cost select Product];

        public List<Product> SelectAllSortedToCostDescFromDatabase() => [.. from Product in Products orderby Product.Cost descending select Product];

        public List<Product> SelectRangeToCostFromDatabase(float startCost, float endCost) => [.. from Product in Products where Product.Cost >= startCost && Product.Cost <= endCost select Product];

        public List<Product> SelectRangeToCostDescFromDatabase(float startCost, float endCost) => [.. from Product in Products where Product.Cost >= startCost && Product.Cost <= endCost orderby Product.Cost descending select Product];
    }
}
