﻿using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IRecipesRepository : IBaseRepository<Recipe>
    {
        List<Recipe> GetRecipesWithFilters(string title);
        List<Recipe> GetMostRecentRecipes(int count);
        List<Recipe> GetTopRecipes(int count);
    }
}
