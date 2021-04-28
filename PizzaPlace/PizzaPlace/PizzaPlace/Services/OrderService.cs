using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PizzaPlace.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Create(Order newOrder)
        {
            newOrder.Status = OrderStatus.Pending;
            orderRepository.Add(newOrder);
        }

        public List<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public List<Order> GetByStatus(OrderStatus status)
        {
            return orderRepository.GetByStatus(status);
        }

        public void SetStatus(int id, OrderStatus status)
        {
            Order order = orderRepository.GetById(id);

            if(order != null)
            {
                order.Status = status;
                orderRepository.Update(order);
            }
        }
    }
}
