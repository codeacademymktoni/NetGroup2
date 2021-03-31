using Microsoft.EntityFrameworkCore;
using MyRecipes.Models;

namespace MyRecipes.Repositories
{
    public class MyRecipesDbContext : DbContext
    {
        public MyRecipesDbContext(DbContextOptions<MyRecipesDbContext> options): base(options)
        {}

        public DbSet<Recipe> Recipes{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
