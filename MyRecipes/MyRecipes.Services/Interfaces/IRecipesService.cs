
using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAllRecipes();

        List<Recipe> GetRecipesByTitle(string title);

        Recipe GetRecipeById(int id);

        void CreateRecipe(Recipe recipe);

        void Delete(int id);
        void Update(Recipe recipe);
    }
}
