using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class RecipeLikesRepository : BaseRepository<RecipeLike>, IRecipeLikesRepository
    {
        public RecipeLikesRepository(MyRecipesDbContext context) : base(context)
        {
        }

        public RecipeLike Get(int recipeId, int userId)
        {
            return _context.RecipeLikes.FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);
        }
    }
}
