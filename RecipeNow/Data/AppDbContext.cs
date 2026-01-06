using Microsoft.EntityFrameworkCore;
using RecipeNow.Data.Entities;

namespace RecipeNow.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // DbSets für deine Entities
    public DbSet<Recipe> Recipes { get; set; }
}