using Disaster.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Disaster.API.Data
{
    public class DataContext : DbContext
    {
        // When you migrate it checks in the Context to create tables
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<UserList> UserLists { get; set; }

        // Maybe later, doesn't affect database I think just how .net handles models
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<ListItem>()
        //             .HasKey(k => new {k.ListId, k.IngredientId});
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Here is where the server connection is made
            optionsBuilder.UseSqlServer(@"Server=ZKWIECINSKI\MSSQLSERVER_2014;Database=RecipeForDisaster_Dev;Trusted_Connection=True");
            // optionsBuilder.UseSqlServer(@"Server=localhost;Database=RecipeForDisaster_Dev;Trusted_Connection=True");
        }
    }
}