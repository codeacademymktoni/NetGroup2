using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private MyRecipesDbContext _context { get; set; }

        public RecipesRepository(MyRecipesDbContext context)
        {
            _context = context;
        }

        public void Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void Delete(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }

        public void Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public List<Recipe> GetAll()
        {
            var recipes = _context.Recipes.ToList();
            return recipes;
        }

        public Recipe GetById(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(x => x.Id == id);
            return recipe;
        }

        public List<Recipe> GetByTitle(string title)
        {
            var recipes = _context.Recipes.Where(x => x.Title.Contains(title)).ToList();
            return recipes;
        }
    }
}
