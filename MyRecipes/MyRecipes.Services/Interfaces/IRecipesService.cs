
using MyRecipes.Models;
using MyRecipes.Services.DtoModels;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAllRecipes();

        List<Recipe> GetRecipesByTitle(string title);

        Recipe GetRecipeById(int id);

        void CreateRecipe(Recipe recipe);

        StatusModel Delete(int id);
        StatusModel Update(Recipe recipe);
    }
}
