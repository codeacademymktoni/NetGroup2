using MyRecipes.Common.Exceptions;
using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.DtoModels;
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
            recipe.DateCreated = DateTime.Now;
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

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var recipe = _recipeRepository.GetById(id);

            if(recipe == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The recipe with id {id} was not found";
            }
            else
            {
                _recipeRepository.Delete(recipe);
            }

            return response;
        }

        public StatusModel Update(Recipe recipe)
        {
            var response = new StatusModel();
            var updatedRecipe = _recipeRepository.GetById(recipe.Id);

            if (updatedRecipe != null)
            {
                updatedRecipe.Title = recipe.Title;
                updatedRecipe.ImageUrl = recipe.ImageUrl;
                updatedRecipe.Description = recipe.Description;
                updatedRecipe.Directions = recipe.Directions;
                updatedRecipe.Ingredients = recipe.Ingredients;
                updatedRecipe.DateModified = DateTime.Now;

                _recipeRepository.Update(updatedRecipe);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The recipe with id {recipe.Id} was not found";
            }

            return response;
        }
    }
}
