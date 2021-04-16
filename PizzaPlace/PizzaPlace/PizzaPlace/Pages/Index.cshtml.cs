using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOfferService _offerService;

        public IndexModel(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public List<OfferViewModel> Offers { get; set; }

        public void OnGet()
        {
            var offers = _offerService.GetAllValid();
            Offers = offers.Select(x => x.ToViewModel()).ToList();
        }
    }
}
