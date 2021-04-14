using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.Interfaces;
using System.Collections.Generic;

namespace MyRecipes.Services
{
    public class RecipeTypesService : IRecipeTypesService
    {
        private readonly IRecipeTypesRepository _recipeTypesRepository;

        public RecipeTypesService(IRecipeTypesRepository recipeTypesRepository)
        {
            _recipeTypesRepository = recipeTypesRepository;
        }

        public List<RecipeType> GetAll()
        {
            return _recipeTypesRepository.GetAll();
        }

        public bool CheckIfExists(int recipeTypeId)
        {
            var recipeType = _recipeTypesRepository.GetById(recipeTypeId);

            return recipeType != null;
        }
    }
}
