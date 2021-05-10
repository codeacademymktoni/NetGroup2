using BookStore.Data.Interfaces;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BookStoreDbContext _context;

        public OrdersRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
