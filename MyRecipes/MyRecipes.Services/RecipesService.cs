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
        private readonly IRecipeTypesService _recipeTypesService;

        private IRecipesRepository _recipeRepository { get; set; }
        public RecipesService(IRecipesRepository recipesRepository, IRecipeTypesService recipeTypesService)
        {
            _recipeRepository = recipesRepository;
            _recipeTypesService = recipeTypesService;
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipeRepository.GetAll();
        }

        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public Recipe GetRecipeDetails(int id)
        {
            var recipe = GetRecipeById(id);

            if(recipe == null)
            {
                return recipe;
            }

            recipe.Views++;

            _recipeRepository.Update(recipe);

            return recipe;
        }

        public StatusModel CreateRecipe(Recipe recipe)
        {
            var response = new StatusModel();

            if (!_recipeTypesService.CheckIfExists(recipe.RecipeTypeId))
            {
                response.IsSuccessful = false;
                response.Message = $"Recipe type with id {recipe.RecipeTypeId} does not exist";

                return response;
            }

            recipe.DateCreated = DateTime.Now;
            _recipeRepository.Add(recipe);

            return response;
        }

        public List<Recipe> GetRecipesWithFilters(string title)
        {
           return _recipeRepository.GetRecipesWithFilters(title);
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
                updatedRecipe.RecipeTypeId = recipe.RecipeTypeId;

                _recipeRepository.Update(updatedRecipe);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The recipe with id {recipe.Id} was not found";
            }

            return response;
        }

        public List<Recipe> GetMostRecentRecipes(int count)
        {
            return  _recipeRepository.GetMostRecentRecipes(count);
        }

        public List<Recipe> GetTopRecipes(int count)
        {
            return _recipeRepository.GetTopRecipes(count);
        }
    }
}
