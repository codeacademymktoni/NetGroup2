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
    }
}
