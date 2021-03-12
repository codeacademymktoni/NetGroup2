
using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAllRecipes();

        Recipe GetRecipeById(int id);

        void CreateRecipe(Recipe recipe);
    }
}
