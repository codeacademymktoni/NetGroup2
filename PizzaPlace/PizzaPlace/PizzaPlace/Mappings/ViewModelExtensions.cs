using PizzaPlace.Models;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Mappings
{
    public static class ViewModelExtensions
    {
        public static Order ToDomainModel(this OrderViewModel viewModel)
        {
            return new Order
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                Message = viewModel.Message
            };
        }
    }
}
