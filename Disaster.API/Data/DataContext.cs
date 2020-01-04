using Microsoft.EntityFrameworkCore;

namespace DisasterBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options) {}

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}