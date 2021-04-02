using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.Interfaces;
using System;

namespace MyRecipes.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void Add(string comment, int recipeId, int userId)
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
    }
}
