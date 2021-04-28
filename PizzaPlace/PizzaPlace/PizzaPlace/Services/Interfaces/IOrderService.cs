
using PizzaPlace.Models;
using System.Collections.Generic;

namespace PizzaPlace.Services.Interfaces
{
    public interface IOrderService
    {
        void Create(Order newOrder);

        List<Order> GetAll();

        List<Order> GetByStatus(OrderStatus status);

        void SetStatus(int id, OrderStatus status);
    }
}
