using Microsoft.EntityFrameworkCore;
using PizzaPlace.Models;

namespace PizzaPlace.Repositories
{
    public class PizzaPlaceDbContext : DbContext
    {
        public PizzaPlaceDbContext(DbContextOptions<PizzaPlaceDbContext> options) : base(options)
        {}

        public DbSet<Offer> Offers{ get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuItem>()
                .HasIndex(u => u.Slug)
                .IsUnique();
        }
    }
}
