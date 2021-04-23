using PizzaPlace.Models;

namespace PizzaPlace.ViewModels
{
    public class OrdersListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public OrderStatus Status{ get; set; }
    }
}
