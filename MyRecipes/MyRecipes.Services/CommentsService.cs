using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System;

namespace MyRecipes.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IRecipesService _recipesService;

        public CommentsService(ICommentsRepository commentsRepository, IRecipesService recipesService)
        {
            _commentsRepository = commentsRepository;
            _recipesService = recipesService;
        }

        public StatusModel Add(string comment, int recipeId, int userId)
        {
            var response = new StatusModel();

            var recipe = _recipesService.GetRecipeById(recipeId);

            if(recipe != null) 
            {
                var newComment = new Comment()
                {
                    Message = comment,
                    DateCreated = DateTime.Now,
                    RecipeId = recipeId,
                    UserId = userId
                };

                _commentsRepository.Add(newComment);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The recipe with Id {recipeId} was not found";
            }

            return response;
        }
    }
}
