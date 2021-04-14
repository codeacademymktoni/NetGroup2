using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipeTypesService
    {
        List<RecipeType> GetAll();
        bool CheckIfExists(int recipeTypeId);
    }
}
