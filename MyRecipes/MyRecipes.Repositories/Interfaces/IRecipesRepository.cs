using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IRecipesRepository
    {
        List<Recipe> GetAll();
        List<Recipe> GetByTitle(string title);
        Recipe GetById(int id);
        void Add(Recipe recipe);
        void Delete(Recipe recipe);
        void Update(Recipe recipe);
    }
}
