using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using System.Collections.Generic;

namespace PizzaPlace.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemRepository.GetAll();
        }

        public MenuItem GetById(int id)
        {
            return _menuItemRepository.GetById(id);
        }

        public MenuItem GetBySlug(string slug)
        {
            return _menuItemRepository.GetBySlug(slug);
        }
    }
}
