using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public List<Order> GetByStatus(OrderStatus orderStatus)
        {
            return _dbContext.Orders.Where(x => x.Status == orderStatus).ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Order order)
        {
            _dbContext.Update(order);
            _dbContext.SaveChanges();
        }
    }
}
