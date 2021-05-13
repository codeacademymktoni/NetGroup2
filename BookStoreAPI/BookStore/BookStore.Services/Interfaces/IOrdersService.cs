using BookStore.Models;
namespace BookStore.Services.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Creates new order
        /// </summary>
        /// <param name="order"></param>
        void Create(Order order);
    }
}
