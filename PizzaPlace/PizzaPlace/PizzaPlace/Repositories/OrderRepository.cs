using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;

namespace PizzaPlace.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaPlaceDbContext _dbContext;

        public OrderRepository(PizzaPlaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Order newOrder)
        {
            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();
        }
    }
}
