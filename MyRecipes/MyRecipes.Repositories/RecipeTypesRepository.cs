
using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;

namespace MyRecipes.Repositories
{
    public class RecipeTypesRepository : BaseRepository<RecipeType>, IRecipeTypesRepository
    {
        public RecipeTypesRepository(MyRecipesDbContext context) : base(context)
        {
        }
    }
}
