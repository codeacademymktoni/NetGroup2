using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlace.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly PizzaPlaceDbContext _dbContext;

        public MenuItemRepository(PizzaPlaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MenuItem> GetAll()
        {
            return _dbContext.MenuItems.ToList();
        }

        public MenuItem GetById(int id)
        {
            return _dbContext.MenuItems.FirstOrDefault(x => x.Id == id);
        }

        public MenuItem GetBySlug(string slug)
        {
            return _dbContext.MenuItems.FirstOrDefault(x => x.Slug.ToLower() == slug.ToLower());
        }
    }
}
