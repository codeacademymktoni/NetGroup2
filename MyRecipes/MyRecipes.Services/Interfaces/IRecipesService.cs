
using MyRecipes.Models;
using MyRecipes.Services.DtoModels;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAllRecipes();

        List<Recipe> GetRecipesWithFilters(string title);

        Recipe GetRecipeById(int id);

        StatusModel CreateRecipe(Recipe recipe);

        StatusModel Delete(int id);

        StatusModel Update(Recipe recipe);

        Recipe GetRecipeDetails(int id);

        List<Recipe> GetMostRecentRecipes(int count);

        List<Recipe> GetTopRecipes(int count);
    }
}
