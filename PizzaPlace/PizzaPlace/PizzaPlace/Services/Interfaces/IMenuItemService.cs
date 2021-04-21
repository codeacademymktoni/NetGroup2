using PizzaPlace.Models;
using System.Collections.Generic;

namespace PizzaPlace.Services.Interfaces
{
    public interface IMenuItemService
    {
        List<MenuItem> GetAll();
        MenuItem GetById(int id);
        MenuItem GetBySlug(string slug);
    }
}
