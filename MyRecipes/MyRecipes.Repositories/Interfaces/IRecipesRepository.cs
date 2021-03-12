using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IRecipesRepository
    {
        List<Recipe> GetAll();
        Recipe GetById(int id);
    }
}
