using Disaster.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Disaster.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Here is where the server connection is made
            optionsBuilder.UseSqlServer(@"Server=ZKWIECINSKI\MSSQLSERVER_2014;Database=RecipeForDisaster_Dev;Trusted_Connection=True");
            // optionsBuilder.UseSqlServer(@"Server=localhost;Database=RecipeForDisaster_Dev;Trusted_Connection=True");
        }
    }
}