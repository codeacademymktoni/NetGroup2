using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class RecipesRepository : BaseRepository<Recipe>, IRecipesRepository
    {
        public RecipesRepository(MyRecipesDbContext context) : base(context)
        {
        }

        public List<Recipe> GetByTitle(string title)
        {
            var recipes = _context.Recipes.Where(x => x.Title.Contains(title)).ToList();
            return recipes;
        }
    }
}
