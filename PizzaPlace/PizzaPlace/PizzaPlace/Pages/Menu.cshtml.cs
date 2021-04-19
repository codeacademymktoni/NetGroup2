using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlace.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IMenuItemService _menuItemService;

        public MenuModel(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public List<MenuItemViewModel> MenuItems { get; set; }

        public void OnGet()
        {
            List<MenuItem> menuItems = _menuItemService.GetAll();
            MenuItems = menuItems.Select(x => x.ToViewModel()).ToList();
        }
    }
}
