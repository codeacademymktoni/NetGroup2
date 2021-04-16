using PizzaPlace.Models;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Mappings
{
    public static class DomainModelExtensions
    {
        public static OfferViewModel ToViewModel(this Offer entity)
        {
            return new OfferViewModel()
            {
                Title = entity.Title,
                Description = entity.Description,
                ValidTo = entity.ValidTo
            };
        }
    }
}
