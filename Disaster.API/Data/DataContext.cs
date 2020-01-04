using Disaster.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options) {}

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}