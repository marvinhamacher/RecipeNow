using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeNow.Data.Entities;
using RecipeNow.Data.Entities.RecipeSystem;

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