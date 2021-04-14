using MyRecipes.Models;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IRecipeLikesRepository : IBaseRepository<RecipeLike>
    {
        RecipeLike Get(int recipeId, int userId);
    }
}
