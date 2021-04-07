﻿using Microsoft.EntityFrameworkCore;
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

        public override Recipe GetById(int entityId)
        {
           var recipe = _context.Recipes
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == entityId);
            return recipe;
        }

        public List<Recipe> GetMostRecentRecipes(int count)
        {
            return _context.Recipes.OrderByDescending(x => x.DateCreated).Take(count).ToList();
        }

        public List<Recipe> GetTopRecipes(int count)
        {
            return _context.Recipes.OrderByDescending(x => x.Views).Take(count).ToList();
        }
    }
}
