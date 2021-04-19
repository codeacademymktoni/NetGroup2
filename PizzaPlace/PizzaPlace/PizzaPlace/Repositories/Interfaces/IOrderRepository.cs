using PizzaPlace.Models;
namespace PizzaPlace.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order newOrder);
    }
}
