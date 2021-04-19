
using PizzaPlace.Models;

namespace PizzaPlace.Services.Interfaces
{
    public interface IOrderService
    {
        void Create(Order newOrder);
    }
}
