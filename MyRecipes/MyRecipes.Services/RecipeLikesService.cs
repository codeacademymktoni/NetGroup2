using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.Interfaces;

namespace MyRecipes.Services
{
    public class RecipeLikesService : IRecipeLikesService
    {
        private readonly IRecipeLikesRepository _recipeLikesRepository;

        public RecipeLikesService(IRecipeLikesRepository recipeLikesRepository)
        {
            _recipeLikesRepository = recipeLikesRepository;
        }

        public void Add(int recipeId, int userId)
        {
            var like = _recipeLikesRepository.Get(recipeId, userId);

            if (like == null)
            {
                var newLike = new RecipeLike();
                newLike.RecipeId = recipeId;
                newLike.UserId = userId;

                _recipeLikesRepository.Add(newLike);
            }
        }

        public void Remove(int recipeId, int userId)
        {
            var like = _recipeLikesRepository.Get(recipeId, userId);

            if (like != null)
            {
                _recipeLikesRepository.Delete(like);
            }
        }
    }
}
