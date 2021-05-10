using BookStore.Models;
namespace BookStore.Services.Interfaces
{
    public interface IOrdersService
    {
        void Create(Order order);
    }
}
