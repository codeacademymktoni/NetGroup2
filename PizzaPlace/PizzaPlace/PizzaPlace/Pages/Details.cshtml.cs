using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IMenuItemService _menuItemService;

        public DetailsModel(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public MenuItemViewModel MenuItem { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet(int id)
        {
            MenuItem menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                ErrorMessage = "The item could not be found";
            }
            else
            {
                MenuItem = menuItem.ToViewModel();
            }
        }
    }
}
