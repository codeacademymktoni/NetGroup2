using MyRecipes.Models;
using MyRecipes.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Services
{
    public class RecipesService
    {
        private RecipesRepository _recipeRepository { get; set; }
        public RecipesService()
        {
            _recipeRepository = new RecipesRepository();
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipeRepository.GetAll();
        }

        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetById(id);
        }
    }
}
