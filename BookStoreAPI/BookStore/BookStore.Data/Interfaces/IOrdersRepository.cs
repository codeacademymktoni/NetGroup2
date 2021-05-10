using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Interfaces
{
    public interface IOrdersRepository
    {
        void Create(Order order);
    }
}
