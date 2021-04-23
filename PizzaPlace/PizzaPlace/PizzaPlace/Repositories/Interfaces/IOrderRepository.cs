using PizzaPlace.Models;
using System.Collections.Generic;

namespace PizzaPlace.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order newOrder);

        List<Order> GetAll();

        Order GetById(int id);
        void Update(Order order);
    }
}
