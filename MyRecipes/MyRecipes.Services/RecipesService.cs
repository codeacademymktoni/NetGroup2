using MyRecipes.Common.Exceptions;
using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MyRecipes.Services
{
    public class RecipesService : IRecipesService
    {
        private IRecipesRepository _recipeRepository { get; set; }
        public RecipesService(IRecipesRepository recipesRepository)
        {
            _recipeRepository = recipesRepository;
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipeRepository.GetAll();
        }

        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public void CreateRecipe(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
        }

        public List<Recipe> GetRecipesByTitle(string title)
        {
            if (title == null) 
            {
                return _recipeRepository.GetAll();
            }
            else
            {
                return _recipeRepository.GetByTitle(title);
            }
        }

        public void Delete(int id)
        {
            var recipe = _recipeRepository.GetById(id);

            if(recipe == null)
            {
                throw new NotFoundException($"The recipe with id {id} was not found");
            }
            else
            {
                _recipeRepository.Delete(recipe);
            }
        }
    }
}
